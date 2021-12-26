using System;

namespace Arkham.Model
{
    public enum InvestigatorState { None, Killed, Insane, Retired }

    [Flags]
    public enum Zone
    {
        None = 0,
        Investigator = 1,
        InvestigatorDeck = 2,
        InvestigatorDiscard = 4,
        Hand = 8,
        Assets = 16,
        Threats = 32,
        EncounterDeck = 64,
        EncounterDiscard = 128,
        Scenario = 256,
        Agenda = 512,
        Act = 1024,
        Location = 2048,
        Card = 4096,
        Playing = 8192,
        Outside = 16384,
        SkillTest = 32768,
        Victory = 65536
    }
}
