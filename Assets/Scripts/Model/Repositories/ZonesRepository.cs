using System.Collections.Generic;

namespace Arkham.Model
{
    public class ZonesRepository
    {
        public Zone EncounterDiscardZone { get; } = new Zone();
        public Zone ScenarioZone { get; } = new Zone();
        public Zone ActZone { get; } = new Zone();
        public Zone AgendaZone { get; } = new Zone();
        public Zone PlayingZone { get; } = new Zone();
        public Zone SkillTestZone { get; } = new Zone();
        public Zone OutSideZone { get; } = new Zone();
        public Zone VictoryZone { get; } = new Zone();
        public List<Zone> Locations { get; private set; } = new List<Zone>();

        /*******************************************************************/
        public void Reset()
        {
            Locations = new List<Zone>();
        }

        public void BuildLocationsZones(int amount)
        {
            for (int i = 0; i < amount; i++)
                Locations.Add(new Zone());
        }
    }
}
