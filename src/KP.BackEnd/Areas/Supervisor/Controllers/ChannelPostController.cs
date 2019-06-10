using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KP.BackEnd.Core;
using KP.BackEnd.Core.DTOs.Shared.ChannelPost;
using KP.BackEnd.Core.DTOs.Supervisor.ChannelPost;
using KP.BackEnd.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KP.BackEnd.Areas.Supervisor.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ChannelPostController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ChannelPostController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChannelPostGetDto>> Get(Guid id)
        {
            var userId = Guid.Parse(User.Identity.Name);
            var channelPost = await _unitOfWork.ChannelPosts.Find(userId, id);
            return Ok(new ChannelPostGetDto(channelPost));
        }
        
        [HttpGet("{page}/{count}")]
        public async Task<ActionResult<IEnumerable<ChannelPostGetDto>>> GetAll(Guid classId, int page, int count)
        {
            var channelPosts = await _unitOfWork.ChannelPosts.GetRange(classId,page, count);
            var channelPostDtos = channelPosts.Select(cp => new ChannelPostGetDto(cp));
            return Ok(channelPostDtos);
        }
        
        [HttpPost]
        public async Task<ActionResult<ChannelPostGetDto>> Create([FromBody] ChannelPostCreateDto channelPostDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = Guid.Parse(User.Identity.Name);
            var channelPost = channelPostDto.ToChannelPost(userId);

            await _unitOfWork.ChannelPosts.Add(channelPost);
            
            return CreatedAtAction(nameof(Get), new ChannelPostGetDto(channelPost), null);
        }
    }
}