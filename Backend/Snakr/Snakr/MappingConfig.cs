using AutoMapper;
using Snakr.Models;
using Snakr.Models.DTOs.MasterBranch;
using Snakr.Models.DTOs.MasterGroup;
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
            CreateMap<MasterbranchCreateDTO, Masterbranch>();

            CreateMap<Masteruser, MasterUsersDTO>();
            CreateMap<Masteruser, MasterUsersCreateDTO>();
            CreateMap<MasterUsersDTO, Masteruser>();
            CreateMap<MasterUsersCreateDTO, Masteruser>();

            CreateMap<Mastergroup, MasterGroupDTO>();
            CreateMap<Mastergroup, MasterGroupCreateDTO>();
            CreateMap<MasterGroupDTO, Masterbranch>();
            CreateMap<MasterGroupCreateDTO, Masterbranch>();

            CreateMap<Favouriteproduct, FavouriteProductDTO>();
            CreateMap<Favouriteproduct, FavouriteProductCreateDTO>();
            CreateMap<FavouriteProductDTO, Favouriteproduct>();
            CreateMap<FavouriteProductCreateDTO, Favouriteproduct>();



        }

    }
}
