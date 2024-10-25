using ECommerce.Models.Shipping;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerce.Models.ViewModels
{
    public class CompanyShippingViewModel
    {
        public CompanyShipping CompanyShipping { get; set; }
        public IEnumerable<SelectListItem> Companies { get; set; }
    }
}
