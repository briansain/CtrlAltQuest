using Be.Vlaanderen.Basisregisters.Generators.Guid;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CtrlAltQuest.Common
{
    public abstract class UniqueId<T> where T : UniqueId<T>
    {
        public static Guid NamespaceGuid => throw new NotImplementedException();
        public Guid Value { get; }
        private static readonly string TypeName = typeof(T).Name.ToLower();
        private static Guid? TypedNamespaceGuid { get; set; }
        public UniqueId(string value)
        {
            if (string.IsNullOrEmpty(value) || !value.StartsWith($"{TypeName}-", StringComparison.Ordinal))
                throw new ArgumentException(@$"Invalid format; expected ""{TypeName}-{{guid}}""", nameof(value));

            // Using Span<char> for better performance
            ReadOnlySpan<char> guidSpan = value.AsSpan(TypeName.Length + 1);

            if (!Guid.TryParse(guidSpan, out var id))
                throw new ArgumentException(@$"Invalid format; expected ""{TypeName}-{{guid}}""", nameof(value));

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
            if (!TypedNamespaceGuid.HasValue)
            {
                var propertyInfo = typeof(T).GetMethod("get_NamespaceGuid", BindingFlags.Public | BindingFlags.Static);
                TypedNamespaceGuid = (Guid?)propertyInfo!.Invoke(null, null);
            }
            var guid = Deterministic.Create(TypedNamespaceGuid!.Value, value);
            return Activator.CreateInstance(typeof(T), guid) as T ?? throw new ArgumentException($"Failed to create {TypeName} in GenerateId method");
        }

		// ChatGPT helped with this :)
		public string ToBase64()
		{
			// Create a span for the byte array representing the GUID
			Span<byte> guidBytes = stackalloc byte[16];
			Value.TryWriteBytes(guidBytes);

			// Create a span for the Base64 character array (24 chars for 16 bytes)
			Span<char> base64Chars = stackalloc char[24];

			// Convert the bytes into Base64 characters
			Convert.TryToBase64Chars(guidBytes, base64Chars, out _);

			// Replace URL-unsafe Base64 characters with URL-safe ones
			for (int i = 0; i < base64Chars.Length; i++)
			{
                base64Chars[i] = base64Chars[i] switch
                {
                    '/' => '_',
                    '+' => '-',
                    var c => c
                };
			}

			// Remove padding characters '=' by slicing the span before '='
			int paddingIndex = base64Chars.IndexOf('=');
			if (paddingIndex == -1)
			{
				// If no padding is needed, just return the string
				return new string(base64Chars);
			}

			// Return the Base64 string without the padding
			return new string(base64Chars.Slice(0, paddingIndex));
		}


		// ChatGPT helped with this :)
		public static T FromBase64(string base64)
		{
            if (base64 == null) throw new ArgumentNullException(nameof(base64));

			// Ensure we have enough space for padding
			int missingPadding = (4 - (base64.Length % 4)) % 4;
			Span<char> buffer = stackalloc char[base64.Length + missingPadding];

			// Copy base64 input and replace URL-safe characters
			for (int i = 0; i < base64.Length; i++)
			{
				buffer[i] = base64[i] switch
				{
					'_' => '/',
					'-' => '+',
					var c => c
				};
			}

			// Append necessary padding
			for (int i = 0; i < missingPadding; i++)
			{
				buffer[base64.Length + i] = '=';
			}

			// Decode Base64 and create a GUID
			byte[] converted = Convert.FromBase64CharArray(buffer.ToArray(), 0, buffer.Length);
			return Activator.CreateInstance(typeof(T), new Guid(converted)) as T
				?? throw new ArgumentException($"Unable to convert {base64} to type {typeof(T)}");
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
