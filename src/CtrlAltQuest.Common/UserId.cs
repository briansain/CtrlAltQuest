using System.Text.Json.Serialization;

namespace CtrlAltQuest.Common
{
    [JsonConverter(typeof(UniqueIdConverter<UserId>))]
    public class UserId : UniqueId<UserId>
    {
        public new static Guid NamespaceGuid => new Guid("387afa8f-a7c2-4e11-8330-6c1b11cf068c");

        [JsonConstructor]
        public UserId(string value) : base(value) { }
        public UserId(Guid value) : base(value) { }
    }
}
