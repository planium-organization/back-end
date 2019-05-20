using System;
using System.Linq;
using System.Threading.Tasks;
using KP.BackEnd.Areas.Shared.DTOs.ChannelPost;
using KP.BackEnd.Areas.Student.DTOs;
using KP.BackEnd.Areas.Supervisor.DTOs.ChannelPost;
using KP.BackEnd.Data;
using KP.BackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KP.BackEnd.Areas.Student.Controllers
{
//    [Authorize]
    [Area("Student")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PostController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpGet("{id}")]

        public async Task<ActionResult<ChannelPostGetDto>> Get(Guid id)
        {
            var channelPost = await _context.ChannelPosts.FirstOrDefaultAsync(c => c.Id == id); // TODO filter by classId
            var channelPostGetDto = new ChannelPostGetDto(channelPost);
            return Ok(channelPostGetDto);
        }

        [HttpGet("{page}/{count}")]
        public async Task<ActionResult<ChannelPost>> GetAll(int page, int count)
        {
            var posts = await _context.ChannelPosts.Skip(page * count).Take(count).ToListAsync();
            
            return Ok(posts);
        }
        
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ChannelPostCreateDto channelPostostDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = Guid.Parse(User.Identity.Name);
            var channelPost = channelPostostDto.ToChannelPost(userId);
                
            await _context.ChannelPosts.AddAsync(channelPost);
            await _context.SaveChangesAsync();
                
            return CreatedAtAction(nameof(Get), new ChannelPostGetDto(channelPost));
        }
    }
}