using Arkham.Model;
using System.Collections.Generic;
using Zenject;

namespace Arkham.Application.Gameplay
{
    public class ZonesManager
    {
        [Inject] private readonly List<ZoneView> allZones;

        /*******************************************************************/

        public ZoneView GetZoneByType(Zone zoneType) => allZones.Find(zone => zone.ZoneType == zoneType);
    }
}
