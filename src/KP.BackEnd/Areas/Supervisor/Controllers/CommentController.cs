using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KP.BackEnd.Areas.Shared.DTOs.Comment;
using KP.BackEnd.Data;
using KP.BackEnd.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KP.BackEnd.Areas.Supervisor.Controllers
{
    [Authorize]
    [Area("Supervisor")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentRepository _commentRepository;

        public CommentController(CommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet("{studentId}/{date}/{page}/{count}")]
        public async Task<ActionResult<IEnumerable<CommentGetDto>>> GetAll(Guid studentId, DateTime date, int page, int count)
        {
            var userId = Guid.Parse(User.Identity.Name);
            var comments = await _commentRepository.GetRange(userId, studentId, date, page, count);
            var commentDtos = comments.Select(c => new CommentGetDto(c));
            return Ok(commentDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommentGetDto>> Get(Guid id)
        {
            var userId = Guid.Parse(User.Identity.Name);
            var comment = await _commentRepository.Find(userId, id);
            if (comment == null)
                return NotFound("card not found");
            
            var commentDto = new CommentGetDto(comment);
            return Ok(commentDto);
        }
    }
}