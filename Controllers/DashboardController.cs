using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class DashboardController : Controller
    {
        private readonly StoreContext _context;
        public DashboardController(StoreContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var dashboard = new Dashboard
            {
                TotalProducts = _context.Products.Count(),
                TotalOrders = _context.Orders.Count(),
            };
            return View(dashboard);
        }
    }
}
