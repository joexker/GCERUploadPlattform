using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Directories;
using api.Interfaces;
using api.Mappers;
using api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/dir")]
    public class DirectoryController : ControllerBase
    {
        private readonly IDirectoryRepository _dirrepo;

        public DirectoryController(IDirectoryRepository dirrepo)
        {
            _dirrepo = dirrepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var directories = await _dirrepo.GetAllAsync();

            return Ok(directories);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var directory = await _dirrepo.GetByIdAsync(id);

            if(directory == null)
            {
                return NotFound();
            }

            return Ok(directory.ToDirectoryDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DirectoryDto createDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var dirModel = createDto.ToDirectoryFromDirectoryDto();
            var createdmodel = await _dirrepo.CreateAsync(dirModel);

            if(createdmodel == null)
                return NotFound("Team could not be found");
            return Ok(dirModel);

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] DirectoryUpdateDto updateDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var dirModel = await _dirrepo.UpdateAsync(id, updateDto);

            if(dirModel == null)
            {
                return NotFound();
            }

            return Ok(dirModel.ToDirectoryDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var dirModel = await _dirrepo.DeleteAsync(id);

            if(dirModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}