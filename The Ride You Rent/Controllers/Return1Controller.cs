using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using The_Ride_You_Rent.models;

namespace The_Ride_You_Rent.Controllers
{
    [Authorize]
    
    public class Return1Controller : Controller
    {
        private readonly RideUrentyContext _context;

        public Return1Controller(RideUrentyContext context)
        {
            _context = context;
        }

        // GET: Return1
        public async Task<IActionResult> Index()
        {
            var rideUrentyContext = _context.Returns.Include(r => r.Car).Include(r => r.Driver).Include(r => r.Inspector);
            return View(await rideUrentyContext.ToListAsync());
        }

        // GET: Return1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Returns == null)
            {
                return NotFound();
            }

            var return1 = await _context.Returns
                .Include(r => r.Car)
                .Include(r => r.Driver)
                .Include(r => r.Inspector)
                .FirstOrDefaultAsync(m => m.ReturnId == id);
            if (return1 == null)
            {
                return NotFound();
            }

            return View(return1);
        }

        // GET: Return1/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "CarId");
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverId");
            ViewData["InspectorId"] = new SelectList(_context.Inspectors, "InspectorId", "InspectorId");
            return View();
        }

        // POST: Return1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReturnId,CarNo,IName,DName,ReturnDate,ElapsedDate,RFine,CarId,InspectorId,DriverId")] Return1 return1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(return1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "CarId", return1.CarId);
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverId", return1.DriverId);
            ViewData["InspectorId"] = new SelectList(_context.Inspectors, "InspectorId", "InspectorId", return1.InspectorId);
            return View(return1);
        }

        // GET: Return1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Returns == null)
            {
                return NotFound();
            }

            var return1 = await _context.Returns.FindAsync(id);
            if (return1 == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "CarId", return1.CarId);
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverId", return1.DriverId);
            ViewData["InspectorId"] = new SelectList(_context.Inspectors, "InspectorId", "InspectorId", return1.InspectorId);
            return View(return1);
        }

        // POST: Return1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReturnId,CarNo,IName,DName,ReturnDate,ElapsedDate,RFine,CarId,InspectorId,DriverId")] Return1 return1)
        {
            if (id != return1.ReturnId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(return1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Return1Exists(return1.ReturnId))
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
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "CarId", return1.CarId);
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverId", return1.DriverId);
            ViewData["InspectorId"] = new SelectList(_context.Inspectors, "InspectorId", "InspectorId", return1.InspectorId);
            return View(return1);
        }

        // GET: Return1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Returns == null)
            {
                return NotFound();
            }

            var return1 = await _context.Returns
                .Include(r => r.Car)
                .Include(r => r.Driver)
                .Include(r => r.Inspector)
                .FirstOrDefaultAsync(m => m.ReturnId == id);
            if (return1 == null)
            {
                return NotFound();
            }

            return View(return1);
        }

        // POST: Return1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Returns == null)
            {
                return Problem("Entity set 'RideUrentyContext.Returns'  is null.");
            }
            var return1 = await _context.Returns.FindAsync(id);
            if (return1 != null)
            {
                _context.Returns.Remove(return1);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Return1Exists(int id)
        {
          return (_context.Returns?.Any(e => e.ReturnId == id)).GetValueOrDefault();
        }
    }
}
