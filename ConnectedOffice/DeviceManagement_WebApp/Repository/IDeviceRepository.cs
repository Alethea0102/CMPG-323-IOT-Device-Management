using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query;
using System;

namespace DeviceManagement_WebApp.Repository
{
    public interface IDeviceRepository : IGenericRepository<Device>
    {
        IIncludableQueryable<Device,Zone> DevicesPerZone();
        IIncludableQueryable<Device,Zone> getDevicesPerZoneById(Guid id);
        SelectList getViewDataZoneId();
        SelectList getViewDataCategoryId();
        SelectList getViewDataZoneId(Guid zoneid);
        SelectList getViewDataCategoryId(Guid categoryid);
        Device NewGuidId(Device device);
        Guid deviceZoneId(Device device);
        Guid DeviceCategoryId(Device device);
        Guid GetDeviceid(Device device);
        bool DeviceExists(Guid deviceId);
    }
}
