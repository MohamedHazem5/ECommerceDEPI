using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommerce.Models;
using ECommerce.Models.Companies;
using ECommerce.Models._Enums;
using ECommerce.Utility;
using ECommerce.Models.ViewModels;

namespace ECommerce.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly StoreContext _context;

        public CompaniesController(StoreContext context)
        {
            _context = context;
        }

        // GET: Companies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Companies.ToListAsync());
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            var viewModel = new CompanyViewModel
            {
                CompanySizes = Enum.GetValues(typeof(CompanySize)).Cast<CompanySize>().Select(cs => new SelectListItem { Value = cs.ToString(), Text = cs.GetEnumDisplayName().ToString() }),
                LegalStatuses = Enum.GetValues(typeof(LegalStatus)).Cast<LegalStatus>().Select(cs => new SelectListItem { Value = cs.ToString(), Text = cs.GetEnumDisplayName().ToString() })
            };

            return View(viewModel);
        }

        // POST: Companies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompanyViewModel companyViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companyViewModel.Company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            companyViewModel.CompanySizes = Enum.GetValues(typeof(CompanySize)).Cast<CompanySize>().Select(cs => new SelectListItem { Value = cs.ToString(), Text = cs.GetEnumDisplayName().ToString() });
            companyViewModel.LegalStatuses = Enum.GetValues(typeof(LegalStatus)).Cast<LegalStatus>().Select(cs => new SelectListItem { Value = cs.ToString(), Text = cs.GetEnumDescription().ToString() });
            
            return View(companyViewModel);
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            var viewModel = new CompanyViewModel
            {
                Company = company,
                CompanySizes = Enum.GetValues(typeof(CompanySize)).Cast<CompanySize>().Select(cs => new SelectListItem { Value = cs.ToString(), Text = cs.GetEnumDisplayName().ToString() }),
                LegalStatuses = Enum.GetValues(typeof(LegalStatus)).Cast<LegalStatus>().Select(cs => new SelectListItem { Value = cs.ToString(), Text = cs.GetEnumDisplayName().ToString() })
            };
            return View(viewModel);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,Industry,Size,FoundedDate,Website,Logo,NumberOfEmployees,TaxID,RegistrationNumber,LegalStatus,CEO,Notes")] Company company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.Id))
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
            return View(company);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company != null)
            {
                _context.Companies.Remove(company);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }
    }
}
