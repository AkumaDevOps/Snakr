namespace Snakr.Models.DTOs.MasterBranch
{
    public class MasterbranchCreateDTO
    {

        public string BranchName { get; set; } = null!;

        public string Location { get; set; } = null!;

        public string City { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string? PhoneNumber { get; set; }
    }
}
