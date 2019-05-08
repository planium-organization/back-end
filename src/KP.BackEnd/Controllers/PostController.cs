using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using KP.BackEnd.Data;
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
    }
}