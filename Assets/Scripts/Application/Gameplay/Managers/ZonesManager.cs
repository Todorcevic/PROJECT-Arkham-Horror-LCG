using Arkham.Model;
using System.Collections.Generic;
using Zenject;

namespace Arkham.Application.GamePlay
{
    public class ZonesManager
    {
        [Inject] private readonly List<ZoneView> allZones;

        public IEnumerable<ZoneView> AllZones => allZones;

        /*******************************************************************/

        public ZoneView GetZoneByType(ZoneType zoneType) => allZones.Find(zone => zone.ZoneType == zoneType);
    }
}
