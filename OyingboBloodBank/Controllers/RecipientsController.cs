using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OyingboBloodBank.Models;

namespace OyingboBloodBank.Controllers
{
    public class RecipientsController : Controller
    {
        private readonly MushinBloodBankContext _context;

        public RecipientsController(MushinBloodBankContext context)
        {
            _context = context;
        }

        // GET: Recipients
        public async Task<IActionResult> Index()
        {
            
            return View();
        }
        public async Task<IActionResult> List()
        {
            var mushinBloodBankContext = _context.Recipients.Include(r => r.BloodType);
            return View(await mushinBloodBankContext.ToListAsync());
        }

        // GET: Recipients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Recipients == null)
            {
                return NotFound();
            }

            var recipient = await _context.Recipients
                .Include(r => r.BloodType)
                .FirstOrDefaultAsync(m => m.RecipientId == id);
            if (recipient == null)
            {
                return NotFound();
            }

            return View(recipient);
        }

        // GET: Recipients/Create
        public IActionResult Create()
        {
            ViewData["BloodTypeId"] = new SelectList(_context.BloodGroups, "BloodTypeId", "BloodTypeId");
            return View();
        }

        // POST: Recipients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecipientId,Name,City,PhoneNumber,BloodComponent,BloodTypeId,RequestDate")] Recipient recipient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BloodTypeId"] = new SelectList(_context.BloodGroups, "BloodTypeId", "BloodTypeId", recipient.BloodTypeId);
            return View(recipient);
        }

        // GET: Recipients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Recipients == null)
            {
                return NotFound();
            }

            var recipient = await _context.Recipients.FindAsync(id);
            if (recipient == null)
            {
                return NotFound();
            }
            ViewData["BloodTypeId"] = new SelectList(_context.BloodGroups, "BloodTypeId", "BloodTypeId", recipient.BloodTypeId);
            return View(recipient);
        }

        // POST: Recipients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecipientId,Name,City,PhoneNumber,BloodComponent,BloodTypeId,RequestDate")] Recipient recipient)
        {
            if (id != recipient.RecipientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipientExists(recipient.RecipientId))
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
            ViewData["BloodTypeId"] = new SelectList(_context.BloodGroups, "BloodTypeId", "BloodTypeId", recipient.BloodTypeId);
            return View(recipient);
        }

        // GET: Recipients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Recipients == null)
            {
                return NotFound();
            }

            var recipient = await _context.Recipients
                .Include(r => r.BloodType)
                .FirstOrDefaultAsync(m => m.RecipientId == id);
            if (recipient == null)
            {
                return NotFound();
            }

            return View(recipient);
        }

        // POST: Recipients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Recipients == null)
            {
                return Problem("Entity set 'MushinBloodBankContext.Recipients'  is null.");
            }
            var recipient = await _context.Recipients.FindAsync(id);
            if (recipient != null)
            {
                _context.Recipients.Remove(recipient);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipientExists(int id)
        {
          return (_context.Recipients?.Any(e => e.RecipientId == id)).GetValueOrDefault();
        }
    }
}
