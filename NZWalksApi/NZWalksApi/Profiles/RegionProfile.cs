using AutoMapper;
using NZWalksApi.Dtos;
using NZWalksApi.Models;

namespace NZWalksApi.Profiles
{
    public class RegionProfile:Profile
    {
        public RegionProfile()
        {
            CreateMap<Region, RegionDto>();
        }
    }
}
