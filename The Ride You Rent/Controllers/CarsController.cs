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
    public class CarsController : Controller
    {
        private readonly RideUrentyContext _context;

        public CarsController(RideUrentyContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            var rideUrentyContext = _context.Cars.Include(c => c.CarMake).Include(c => c.Carbody);
            return View(await rideUrentyContext.ToListAsync());
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cars == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.CarMake)
                .Include(c => c.Carbody)
                .FirstOrDefaultAsync(m => m.CarId == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            ViewData["CarMakeId"] = new SelectList(_context.CarMakes, "CarMakeId", "CarMakeId");
            ViewData["CarbodyId"] = new SelectList(_context.CarBodies, "CarbodyId", "CarbodyId");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarId,CarNo,CDescription,VehicleModel,CarBodyDescription,KmTravelled,ServiceKm,Availability,CarMakeId,CarbodyId")] Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarMakeId"] = new SelectList(_context.CarMakes, "CarMakeId", "CarMakeId", car.CarMakeId);
            ViewData["CarbodyId"] = new SelectList(_context.CarBodies, "CarbodyId", "CarbodyId", car.CarbodyId);
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cars == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            ViewData["CarMakeId"] = new SelectList(_context.CarMakes, "CarMakeId", "CarMakeId", car.CarMakeId);
            ViewData["CarbodyId"] = new SelectList(_context.CarBodies, "CarbodyId", "CarbodyId", car.CarbodyId);
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarId,CarNo,CDescription,VehicleModel,CarBodyDescription,KmTravelled,ServiceKm,Availability,CarMakeId,CarbodyId")] Car car)
        {
            if (id != car.CarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.CarId))
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
            ViewData["CarMakeId"] = new SelectList(_context.CarMakes, "CarMakeId", "CarMakeId", car.CarMakeId);
            ViewData["CarbodyId"] = new SelectList(_context.CarBodies, "CarbodyId", "CarbodyId", car.CarbodyId);
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cars == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.CarMake)
                .Include(c => c.Carbody)
                .FirstOrDefaultAsync(m => m.CarId == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cars == null)
            {
                return Problem("Entity set 'RideUrentyContext.Cars'  is null.");
            }
            var car = await _context.Cars.FindAsync(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
          return (_context.Cars?.Any(e => e.CarId == id)).GetValueOrDefault();
        }
    }
}
