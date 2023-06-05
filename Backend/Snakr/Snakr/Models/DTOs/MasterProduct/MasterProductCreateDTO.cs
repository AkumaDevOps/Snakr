namespace Snakr.Models.DTOs.MasterProduct
{
    public class MasterProductCreateDTO
    {
        

        public string Name { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string Brand { get; set; } = null!;

        public string? Description { get; set; }
    }
}
