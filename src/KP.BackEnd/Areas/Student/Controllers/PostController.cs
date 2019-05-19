using System;
using System.Linq;
using System.Threading.Tasks;
using KP.BackEnd.Areas.Student.DTOs;
using KP.BackEnd.Areas.Student.DTOs.ChannelPost;
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

        [HttpGet("{page}/{count}")]
        public async Task<ActionResult<ChannelPost>> GetAll(int page, int count)
        {
            var posts = await _context.Posts.Skip(page * count).Take(count).ToListAsync();
            
            return Ok(posts);
        }
        
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PostDto postDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var post= new ChannelPost()
            {
                Image = postDto.ImageUrl,
                Text = postDto.Text,
                CreationTime = DateTime.Now,
               Creator = _context.Supervisors.First() //TODO
            };
                
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
                
            return Ok();
        }
    }
}