using System.Text.Json.Serialization;

namespace CtrlAltQuest.Common
{
    [JsonConverter(typeof(UniqueIdConverter<UserId>))]
    public record UserId : UniqueId<UserId>
    {
        private static readonly Guid NamespaceGuid = new Guid("387afa8f-a7c2-4e11-8330-6c1b11cf068c");

        public UserId(Guid value) : base(value) { }

        [JsonConstructor]
        public UserId(string value) : base(value) { }

        public static UserId GenerateId(string value) => GenerateId(NamespaceGuid, value);
    }
}
