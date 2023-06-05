namespace Snakr.Models.DTOs.MasterVendingMachine
{
    public class MasterVendingMachineCreateDTO
    {
        public string MachineName { get; set; } = null!;

        public string? Model { get; set; }

        public string Brand { get; set; } = null!;

        public int Capacity { get; set; }

    }
}
