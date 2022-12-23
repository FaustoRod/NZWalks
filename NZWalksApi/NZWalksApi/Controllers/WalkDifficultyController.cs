using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalksApi.Services.Interfaces;

namespace NZWalksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkDifficultyController : ControllerBase
    {
        private readonly IWalkDifficultyService walkDifficultyService;

        public WalkDifficultyController(IWalkDifficultyService walkDifficultyService)
        {
            this.walkDifficultyService = walkDifficultyService;
        }

        [HttpGet(Name = "GetWalkDifficulties")]
        public async Task<IActionResult> GetAllWalkDifficulties()
        {
            var WalkDifficulties = await walkDifficultyService.GetAllAsync();
            return Ok(WalkDifficulties);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkDifficulty")]
        public async Task<IActionResult> GetWalkDifficulty(Guid id)
        {
            var WalkDifficulty = await walkDifficultyService.GetByIdAsync(id);
            return Ok(WalkDifficulty);
        }

    }
}
