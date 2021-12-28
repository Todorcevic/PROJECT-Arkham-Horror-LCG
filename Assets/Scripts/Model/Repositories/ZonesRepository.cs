using System;
using System.Collections.Generic;

namespace Arkham.Model
{
    public class ZonesRepository
    {
        private List<Zone> allZones;

        /*******************************************************************/
        public void Add(Zone newZone) => allZones.Add(newZone);

        public void Reset() => allZones = new List<Zone>();

        public Zone GetZoneByType(ZoneType zoneType) => allZones.Find(zone => zone.Type == zoneType);

        public Zone GetZoneById(Guid zoneGuid) => allZones.Find(zone => zone.Guid == zoneGuid);
    }
}
