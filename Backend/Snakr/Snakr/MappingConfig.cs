using AutoMapper;
using Snakr.Models;
using Snakr.Models.DTOs.MasterBranch;
using Snakr.Models.DTOs.MasterUser;

namespace Snakr
{
    public class MappingConfig: Profile
    {
        public MappingConfig() 
        {
            CreateMap<Masterbranch,MasterbranchDTO>();
            CreateMap<Masterbranch, MasterbranchCreateDTO>();
            CreateMap<MasterbranchDTO, Masterbranch>();

            CreateMap<Masteruser, MasterUsersDTO>();
            CreateMap<Masteruser, MasterUsersCreateDTO>();

        }

    }
}
