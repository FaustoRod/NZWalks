using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalksApi.Models;
using NZWalksApi.Models.Dtos;
using NZWalksApi.Repositories.Interfaces;

namespace NZWalksApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _regionService;
        private readonly IMapper _mapper;

        public RegionController(IRegionService regionService, IMapper mapper)
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

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegion")]
        public async Task<IActionResult> GetRegion(Guid id)
        {
            var region = await _regionService.GetByIdAsync(id);

            if (region is null) return NotFound();

            var resgionDto = _mapper.Map<RegionDto>(region);

            return Ok(resgionDto);
        }

        [HttpPost]
        [ActionName("AddRegionAsync")]
        public async Task<IActionResult> AddRegionAsync(AddRegionRequest regionRequest)
        {
            var region = _mapper.Map<Region>(regionRequest);

            var result = await _regionService.AddAsync(region);

            return CreatedAtAction(nameof(GetRegion), new { id = result.Id }, result);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            var result = await _regionService.DeleteAsync(id);
            return result is not null ? Ok(result) : NotFound();
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync(Guid id, [FromBody] AddRegionRequest regionRequest)
        {
            var region = _mapper.Map<Region>(regionRequest);
            var result = await _regionService.UpdateAsync(id, region);
            return result is not null ? Ok(result) : NotFound();
        }
    }
}
