using AutoMapper;
using NZWalksApi.Models;
using NZWalksApi.Models.Dtos;

namespace NZWalksApi.Profiles
{
    public class RegionProfile:Profile
    {
        public RegionProfile()
        {
            CreateMap<Region, RegionDto>();
            CreateMap<AddRegionRequest, Region>();
        }
    }
}
