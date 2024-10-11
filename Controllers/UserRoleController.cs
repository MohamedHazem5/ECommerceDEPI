using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommerce.Models;
using ECommerce.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace ECommerce.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserRoleController : Controller
    {
        private readonly StoreContext _context;
        private readonly UserManager<User> _userManager;
        public UserRoleController(StoreContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: UserRole
        public async Task<IActionResult> Index()
        {
            var StoreContext = _context.UserRoles.Include(u => u.Role).Include(u => u.User);
            return View(await StoreContext.ToListAsync());
        }

        // GET: UserRole/Edit/5
        public async Task<IActionResult> Edit(int? roleId,int userId)
        {
            if (roleId == null)
            {
                return NotFound();
            }
            if(roleId == 1)
            {
                return RedirectToAction(nameof(Index));
            }
            var userRole = await _context.UserRoles
                .Include(u => u.Role)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserId == userId);
            if (userRole == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name", userRole.RoleId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FirstName", userRole.UserId);
            return View(userRole);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int roleId, int userId)
        {
            if (roleId == 1)
            {
                return RedirectToAction(nameof(Index));
            }
            var userRole = await _context.UserRoles
                .Include(u => u.Role)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserId == userId);
            var user = await _context.Users.FindAsync(userId);
            if (userId != userRole.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _userManager.RemoveFromRoleAsync(user, userRole.Role.Name);
                    var role = await _context.Roles.FindAsync(roleId); 
                    await _userManager.AddToRoleAsync(user, role.Name);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserRoleExists(userRole.UserId))
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
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name", userRole.RoleId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FirstName", userRole.UserId);
            return View(userRole);
        }

        private bool UserRoleExists(int id)
        {
            return _context.UserRoles.Any(e => e.UserId == id);
        }
    }
}
