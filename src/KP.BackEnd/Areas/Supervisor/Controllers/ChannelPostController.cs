using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KP.BackEnd.Areas.Shared.DTOs.ChannelPost;
using KP.BackEnd.Areas.Supervisor.DTOs.ChannelPost;
using KP.BackEnd.Data;
using KP.BackEnd.Repositories;
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
        private readonly ChannelPostRepository _channelPostRepository;
        public ChannelPostController(ChannelPostRepository channelPostRepository)
        {
            _channelPostRepository = channelPostRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChannelPostGetDto>> Get(Guid id)
        {
            var userId = Guid.Parse(User.Identity.Name);
            var channelPost = await _channelPostRepository.Find(userId, id);
            return Ok(new ChannelPostGetDto(channelPost));
        }
        
        [HttpGet("{page}/{count}")]
        public async Task<ActionResult<IEnumerable<ChannelPostGetDto>>> GetAll(int page, int count)
        {
            var channelPosts = await _channelPostRepository.GetRange(page, count);
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

            await _channelPostRepository.Add(channelPost);
            
            return CreatedAtAction(nameof(Get), new ChannelPostGetDto(channelPost), null);
        }
    }
}