using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KP.BackEnd.Areas.Shared.DTOs.Card;
using KP.BackEnd.Areas.Shared.DTOs.Comment;
using KP.BackEnd.Areas.Student.DTOs.Card;
using KP.BackEnd.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KP.BackEnd.Areas.Student.Controllers
{
    [Authorize]
    [Area("Student")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CommentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{date}/{count}")]
        public async Task<ActionResult<IEnumerable<CommentGetDto>>> GetAll(DateTime date, int count)
        {
            var userId = Guid.Parse(User.Identity.Name);
            var comments = await _context.Comments
                .Where(c => c.StudentId == userId && c.CreationTime.Date == date)
                .OrderBy(c => c.CreationTime)
                .Take(count)
                .ToListAsync();

            var commentDtos = comments.Select(c => new CommentGetDto(c));
            return Ok(commentDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommentGetDto>> Get(Guid id)
        {
            var userId = Guid.Parse(User.Identity.Name);
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.StudentId == userId && c.Id == id);
            if (comment == null)
                return NotFound("card not found");
            
            var commentDto = new CommentGetDto(comment);
            return Ok(commentDto);
        }
    }
}