﻿using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(ConnectedOfficeContext context) : base(context)
        {
        }

        public Guid DeviceCategoryId(Device device)
        {
            return device.CategoryId;
        }

        public bool DeviceExists(Guid deviceId)
        {
            return _context.Device.Any(x => x.DeviceId == deviceId);
        }

        public IIncludableQueryable<Device, Zone> DevicesPerZone()
        {
            var connectedOfficeContext = _context.Device.Include(d => d.Category).Include(d => d.Zone);

            return connectedOfficeContext;
        }

        public Guid deviceZoneId(Device device)
        {
            return device.ZoneId;
        }

        public Guid GetDeviceid(Device device)
        {
            return device.DeviceId;
        }

        public IIncludableQueryable<Device, Zone> getDevicesPerZoneById(Guid id)
        {
            var device = _context.Device.Include(e => e.Category).Include(e => e.Zone);
            return device;
        }

        public SelectList getViewDataCategoryId()
        {
            SelectList categoryIdViewData = new SelectList(_context.Category, "CategoryId", "CategoryName");
            return categoryIdViewData;
        }

        public SelectList getViewDataCategoryId(Guid categoryid)
        {
            SelectList categoryIdViewData = new SelectList(_context.Category, "CategoryId", "CategoryName",categoryid);
            return categoryIdViewData;
        }

        public SelectList getViewDataZoneId()
        {
            SelectList ZoneIdViewData = new SelectList(_context.Zone, "ZoneId", "ZoneName");
            return ZoneIdViewData;
        }

        public SelectList getViewDataZoneId(Guid zoneid)
        {
            SelectList ZoneIdViewData = new SelectList(_context.Zone, "ZoneId", "ZoneName", zoneid);
            return ZoneIdViewData;
        }

        public Device NewGuidId(Device device)
        {
            device.DeviceId = Guid.NewGuid();
            return device;
        }
    }
}
