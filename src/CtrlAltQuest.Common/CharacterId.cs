﻿using System.Text.Json.Serialization;

namespace CtrlAltQuest.Common
{
    [JsonConverter(typeof(UniqueIdConverter<CharacterId>))]
    public class CharacterId : UniqueId<CharacterId>
    {
        protected static new Guid NamespaceGuid => new Guid("387afa8f-a7c2-4e11-8330-6c1b11cf068c");

        [JsonConstructor]
        public CharacterId(string value) : base(value) { }
        public CharacterId(Guid value) : base(value) { }
    }
}
