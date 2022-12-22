using AutoMapper;
using NZWalksApi.Models;
using NZWalksApi.Models.Dtos;

namespace NZWalksApi.Profiles
{
    public class WalkProfile:Profile
    {
        public WalkProfile()
        {
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<AddWalkRequest, Walk>();
        }
    }
}
