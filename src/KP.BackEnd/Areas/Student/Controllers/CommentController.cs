using System.Linq;
using System.Threading.Tasks;
using KP.BackEnd.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KP.BackEnd.Areas.Student.Controllers
{
//    [Authorize]
    [Area("Student")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        
        public CommentController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpGet("{page}/{count}")]
        public async Task<ActionResult<Comment>> GetAll(int page, int count)
        {
            var posts = await _context.Posts.Skip(page * count).Take(count).ToListAsync();
            
            return Ok(posts);
        }
    }
}