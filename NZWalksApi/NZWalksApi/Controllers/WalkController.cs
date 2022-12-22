using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalksApi.Models;
using NZWalksApi.Models.Dtos;
using NZWalksApi.Services.Interfaces;

namespace NZWalksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkController : ControllerBase
    {
        private readonly IWalkService walkService;
        private readonly IMapper Mapper;

        public WalkController(IWalkService walkService, IMapper mapper)
        {
            this.walkService = walkService;
            Mapper = mapper;
        }

        [HttpGet]
        [ActionName("GetAllWalksAsync")]
        public async Task<IActionResult> GetAllWalksAsync()
        {
            var result = await walkService.GetAllAsync();
            var walks = Mapper.Map<IList<WalkDto>>(result);
            return Ok(walks);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetWalkAsync(Guid id)
        {
            var result = await walkService.GetByIdAsync(id);
            if (result is null) return NotFound();
            var walks = Mapper.Map<WalkDto>(result);
            return Ok(walks);
        }

        [HttpPost]
        public async Task<IActionResult> AddWalkAsync(AddWalkRequest walk)
        {
            var walkAdd = Mapper.Map<Walk>(walk);
            var result = await walkService.AddAsync(walkAdd);
            return CreatedAtAction(nameof(GetAllWalksAsync), new { id = result.Id }, result);
        }

    }
}
