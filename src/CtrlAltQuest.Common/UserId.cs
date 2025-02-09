using Be.Vlaanderen.Basisregisters.Generators.Guid;
using System.Text.Json.Serialization;

namespace CtrlAltQuest.Common
{
    public readonly struct UserId
    {
        private static readonly Guid NamespaceGuid = new Guid("387afa8f-a7c2-4e11-8330-6c1b11cf068c");

        public Guid Value { get; }
        public UserId(Guid value) => Value = value;

        [JsonConstructor]
        public UserId(string value)
        {
            if (string.IsNullOrEmpty(value) || !value.StartsWith("user-", StringComparison.Ordinal))
                throw new ArgumentException(@"Invalid format; expected ""user-{guid}""", nameof(value));

            // Using Span<char> for better performance
            ReadOnlySpan<char> guidSpan = value.AsSpan("user-".Length);

            if (!Guid.TryParse(guidSpan, out var id))
                throw new ArgumentException(@"Invalid Guid; expected ""user-{guid}""", nameof(value));

            Value = id;
        }

        public override string ToString() => string.Create(48, Value, (span, id) =>
        {
            "user-".AsSpan().CopyTo(span);
            id.TryFormat(span.Slice(4), out _);
        });

        public static UserId GenerateId(string value) => new(Deterministic.Create(NamespaceGuid, value));
    }
}
