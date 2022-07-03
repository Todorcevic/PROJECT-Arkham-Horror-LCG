using Arkham.Model;
using System.Collections.Generic;
using Zenject;

namespace Arkham.Application.GamePlay
{
    public class ZonesManager
    {
        private readonly Dictionary<Zone, ZoneView> zonesCorrespondecy = new Dictionary<Zone, ZoneView>();
        [Inject] private readonly List<ZoneView> allZones;
        [Inject] private readonly ZonesRepository zonesRepository;
        [Inject] private readonly PlayersRepository playersRepository;

        public IEnumerable<ZoneView> AllZones => allZones;

        /*******************************************************************/
        public ZoneView GetZoneView(Zone zone) => zonesCorrespondecy[zone];

        public ZoneView GetZoneByType(ZoneType zoneType) => allZones.Find(zoneView => zoneView.ZoneType == zoneType);

        private ZoneView GetVoidLocation() => allZones.Find(zoneView => zoneView.ZoneType == ZoneType.Location && !zonesCorrespondecy.ContainsValue(zoneView));

        public void AddZone(Zone zone, ZoneView zoneView)
        {
            zonesCorrespondecy.Add(zone, zoneView);
        }

        public void LinkZones()
        {
            LinkSingleZones();
            LinkPlayersZones();
            LinkRealtionLocations();

            void LinkSingleZones()
            {
                zonesCorrespondecy.Add(zonesRepository.EncounterDiscardZone, GetZoneByType(ZoneType.EncounterDiscard));
                zonesCorrespondecy.Add(zonesRepository.ScenarioZone, GetZoneByType(ZoneType.Scenario));
                zonesCorrespondecy.Add(zonesRepository.ActZone, GetZoneByType(ZoneType.Act));
                zonesCorrespondecy.Add(zonesRepository.AgendaZone, GetZoneByType(ZoneType.Agenda));
                zonesCorrespondecy.Add(zonesRepository.PlayingZone, GetZoneByType(ZoneType.Playing));
                zonesCorrespondecy.Add(zonesRepository.SkillTestZone, GetZoneByType(ZoneType.SkillTest));
                zonesCorrespondecy.Add(zonesRepository.OutSideZone, GetZoneByType(ZoneType.Outside));
                zonesCorrespondecy.Add(zonesRepository.VictoryZone, GetZoneByType(ZoneType.Outside));
            }

            void LinkPlayersZones()
            {
                foreach (Player player in playersRepository.AllPlayers)
                {
                    zonesCorrespondecy.Add(player.InvestigatorZone, GetZoneByType(ZoneType.Investigator));
                    zonesCorrespondecy.Add(player.HandZone, GetZoneByType(ZoneType.Hand));
                    zonesCorrespondecy.Add(player.DeckZone, GetZoneByType(ZoneType.InvestigatorDeck));
                    zonesCorrespondecy.Add(player.DiscardZone, GetZoneByType(ZoneType.InvestigatorDiscard));
                    zonesCorrespondecy.Add(player.AssetZone, GetZoneByType(ZoneType.Assets));
                    zonesCorrespondecy.Add(player.ThreatZone, GetZoneByType(ZoneType.Threats));
                }
            }

            void LinkRealtionLocations()
            {
                foreach (Zone zoneLocation in zonesRepository.Locations)
                {
                    zonesCorrespondecy.Add(zoneLocation, GetVoidLocation());
                }
            }
        }

        public void SelectedPlayerZones(Player player)
        {
            zonesCorrespondecy[player.InvestigatorZone] = GetZoneByType(ZoneType.Investigator);
            zonesCorrespondecy[player.HandZone] = GetZoneByType(ZoneType.Hand);
            zonesCorrespondecy[player.DeckZone] = GetZoneByType(ZoneType.InvestigatorDeck);
            zonesCorrespondecy[player.DiscardZone] = GetZoneByType(ZoneType.InvestigatorDiscard);
            zonesCorrespondecy[player.AssetZone] = GetZoneByType(ZoneType.Assets);
            zonesCorrespondecy[player.ThreatZone] = GetZoneByType(ZoneType.Threats);
        }

        public void DeselectPlayerZones(Player player)
        {
            if (player is NullPlayer) return;
            zonesCorrespondecy[player.InvestigatorZone] = GetZoneByType(ZoneType.Outside);
            zonesCorrespondecy[player.HandZone] = GetZoneByType(ZoneType.Outside);
            zonesCorrespondecy[player.DeckZone] = GetZoneByType(ZoneType.Outside);
            zonesCorrespondecy[player.DiscardZone] = GetZoneByType(ZoneType.Outside);
            zonesCorrespondecy[player.AssetZone] = GetZoneByType(ZoneType.Outside);
            zonesCorrespondecy[player.ThreatZone] = GetZoneByType(ZoneType.Outside);
        }
    }
}
