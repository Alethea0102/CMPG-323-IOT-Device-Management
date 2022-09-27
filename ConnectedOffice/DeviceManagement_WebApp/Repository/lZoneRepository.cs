using DeviceManagement_WebApp.Models;
using System;

namespace DeviceManagement_WebApp.Repository
{
    public interface ILZoneRepository : IGenericRepository<Zone> 
    {
        Zone GetZoneById(int zoneId);
        Zone newGuid(Zone category);
        Guid getZoneId(Zone zone);
        bool zoneExists(Guid zoneid);
    }
}