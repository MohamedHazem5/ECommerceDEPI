using ECommerce.Models._Enums;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models.Companies
{
    public class Company
    {
        [Key] [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string? Address { get; set; }

        public string? Industry { get; set; }

        public CompanySize Size { get; set; } // Consider an enum for company size

        public DateTime? FoundedDate { get; set; }

        public string? Website { get; set; }

        public string? Logo { get; set; }

        public int? NumberOfEmployees { get; set; }

        public string? TaxID { get; set; }

        public string? RegistrationNumber { get; set; }

        public LegalStatus LegalStatus { get; set; } // Consider an enum for legal status

        public string? CEO { get; set; }

        public string? Notes { get; set; }

    }
}
