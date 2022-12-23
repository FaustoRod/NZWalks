using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZWalksApi.Models;
using NZWalksApi.Models.Dtos;
using NZWalksApi.Repositories.Interfaces;

namespace NZWalksApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
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
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> AddRegionAsync(AddRegionRequest regionRequest)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            //if (!ValidateAddRegionAsync(regionRequest)) return BadRequest(ModelState);
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

        #region Private Methods
        private bool ValidateAddRegionAsync(AddRegionRequest regionRequest)
        {
            if(regionRequest is null)
            {
                ModelState.AddModelError(nameof(regionRequest), $"{nameof(regionRequest)} cannot be null");
                return false;
            }

            if (string.IsNullOrWhiteSpace(regionRequest.Code))
            {
                ModelState.AddModelError(nameof(regionRequest.Code), $"{nameof(regionRequest.Code)} cannot be null");
            }

            if (string.IsNullOrWhiteSpace(regionRequest.Name))
            {
                ModelState.AddModelError(nameof(regionRequest.Name), $"{nameof(regionRequest.Name)} cannot be null");
            }

            if(regionRequest.Long < 0)
            {
                ModelState.AddModelError(nameof(regionRequest.Long), $"{nameof(regionRequest.Long)} must be > 0");
            }

            if(regionRequest.Lat < 0)
            {
                ModelState.AddModelError(nameof(regionRequest.Lat), $"{nameof(regionRequest.Lat)} must be > 0");
            }

            if(regionRequest.Population < 0)
            {
                ModelState.AddModelError(nameof(regionRequest.Population), $"{nameof(regionRequest.Population)} must be > 0");
            }

            return ModelState.ErrorCount.Equals(0);
        }
        #endregion
    }
}
