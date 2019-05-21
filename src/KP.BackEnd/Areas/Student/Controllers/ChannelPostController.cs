using System;
using System.Linq;
using System.Threading.Tasks;
using KP.BackEnd.Areas.Shared.DTOs.ChannelPost;
using KP.BackEnd.Areas.Supervisor.DTOs.ChannelPost;
using KP.BackEnd.Data;
using KP.BackEnd.Migrations;
using KP.BackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KP.BackEnd.Areas.Student.Controllers
{
    [Authorize]
    [Area("Student")]
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
            var channelPost = await _context.ChannelPosts.FirstOrDefaultAsync(c => c.Id == id); // TODO filter by classId
            var channelPostGetDto = new ChannelPostGetDto(channelPost);
            return Ok(channelPostGetDto);
        }

        [HttpGet("{page}/{count}")]
        public async Task<ActionResult<ChannelPost>> GetAll(int page, int count)
        {
            var channelPosts = await _context.ChannelPosts
                .Skip(page * count)
                .Take(count)
                .ToListAsync();

            var channelPostGetDtos = channelPosts.Select(p => new ChannelPostGetDto(p)).ToList();
            
            return Ok(channelPostGetDtos);
        }
    }
}