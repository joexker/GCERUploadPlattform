using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using api.Mappers;
using api.Dtos.Team;

namespace api.Controllers
{
    [Route("api/team")]
    [ApiController]
    public class TeamController : ControllerBase
    {

        private readonly ITeamRepository _teamrepo;

        public TeamController(ITeamRepository teamRepository)
        {
            _teamrepo = teamRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var teams = await _teamrepo.GetAllAsync();

            return Ok(teams);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var team = await _teamrepo.GetByIdAsync(id);

            if(team == null)
            {
                return NotFound();
            }

            return Ok(team.ToTeamDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TeamCreateDto createDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var teamModel = createDto.ToTeamFromCreateDto();
            await _teamrepo.CreateAsync(teamModel);
            return Ok(teamModel);

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TeamUpdateDto updateDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var teamModel = await _teamrepo.UpdateAsync(id, updateDto);

            if(teamModel == null)
            {
                return NotFound();
            }

            return Ok(teamModel.ToTeamDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var teamModel = await _teamrepo.DeleteAsync(id);

            if(teamModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}