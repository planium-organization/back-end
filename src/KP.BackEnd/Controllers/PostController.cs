using System;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using KP.BackEnd.Data;
using KP.BackEnd.DTOs;
using KP.BackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KP.BackEnd.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PostController(ApplicationDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet("{page}/{count}")]
        public async Task<ActionResult<Post>> GetAll(int page, int count)
        {
            var posts = await _context.Posts.Skip(page * count).Take(count).ToListAsync();
            
            return Ok(posts);
        }
        
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PostDto postDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var post= new Post()
            {
                ImageUrl = postDto.ImageUrl,
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