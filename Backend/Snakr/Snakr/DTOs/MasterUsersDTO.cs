﻿namespace Snakr.DTOs
{
    public class MasterUsersDTO
    {
        public int Id { get; set; }

        public int IdMasterBranches { get; set; }

        public string UserName { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
