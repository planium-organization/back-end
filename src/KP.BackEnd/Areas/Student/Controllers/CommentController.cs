using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KP.BackEnd.Core;
using KP.BackEnd.Core.DTOs.Shared.Comment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KP.BackEnd.Areas.Student.Controllers
{
    [Authorize]
    [Area("Student")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public CommentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{studentId}/{date}/{page}/{count}")]
        public async Task<ActionResult<IEnumerable<CommentGetDto>>> GetAll(Guid studentId, DateTime date, int page, int count)
        {
            var userId = Guid.Parse(User.Identity.Name);

            var comments = await _unitOfWork.Comments.GetRange(userId, studentId, date, page, count);

            var commentDtos = comments.Select(c => new CommentGetDto(c));
            return Ok(commentDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommentGetDto>> Get(Guid id)
        {
            var userId = Guid.Parse(User.Identity.Name);
            var comment = await _unitOfWork.Comments.Find(userId, id);
            if (comment == null)
                return NotFound("card not found");
            
            var commentDto = new CommentGetDto(comment);
            return Ok(commentDto);
        }
    }
}