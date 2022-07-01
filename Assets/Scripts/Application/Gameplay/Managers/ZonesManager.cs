using Arkham.Model;
using System.Collections.Generic;
using Zenject;

namespace Arkham.Application.GamePlay
{
    public class ZonesManager
    {
        private readonly Dictionary<Zone, ZoneView> allRealZones = new Dictionary<Zone, ZoneView>();
        [Inject] private readonly PlayersRepository playerRepository;
        [Inject] private readonly List<ZoneView> allZones;

        public IEnumerable<ZoneView> AllZones => allZones;

        /*******************************************************************/
        public ZoneView GetZoneView(Zone zone) => allRealZones[zone];

        public ZoneView GetZoneByType(ZoneType zoneType) => allZones.Find(zone => zone.ZoneType == zoneType);

        public void BuildZones()
        {
            allRealZones.Add(playerRepository.PlayerLead.HandZone, GetZoneByType(ZoneType.Investigator));
        }
    }
}
