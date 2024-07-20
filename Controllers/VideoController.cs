using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using api.Dtos.Videos;
using api.Interfaces;
using api.Mappers;
using api.Models;
using api.Repository;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace api.Controllers
{
    [Route("api/video")]
    public class VideoController : ControllerBase
    {
        
        private readonly IVideoRepository _videorepo;
        private readonly ITeamRepository _teamrepo;

        private readonly string _uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");

        public VideoController(IVideoRepository videorepo, ITeamRepository teamrepo)
        {
            _videorepo = videorepo;
            _teamrepo = teamrepo;
            if (!Directory.Exists(_uploadPath))
            {
                Directory.CreateDirectory(_uploadPath);
            }
        }

        
        private async Task<Video?> UploadBase(int id, String title, IFormFile file, bool uploadInTeam)
        {     
            var path = Path.Combine(_uploadPath, file.FileName);

            var video = file.ToVideoInTeamFromFile(id, title);
            if(!uploadInTeam)
                video = file.ToVideoInDirectoryFromFile(id, title);
            
    	    var videoModel = await _videorepo.UploadAsync(video);

            if(videoModel == null)
            {
                return null;
            }


            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return videoModel;
        }
        
        [HttpPost("team/{id:int}")]
        public async Task<IActionResult> UploadTeam([FromRoute] int id, String title, IFormFile file)
        {
            bool ok = false;
            foreach(String type in GetMimeTypes().Keys)
            {
                if(file.FileName.EndsWith(type))
                {
                    ok = true;
                    break;
                }
            }

            if(!ok)
            {
                return BadRequest("Filetype not supported");
            }
            

            if (file == null || file.Length == 0)
                return BadRequest("File not selected");

            var videoModel = await UploadBase(id, title, file, true);

            if(videoModel == null)
            {
                return NotFound("Team not found");
            }

            return Ok(videoModel);
        }

        [HttpPost("directory/{id:int}")]
        public async Task<IActionResult> UploadDirectory([FromRoute] int id, String title, IFormFile file)
        {bool ok = false;
            foreach(String type in GetMimeTypes().Keys)
            {
                if(file.FileName.EndsWith(type))
                {
                    ok = true;
                    break;
                }
            }

            if(!ok)
            {
                return BadRequest("Filetype not supported");
            }
            

            if (file == null || file.Length == 0)
                return BadRequest("File not selected");

            var videoModel = await UploadBase(id, title, file, false);

            if(videoModel == null)
            {
                return NotFound("Directory not found");
            }

            return Ok(videoModel);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllFromTeam([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var videos = await _videorepo.GetAllFromTeamAsync(id);

            return Ok(videos);
        }

        [HttpGet("video/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);


            var videoModel = await _videorepo.GetByIdAsync(id);

            if(videoModel == null)
            {
                return NotFound();
            }

            var path = Path.Combine(_uploadPath, videoModel.videoPath);

            if (videoModel == null || !System.IO.File.Exists(path))
                return NotFound();
            

            var memory = new MemoryStream();

            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(memory, GetContentType(path), videoModel.Title + "." + videoModel.videoPath.Split(".").Last());
        }

        [HttpGet("details/{id:int}")]
        public async Task<IActionResult> GetbyIdDetails([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var video = await _videorepo.GetByIdAsync(id);   
            
            if(video == null)
            {
                return NotFound();
            }

            return Ok(video.ToDownloadDto());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var videos = await _videorepo.GetAllAsync();

            return Ok(videos);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] VideoUpdateDto updateDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var videoModel = await _videorepo.UpdateAsync(id, updateDto);

            if(videoModel == null)
            {
                return NotFound();
            }

            return Ok(videoModel);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var videoModel = await _videorepo.DeleteAsync(id);

            if(videoModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                // Common image formats
                { ".png", "image/png" },
                { ".jpg", "image/jpeg" },
                { ".jpeg", "image/jpeg" },
                { ".gif", "image/gif" },
                
                // Common video formats
                { ".mp4", "video/mp4" },
                { ".mov", "video/quicktime" },
                { ".wmv", "video/x-ms-wmv" },
                { ".flv", "video/x-flv" },
                { ".avi", "video/x-msvideo" },
                { ".mkv", "video/x-matroska" },
                { ".webm", "video/webm" },
                { ".3gp", "video/3gpp" },
                { ".3g2", "video/3gpp2" },
                
                // Common audio formats
                { ".mp3", "audio/mpeg" },
                { ".wav", "audio/wav" },
                { ".ogg", "audio/ogg" },
                { ".m4a", "audio/mp4" },
                { ".aac", "audio/aac" },
            };
        }
    }
}