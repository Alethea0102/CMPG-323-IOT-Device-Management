using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repository;

namespace DeviceManagement_WebApp.Controllers
{
    public class DevicesController : Controller
    {
        private readonly IDeviceRepository _deviceRepository;

        public DevicesController(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        // GET: Devices
        public async Task<IActionResult> Index()
        {
            //var connectedOfficeContext = _context.Device.Include(d => d.Category).Include(d => d.Zone);
            //return View(await connectedOfficeContext.ToListAsync());
            return (IActionResult)_deviceRepository.DevicesPerZone().ToList();
        }

        // GET: Devices/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var device = await _context.Device
                .Include(d => d.Category)
                .Include(d => d.Zone)
                .FirstOrDefaultAsync(m => m.DeviceId == id);*/
            var device = _deviceRepository.getDevicesPerZoneById((Guid)id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // GET: Devices/Create
        public IActionResult Create()
        {
            //ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName");
            ViewData["CategoryId"] = _deviceRepository.getViewDataCategoryId();
            //ViewData["ZoneId"] = new SelectList(_context.Zone, "ZoneId", "ZoneName");
            ViewData["ZoneId"] = _deviceRepository.getViewDataZoneId();
            return View();
        }

        // POST: Devices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            //device.DeviceId = Guid.NewGuid();
            var newDevice = _deviceRepository.NewGuidId(device);

            // _context.Add(device);
            _deviceRepository.Add(newDevice);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }

        // GET: Devices/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           // var device = await _context.Device.FindAsync(id);
           var device = _deviceRepository.GetById(id);
            if (device == null)
            {
                return NotFound();
            }
            var deviceCategoryId = _deviceRepository.DeviceCategoryId(device);
            var deviceZoneId     = _deviceRepository.deviceZoneId(device);
            //ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", device.CategoryId);
            ViewData["CategoryId"] = _deviceRepository.getViewDataCategoryId(deviceCategoryId);
            //ViewData["ZoneId"] = new SelectList(_context.Zone, "ZoneId", "ZoneName", device.ZoneId);
            ViewData["ZoneId"] = _deviceRepository.getViewDataZoneId(deviceZoneId);

            return View(device);
        }

        // POST: Devices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            var deviceId = _deviceRepository.GetDeviceid(device);

            if (id != deviceId)
            {
                return NotFound();
            }
            try
            {
                _deviceRepository.Update(device);
                //_context.Update(device);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(deviceId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: Devices/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            /*var device = await _context.Device
                .Include(d => d.Category)
                .Include(d => d.Zone)
                .FirstOrDefaultAsync(m => m.DeviceId == id);*/
            var device = _deviceRepository.getDevicesPerZoneById((Guid)id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
           // var device = await _context.Device.FindAsync(id);
            //_context.Device.Remove(device);
            //await _context.SaveChangesAsync();
            var device = _deviceRepository.GetById(id);
            _deviceRepository.Remove(device);
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceExists(Guid id)
        {
            //return _context.Device.Any(e => e.DeviceId == id);
            return _deviceRepository.DeviceExists(id);
        }
    }
}
