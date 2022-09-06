﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OyingboBloodBank.Models;

namespace OyingboBloodBank.Controllers
{
    public class DonorsController : Controller
    {
        private readonly MushinBloodBankContext _context;

        public DonorsController(MushinBloodBankContext context)
        {
            _context = context;
        }

        // GET: Donors
        public async Task<IActionResult> Index()
        {
            var mushinBloodBankContext = _context.Donors.Include(d => d.BloodType);
            return View(await mushinBloodBankContext.ToListAsync());
        }

        // GET: Donors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Donors == null)
            {
                return NotFound();
            }

            var donor = await _context.Donors
                .Include(d => d.BloodType)
                .FirstOrDefaultAsync(m => m.DonorId == id);
            if (donor == null)
            {
                return NotFound();
            }

            return View(donor);
        }

        // GET: Donors/Create
        public IActionResult Create()
        {
            ViewData["BloodTypeId"] = new SelectList(_context.BloodGroups, "BloodTypeId", "BloodTypeId");
            return View();
        }

        // POST: Donors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DonorId,Name,City,PhoneNumber,Email,DonationDate,BloodTypeId")] Donor donor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BloodTypeId"] = new SelectList(_context.BloodGroups, "BloodTypeId", "BloodTypeId", donor.BloodTypeId);
            return View(donor);
        }

        // GET: Donors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Donors == null)
            {
                return NotFound();
            }

            var donor = await _context.Donors.FindAsync(id);
            if (donor == null)
            {
                return NotFound();
            }
            ViewData["BloodTypeId"] = new SelectList(_context.BloodGroups, "BloodTypeId", "BloodTypeId", donor.BloodTypeId);
            return View(donor);
        }

        // POST: Donors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DonorId,Name,City,PhoneNumber,Email,DonationDate,BloodTypeId")] Donor donor)
        {
            if (id != donor.DonorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonorExists(donor.DonorId))
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
            ViewData["BloodTypeId"] = new SelectList(_context.BloodGroups, "BloodTypeId", "BloodTypeId", donor.BloodTypeId);
            return View(donor);
        }

        // GET: Donors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Donors == null)
            {
                return NotFound();
            }

            var donor = await _context.Donors
                .Include(d => d.BloodType)
                .FirstOrDefaultAsync(m => m.DonorId == id);
            if (donor == null)
            {
                return NotFound();
            }

            return View(donor);
        }

        // POST: Donors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Donors == null)
            {
                return Problem("Entity set 'MushinBloodBankContext.Donors'  is null.");
            }
            var donor = await _context.Donors.FindAsync(id);
            if (donor != null)
            {
                _context.Donors.Remove(donor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonorExists(int id)
        {
          return (_context.Donors?.Any(e => e.DonorId == id)).GetValueOrDefault();
        }
    }
}
