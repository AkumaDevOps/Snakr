namespace Snakr.Models.DTOs.MasterVendingMachine
{
    public class MasterVendingMachineDTO
    {
        public int Id { get; set; }

        public string MachineName { get; set; } = null!;

        public string? Model { get; set; }

        public string Brand { get; set; } = null!;

        public int Capacity { get; set; }

    }
}
