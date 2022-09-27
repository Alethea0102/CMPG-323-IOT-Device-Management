using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repository;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class ZoneRepository : GenericRepository<Zone>, ILZoneRepository
    {
        public ZoneRepository(ConnectedOfficeContext context) : base(context)
        {
        }

        public Zone GetZoneById(int zoneId)
        {
            return _context.Zone.Find(zoneId);
        }

        public Guid getZoneId(Zone zone)
        {
            return zone.ZoneId;
        }

        public Zone newGuid(Zone zone)
        {
            var zoneid = zone.ZoneId = Guid.NewGuid();
            return zone;
        }

        public bool zoneExists(Guid zoneid)
        {
            return _context.Zone.Any(e => e.ZoneId == zoneid);
        }
    }
}
