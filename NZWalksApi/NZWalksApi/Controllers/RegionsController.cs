using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalksApi.Dtos;
using NZWalksApi.Repositories.Interfaces;

namespace NZWalksApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionService _regionService;
        private readonly IMapper _mapper;

        public RegionsController(IRegionService regionService, IMapper mapper)
        {
            _regionService = regionService;
            _mapper = mapper;
        }

        public IMapper Mapper { get; }

        [HttpGet(Name = "GetRegions")]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await _regionService.GetAllAsync();
            var regionsDto = _mapper.Map<List<RegionDto>>(regions);
            return Ok(regionsDto);
        }
    }
}
