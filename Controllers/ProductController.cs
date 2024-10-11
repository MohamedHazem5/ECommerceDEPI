using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.DataProtection;
using ECommerce.Models.Products;
using ECommerce.Models.Vendors;
using ECommerce.Models;
using Microsoft.AspNetCore.Authorization;

namespace ECommerce.Controllers
{
    public class ProductsController : Controller
    {
        private readonly StoreContext _context;

        public ProductsController(StoreContext context,IDataProtectionProvider provider)
        {
            _context = context;
            
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var storeDbContext = _context.Products.Include(p => p.Category).Include(p => p.Vendor);
            return View(await storeDbContext.ToListAsync());
        }
        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Vendor)
                .Include(p => p.ProductImages) // Include ProductImages to access them
                .FirstOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        [Authorize(Roles = "Admin,Vendor")]
        // GET: Products/Create
        public IActionResult Create()
        {
            // Populate the dropdown list with vendors
            ViewBag.Vendors = new SelectList(_context.Vendor.ToList(), "Id", "Name"); // Id is used for saving, Name is shown to the user
                                                                                       // Populate the dropdown list with categories
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name"); // Id is used for saving, Name is shown to the user

            return View();
        }
        [Authorize(Roles = "Admin,Vendor")]

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,QuantityInStock,IsActive,CategoryId,VendorId")] Product product, List<IFormFile> images)
        {

            // Save product details
            _context.Add(product);
            await _context.SaveChangesAsync(); // Save product to generate its Id

            // Check if any images were uploaded
            if (images != null && images.Count > 0)
            {
                foreach (var image in images)
                {
                    if (image.Length > 0)
                    {
                        // Convert image to byte array
                        using (var ms = new MemoryStream())
                        {
                            await image.CopyToAsync(ms);
                            var imageData = ms.ToArray();

                            // Create new ProductImage
                            var productImage = new ProductImage
                            {
                                ProductID = product.Id, // Reference the created product
                                ImageData = imageData
                            };

                            // Add product image to the database
                            _context.ProductImages.Add(productImage);
                        }
                    }
                }
                await _context.SaveChangesAsync(); // Save images
            }

            return RedirectToAction(nameof(Index));


            ViewBag.Vendors = new SelectList(_context.Vendor.ToList(), "Id", "Name");
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name");

            return View(product);
        }
        [Authorize(Roles = "Admin,Vendor")]

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.Products
                .Include(p => p.ProductImages) // Include ProductImages to access them
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            // Populate vendors and categories for the dropdown lists
            ViewBag.Vendors = new SelectList(_context.Vendor, "Id", "Name", product.VendorId);
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);

            return View(product);
        }
        [Authorize(Roles = "Admin,Vendor")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,QuantityInStock,IsActive,VendorId,CategoryId")] Product updatedProduct, IList<IFormFile> ImageUploads)
        {
            if (id != updatedProduct.Id)
            {
                return NotFound();
            }

            var existingProduct = await _context.Products
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.Id == id);

            // Update fields
            existingProduct.Name = updatedProduct.Name;
            existingProduct.Description = updatedProduct.Description;
            existingProduct.Price = updatedProduct.Price;
            existingProduct.QuantityInStock = updatedProduct.QuantityInStock;
            existingProduct.IsActive = updatedProduct.IsActive;
            existingProduct.CategoryId = updatedProduct.CategoryId;

            // Handle image uploads

            foreach (var imageUpload in ImageUploads)
            {

                using (var memoryStream = new MemoryStream())
                {
                    await imageUpload.CopyToAsync(memoryStream);
                    var newImage = new ProductImage
                    {
                        ProductID = existingProduct.Id,
                        ImageData = memoryStream.ToArray()
                    };
                    existingProduct.ProductImages.Add(newImage); // Add new image to the collection
                }

            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


            // If ModelState is invalid, repopulate ViewBag
            ViewBag.Vendors = new SelectList(_context.Vendor, "Id", "Name", updatedProduct.VendorId);
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", updatedProduct.CategoryId);
            return View(updatedProduct);
        }
    
        [Authorize(Roles = "Admin,Vendor")]

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Vendor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
