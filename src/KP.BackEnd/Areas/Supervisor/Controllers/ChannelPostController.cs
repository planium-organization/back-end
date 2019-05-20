using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KP.BackEnd.Areas.Shared.DTOs.ChannelPost;
using KP.BackEnd.Areas.Supervisor.DTOs.ChannelPost;
using KP.BackEnd.Data;
using KP.BackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KP.BackEnd.Areas.Supervisor.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ChannelPostController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ChannelPostController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChannelPostGetDto>> Get(Guid id)
        {
            var userId = Guid.Parse(User.Identity.Name);
            var channelPost = await _context.ChannelPosts.FirstOrDefaultAsync(p => p.Id == id && p.CreatorId == userId);
            return Ok(new ChannelPostGetDto(channelPost));
        }
        
        [HttpGet("{page}/{count}")]
        public async Task<ActionResult<IEnumerable<ChannelPostGetDto>>> GetAll(int page, int count)
        {
            var channelPosts = await _context.ChannelPosts.Skip(page * count).Take(count).ToListAsync();
            
            var channelPostDtos = channelPosts.Select(cp => new ChannelPostGetDto(cp));
            
            return Ok(channelPostDtos);
        }
        
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ChannelPostCreateDto channelPostDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = Guid.Parse(User.Identity.Name);
            var channelPost = channelPostDto.ToChannelPost(userId);
                
            await _context.ChannelPosts.AddAsync(channelPost);
            await _context.SaveChangesAsync();
                
            return CreatedAtAction(nameof(Get), new ChannelPostGetDto(channelPost), null);
        }
    }
}