using Be.Vlaanderen.Basisregisters.Generators.Guid;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CtrlAltQuest.Common
{
    public abstract class UniqueId<T> where T : UniqueId<T>
    {
        public static Guid NamespaceGuid => throw new ArgumentNullException("NamespaceGuid must be overridden");
        public Guid Value { get; }
        private static readonly string TypeName = typeof(T).Name.ToLower();

        public UniqueId(string value)
        {
            if (string.IsNullOrEmpty(value) || !value.StartsWith($"{TypeName}-", StringComparison.Ordinal))
                throw new ArgumentException(@$"Invalid format; expected ""{TypeName}-{{guid}}""", nameof(value));

            // Using Span<char> for better performance
            ReadOnlySpan<char> guidSpan = value.AsSpan(TypeName.Length + 1);

            if (!Guid.TryParse(guidSpan, out var id))
                throw new ArgumentException(@$"Invalid format; expected "" {TypeName} -{{guid}}""", nameof(value));

            Value = id;
        }

        public UniqueId(Guid value) => Value = value;

        public override string ToString() =>
            string.Create(TypeName.Length + 1 + 36, (TypeName, Value), (span, state) =>
            {
                var len = TypeName.Length;
                state.TypeName.AsSpan().CopyTo(span);
                span[len] = '-';
                state.Value.TryFormat(span.Slice(len + 1), out _);
            });

        public static T GenerateId(string value)
        {
            var guid = Deterministic.Create(NamespaceGuid, value);
            return Activator.CreateInstance(typeof(T), guid) as T ?? throw new ArgumentException($"Failed to create {TypeName} in GenerateId method");
        }
    }

    public class UniqueIdConverter<T> : JsonConverterFactory where T : UniqueId<T>
    {
        private static readonly Lazy<Func<JsonConverter>> ConverterFunc = new(() => Activator.CreateInstance<UniqueIdConverterInner<T>>, LazyThreadSafetyMode.ExecutionAndPublication);
        public override bool CanConvert(Type typeToConvert)
        {
            return true;
        }

        public override JsonConverter CreateConverter(
            Type type,
            JsonSerializerOptions options)
        {
            return ConverterFunc.Value.Invoke();
        }

        public class UniqueIdConverterInner<TUniqueId> : JsonConverter<TUniqueId>
        {
            private static ConstructorInfo? TypeConstructor;

            public UniqueIdConverterInner()
            {
                if (TypeConstructor == null)
                {
                    var constructors = typeof(TUniqueId).GetConstructors();
                    var jsonConstructor = constructors.FirstOrDefault(c => c.CustomAttributes.Any(ca => ca.AttributeType == typeof(JsonConstructorAttribute)));
                    TypeConstructor = jsonConstructor ?? throw new ArgumentException($"Type {typeof(TUniqueId)} must have constructor with attribute JsonConstructor");
                }
            }

            public override TUniqueId? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return (TUniqueId)(TypeConstructor?.Invoke([reader.GetString()]) ?? throw new Exception($"TypeConstructor was null for type {typeof(TUniqueId)}"));
            }

            public override void Write(Utf8JsonWriter writer, TUniqueId value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value?.ToString() ?? throw new ArgumentNullException($"{nameof(value)} is null in UniqueIdConverterInner.Write", nameof(value)));
            }
        }
    }
}
