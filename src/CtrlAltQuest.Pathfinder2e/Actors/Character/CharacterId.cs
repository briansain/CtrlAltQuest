using Be.Vlaanderen.Basisregisters.Generators.Guid;
using CtrlAltQuest.Common;
using System.Text.Json.Serialization;

namespace CtrlAltQuest.Pathfinder2e.Actors.Character
{
    public readonly struct CharacterId : ICharacterId
    {
        private static readonly Guid NamespaceGuid = new Guid("387afa8f-a7c2-4e11-8330-6c1b11cf068c");

        public Guid Value { get; }
        public CharacterId(Guid value) => Value = value;

        [JsonConstructor]
        public CharacterId(string value)
        {
            if (string.IsNullOrEmpty(value) || !value.StartsWith("character-", StringComparison.Ordinal))
                throw new ArgumentException(@"Invalid format; expected ""character-{guid}""", nameof(value));

            // Using Span<char> for better performance
            ReadOnlySpan<char> guidSpan = value.AsSpan("character-".Length);

            if (!Guid.TryParse(guidSpan, out var id))
                throw new ArgumentException(@"Invalid Guid; expected ""character-{guid}""", nameof(value));

            Value = id;
        }

        public override string ToString() => string.Create(48, Value, (span, id) =>
        {
            "character-".AsSpan().CopyTo(span);
            id.TryFormat(span.Slice(9), out _);
        });

        public static CharacterId GenerateId(string value) => new(Deterministic.Create(NamespaceGuid, value));
    }
}
