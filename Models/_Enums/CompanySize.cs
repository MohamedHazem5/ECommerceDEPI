using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models._Enums
{
    public enum CompanySize
    {
        [Display(Name = "Small Business")] 
        Small,
        [Display(Name = "Medium-Sized Business")]
        Medium,
        [Display(Name = "Large Corporation")]
        Large,
        [Display(Name = "Enterprise")]
        Enterprise
    }
}
