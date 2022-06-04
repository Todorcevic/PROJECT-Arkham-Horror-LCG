using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Arkham.Model
{
    public class ZonesRepository
    {
        private List<Zone> allZones;

        public Zone EncounterZone { get; } = new Zone(ZoneType.EncounterDeck);
        public Zone DiscardZone { get; } = new Zone(ZoneType.EncounterDiscard);
        public Zone ScenarioZone { get; } = new Zone(ZoneType.Scenario);
        public Zone ActZone { get; } = new Zone(ZoneType.Act);
        public Zone AgendaZone { get; } = new Zone(ZoneType.Agenda);
        public Zone PlayingZone { get; } = new Zone(ZoneType.Playing);
        public Zone SkillTestZone { get; } = new Zone(ZoneType.SkillTest);
        public Zone OutSideZone { get; } = new Zone(ZoneType.Outside);
        public Zone VictoryZone { get; } = new Zone(ZoneType.Victory);
        public List<Zone> Locations { get; private set; }
        public ReadOnlyCollection<Zone> AllZones => allZones.AsReadOnly();

        /*******************************************************************/
        public void Add(Zone newZone) => allZones.Add(newZone);

        public void AddRange(IEnumerable<Zone> newZones) => allZones.AddRange(newZones);

        public void Reset()
        {
            allZones = new List<Zone>();
            Locations = new List<Zone>();
        }

        public Zone GetZoneByType(ZoneType zoneType) => allZones.Find(zone => zone.Type == zoneType);

        public Zone GetZoneById(Guid zoneGuid) => allZones.Find(zone => zone.Guid == zoneGuid);

        public Zone GetZoneWithThisCard(Card card) => allZones.Find(zone => zone.ContainThisCard(card));

        public void BuildZones()
        {
            Add(EncounterZone);
            Add(DiscardZone);
            Add(ScenarioZone);
            Add(ActZone);
            Add(AgendaZone);
            Add(PlayingZone);
            Add(SkillTestZone);
            Add(OutSideZone);
            Add(VictoryZone);
        }

        public void BuildLocationsZones(int amount)
        {
            for (int i = 0; i < amount; i++)
                Locations.Add(new Zone(ZoneType.Location));
            AddRange(Locations);
        }
    }
}
