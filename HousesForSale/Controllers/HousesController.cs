using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HousesForSale.Models;

namespace HousesForSale.Controllers
{
    public class HousesController : Controller
    {
        private readonly HousesForSaleContext _context;

        public HousesController(HousesForSaleContext context)
        {
            _context = context;
        }

        // GET: Houses
        public async Task<IActionResult> Index()
        {
            var housesForSaleContext = _context.Houses.Include(h => h.BuildingType).Include(h => h.ParkingType).Include(h => h.Region);
            return View(await housesForSaleContext.ToListAsync());
        }

        // GET: Houses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var houses = await _context.Houses
                .Include(h => h.BuildingType)
                .Include(h => h.ParkingType)
                .Include(h => h.Region)
                .SingleOrDefaultAsync(m => m.HouseId == id);
            if (houses == null)
            {
                return NotFound();
            }

            return View(houses);
        }

    //    // GET: Houses/Create
    //    public IActionResult Create()
    //    {
    //        ViewData["BuildingTypeId"] = new SelectList(_context.BuildingTypes, "Id", "Type");
    //        ViewData["ParkingTypeId"] = new SelectList(_context.ParkingTypes, "Id", "Type");
    //        ViewData["RegionId"] = new SelectList(_context.Regions, "Id", "RegionName");
    //        return View();
    //    }

    //    // POST: Houses/Create
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Create([Bind("HouseId,Price,Mlsnumber,StreetAddress,PostalCode,RegionId,BuildingTypeId,Bedrooms,Bathrooms,Storeys,ParkingTypeId")] Houses houses)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            _context.Add(houses);
    //            await _context.SaveChangesAsync();
    //            return RedirectToAction(nameof(Index));
    //        }
    //        ViewData["BuildingTypeId"] = new SelectList(_context.BuildingTypes, "Id", "Type", houses.BuildingTypeId);
    //        ViewData["ParkingTypeId"] = new SelectList(_context.ParkingTypes, "Id", "Type", houses.ParkingTypeId);
    //        ViewData["RegionId"] = new SelectList(_context.Regions, "Id", "RegionName", houses.RegionId);
    //        return View(houses);
    //    }

    //    // GET: Houses/Edit/5
    //    public async Task<IActionResult> Edit(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var houses = await _context.Houses.SingleOrDefaultAsync(m => m.HouseId == id);
    //        if (houses == null)
    //        {
    //            return NotFound();
    //        }
    //        ViewData["BuildingTypeId"] = new SelectList(_context.BuildingTypes, "Id", "Type", houses.BuildingTypeId);
    //        ViewData["ParkingTypeId"] = new SelectList(_context.ParkingTypes, "Id", "Type", houses.ParkingTypeId);
    //        ViewData["RegionId"] = new SelectList(_context.Regions, "Id", "RegionName", houses.RegionId);
    //        return View(houses);
    //    }

    //    // POST: Houses/Edit/5
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Edit(int id, [Bind("HouseId,Price,Mlsnumber,StreetAddress,PostalCode,RegionId,BuildingTypeId,Bedrooms,Bathrooms,Storeys,ParkingTypeId")] Houses houses)
    //    {
    //        if (id != houses.HouseId)
    //        {
    //            return NotFound();
    //        }

    //        if (ModelState.IsValid)
    //        {
    //            try
    //            {
    //                _context.Update(houses);
    //                await _context.SaveChangesAsync();
    //            }
    //            catch (DbUpdateConcurrencyException)
    //            {
    //                if (!HousesExists(houses.HouseId))
    //                {
    //                    return NotFound();
    //                }
    //                else
    //                {
    //                    throw;
    //                }
    //            }
    //            return RedirectToAction(nameof(Index));
    //        }
    //        ViewData["BuildingTypeId"] = new SelectList(_context.BuildingTypes, "Id", "Type", houses.BuildingTypeId);
    //        ViewData["ParkingTypeId"] = new SelectList(_context.ParkingTypes, "Id", "Type", houses.ParkingTypeId);
    //        ViewData["RegionId"] = new SelectList(_context.Regions, "Id", "RegionName", houses.RegionId);
    //        return View(houses);
    //    }

    //    // GET: Houses/Delete/5
    //    public async Task<IActionResult> Delete(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var houses = await _context.Houses
    //            .Include(h => h.BuildingType)
    //            .Include(h => h.ParkingType)
    //            .Include(h => h.Region)
    //            .SingleOrDefaultAsync(m => m.HouseId == id);
    //        if (houses == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(houses);
    //    }

    //    // POST: Houses/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> DeleteConfirmed(int id)
    //    {
    //        var houses = await _context.Houses.SingleOrDefaultAsync(m => m.HouseId == id);
    //        _context.Houses.Remove(houses);
    //        await _context.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }

    //    private bool HousesExists(int id)
    //    {
    //        return _context.Houses.Any(e => e.HouseId == id);
    //    }
    }
}
