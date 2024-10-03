using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommerce.Models;
using ECommerce.Models.Carts;

namespace ECommerce.Controllers
{
    public class CartItemController : Controller
    {
        private readonly storeContext _context;

        public CartItemController(storeContext context)
        {
            _context = context;
        }

        // GET: CartItem
        public async Task<IActionResult> Index()
        {
            var storeContext = _context.CartItems.Include(c => c.Product).Include(c => c.customer);
            return View(await storeContext.ToListAsync());
        }

        // GET: CartItem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartItem = await _context.CartItems
                .Include(c => c.Product)
                .Include(c => c.customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cartItem == null)
            {
                return NotFound();
            }

            return View(cartItem);
        }

        // GET: CartItem/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Description");
            ViewData["customerid"] = new SelectList(_context.Customers, "Id", "Id");
            return View();
        }

        // POST: CartItem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quantity,ProductId,customerid")] CartItem cartItem)
        {
            if (ModelState.IsValid)
            {
                if(_context.Find<CartItem>(cartItem.ProductId)!=null)
                {
                    _context.Add(cartItem);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    cartItem.Quantity++;
                    _context.Update(cartItem);
                }
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Description", cartItem.ProductId);
            ViewData["customerid"] = new SelectList(_context.Customers, "Id", "Id", cartItem.customerid);
            return View(cartItem);
        }

        // GET: CartItem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Description", cartItem.ProductId);
            ViewData["customerid"] = new SelectList(_context.Customers, "Id", "Email", cartItem.customerid);
            return View(cartItem);
        }

        // POST: CartItem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quantity,ProductId,customerid")] CartItem cartItem)
        {
            if (id != cartItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartItemExists(cartItem.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Description", cartItem.ProductId);
            ViewData["customerid"] = new SelectList(_context.Customers, "Id", "Email", cartItem.customerid);
            return View(cartItem);
        }

        // GET: CartItem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartItem = await _context.CartItems
                .Include(c => c.Product)
                .Include(c => c.customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cartItem == null)
            {
                return NotFound();
            }

            return View(cartItem);
        }

        // POST: CartItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartItemExists(int id)
        {
            return _context.CartItems.Any(e => e.Id == id);
        }
    }
}
