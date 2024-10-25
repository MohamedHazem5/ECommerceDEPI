using ECommerce.Models.Companies;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerce.Models.ViewModels
{
    public class CompanyViewModel
    {
        public Company Company { get; set; }
        public IEnumerable<SelectListItem> CompanySizes { get; set; }
        public IEnumerable<SelectListItem> LegalStatuses { get; set; }
    }
}
