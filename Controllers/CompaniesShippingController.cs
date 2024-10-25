using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommerce.Models;
using ECommerce.Models.Shipping;
using ECommerce.Models.Companies;

namespace ECommerce.Controllers
{
    public class CompaniesShippingController : Controller
    {
        private readonly StoreContext _context;

        public CompaniesShippingController(StoreContext context)
        {
            _context = context;
        }

        // GET: CompaniesShipping
        public async Task<IActionResult> Index()
        {
            var storeContext = _context.CompaniesShipping.Include(c => c.Company);
            return View(await storeContext.ToListAsync());
        }

        // GET: CompaniesShipping/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var CompaniesShipping = await _context.CompaniesShipping
                .Include(c => c.Company)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (CompaniesShipping == null)
            {
                return NotFound();
            }

            return View(CompaniesShipping);
        }

        // GET: CompaniesShipping/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Companies, dataValueField: nameof(Company.Id), dataTextField: nameof(Company.Name));
            return View();
        }

        // POST: CompaniesShipping/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyId,ShippingName,ShippingAddress,City,State,Country,PostalCode,PhoneNumber,Email,IsActive,Notes")] CompanyShipping CompaniesShipping)
        {
            if (ModelState.IsValid)
            {
                _context.Add(CompaniesShipping);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", nameof(Company.Name), CompaniesShipping.CompanyId);
            return View(CompaniesShipping);
        }

        // GET: CompaniesShipping/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var CompaniesShipping = await _context.CompaniesShipping.FindAsync(id);
            if (CompaniesShipping == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, dataValueField: nameof(Company.Id), dataTextField: nameof(Company.Name));
            return View(CompaniesShipping);
        }

        // POST: CompaniesShipping/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyId,ShippingName,ShippingAddress,City,State,Country,PostalCode,PhoneNumber,Email,IsActive,Notes")] CompanyShipping CompaniesShipping)
        {
            if (id != CompaniesShipping.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(CompaniesShipping);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompaniesShippingExists(CompaniesShipping.Id))
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
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", nameof(Company.Name), CompaniesShipping.CompanyId);
            return View(CompaniesShipping);
        }

        // GET: CompaniesShipping/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var CompaniesShipping = await _context.CompaniesShipping
                .Include(c => c.Company)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (CompaniesShipping == null)
            {
                return NotFound();
            }

            return View(CompaniesShipping);
        }

        // POST: CompaniesShipping/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var CompaniesShipping = await _context.CompaniesShipping.FindAsync(id);
            if (CompaniesShipping != null)
            {
                _context.CompaniesShipping.Remove(CompaniesShipping);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompaniesShippingExists(int id)
        {
            return _context.CompaniesShipping.Any(e => e.Id == id);
        }
    }
}
