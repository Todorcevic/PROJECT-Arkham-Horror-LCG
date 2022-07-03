using System.Collections.Generic;

namespace Arkham.Model
{
    public class ZonesRepository
    {
        public Zone EncounterDiscardZone { get; set; } = new Zone();
        public Zone ScenarioZone { get; set; } = new Zone();
        public Zone ActZone { get; set; } = new Zone();
        public Zone AgendaZone { get; set; } = new Zone();
        public Zone PlayingZone { get; set; } = new Zone();
        public Zone SkillTestZone { get; set; } = new Zone();
        public Zone OutSideZone { get; set; } = new Zone();
        public Zone VictoryZone { get; set; } = new Zone();
        public List<Zone> Locations { get; private set; } = new List<Zone>();

        /*******************************************************************/
        public void Reset(int locationsAmount)
        {
            EncounterDiscardZone = new Zone();
            ScenarioZone = new Zone();
            ActZone = new Zone();
            AgendaZone = new Zone();
            PlayingZone = new Zone();
            SkillTestZone = new Zone();
            OutSideZone = new Zone();
            VictoryZone = new Zone();
            BuildLocationsZones(locationsAmount);
        }

        private void BuildLocationsZones(int amount)
        {
            Locations = new List<Zone>();
            for (int i = 0; i < amount; i++)
                Locations.Add(new Zone());
        }
    }
}
