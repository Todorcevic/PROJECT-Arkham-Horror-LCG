﻿using System.Runtime.Serialization;

namespace Arkham.Application
{
    [DataContract]
    public class CampaignDTO
    {
        [DataMember] public string Id { get; set; }
        [DataMember] public string State { get; set; }
        [DataMember] public string FirstScenario { get; set; }
    }
}