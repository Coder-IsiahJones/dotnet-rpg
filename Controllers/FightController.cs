using System.Threading.Tasks;
using dotnet_rpg.Dtos.Fight;
using dotnet_rpg.Models;
using dotnet_rpg.Services.FightService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FightController : ControllerBase
    {
        private readonly IFightService _fighterService;

        public FightController(IFightService fighterService)
        {
            _fighterService = fighterService;
        }

        [HttpPost]
        [Route("Weapon")]
        public async Task<ActionResult<ServiceResponse<AttackResultDto>>> WeaponAttack(WeaponAttackDto request)
        {
            return Ok(await _fighterService.WeaponAttack(request));
        }

        [HttpPost]
        [Route("Skill")]
        public async Task<ActionResult<ServiceResponse<AttackResultDto>>> SkillAttack(SkillAttackDto request)
        {
            return Ok(await _fighterService.SkillAttack(request));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<FightResultDto>>> Fight(FightRequestDto request)
        {
            return Ok(await _fighterService.Fight(request));
        }

        [HttpGet]
        [Route("GetHighScore")]
        public async Task<ActionResult<ServiceResponse<HighscoreDto>>> GetHighscore()
        {
            return Ok(await _fighterService.GetHighscore());
        }
    }
}