using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KP.BackEnd.Areas.Shared.DTOs.Comment;
using KP.BackEnd.Areas.Supervisor.DTOs.Comment;
using KP.BackEnd.Data;
using KP.BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KP.BackEnd.Areas.Supervisor.Controllers
{
//    [Authorize]
    [Area("Supervisor")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        
        public CommentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost()]
        public async Task<ActionResult> Create([FromBody] CommentCreateDto commentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = Guid.Parse(User.Identity.Name);
            var comment = commentDto.ToComment(userId);
            
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
                
            return Ok();
        }
        
        [HttpGet(("{date}/{page}/{count}"))]
        public async Task<ActionResult<IEnumerable<CommentGetDto>>> GetAll(DateTime date,int page, int count)
        {
            var comments = await _context.Comments.Where(c=>c.CreationTime.Date== date.Date).Skip(page * count).Take(count).ToListAsync();
            var commentDtos= comments.Select(c => new CommentGetDto(c)).ToList();
            return Ok(commentDtos);
        }
    }
}