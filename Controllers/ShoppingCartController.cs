using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace ECommerce.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly storeContext _db;
        private  List<ShoppingCartItem> _items;
        public ShoppingCartController(storeContext context)
        {
            _db=context;
            _items=new List<ShoppingCartItem>();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddtoCart(int id)
        {
            var _product=_db.Products.Find(id);
            var _cartItems=HttpContext.Session.Get<List<ShoppingCartItem>>("Cart")??new List<ShoppingCartItem>();
            var extingproduct= _cartItems.FirstOrDefault(x => x.product.Id == id);
            if(extingproduct != null)
            {
                extingproduct.Quantitiy++;
            }
            else
            {
                _cartItems.Add(new ShoppingCartItem
                {
                    Quantitiy = 1,
                    product = _product
                }); 
            }
            HttpContext.Session.Set("Cart", _cartItems);
            return RedirectToAction("Index","Product");
        }
        public IActionResult ViewCart()
        {
            var _cartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();

            var catviewmodel = new ShoppingCartViewItem
            {
                Items = _cartItems,
                TotalPrice = _cartItems.Sum(item => item.product.Price * item.Quantitiy)
            };
            return View(catviewmodel);
        }
        public IActionResult RemoveFromCart(int id)
        {
            var _cartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();
            var extingproduct = _cartItems.FirstOrDefault(x => x.product.Id == id);
            if (extingproduct != null)
            {
                _cartItems.Remove(extingproduct);
            }
            HttpContext.Session.Set("Cart", _cartItems);

            return RedirectToAction("ViewCart");
        }
    }
}
