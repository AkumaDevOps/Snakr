namespace Snakr.Models.DTOs.MasterProvider
{
    public class MasterProviderCreateDTO
    { 
        public string CompanyNameS { get; set; } = null!;

        public string? CompanyNameL { get; set; }

        public string? StreetAddress { get; set; }

        public string City { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string? PostalCode { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }
    }
}
