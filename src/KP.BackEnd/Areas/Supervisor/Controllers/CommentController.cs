using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KP.BackEnd.Core;
using KP.BackEnd.Core.DTOs.Shared.Comment;
using KP.BackEnd.Core.DTOs.Supervisor.Comment;
using KP.BackEnd.Core.Models;
using KP.BackEnd.Persistence.EntityConfigurations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KP.BackEnd.Areas.Supervisor.Controllers
{
    [Authorize(Roles = "Supervisor")]
    [Route("api/supervisor/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
         
        public CommentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{studentId}/{date}/{page}/{count}")]
        public async Task<ActionResult<IEnumerable<CommentGetDto>>> GetAll(Guid studentId, DateTime date, int page, int count)
        {
            var userId = Guid.Parse(User.Identity.Name);
            var comments = await _unitOfWork.Comments.GetRange(userId ,studentId, date, page, count);

            var commentDtos = comments.Select(c => _mapper.Map<CommentGetDto>(c));
            
            return Ok(commentDtos);
        }

        [HttpPost]
        public async Task<ActionResult<CommentGetDto>> Create([FromBody]CommentPostDto commentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = Guid.Parse(User.Identity.Name);
            
            var comment = _mapper.Map<Comment>(commentDto);
            comment.CreationTime = DateTime.Now;
            comment.SupervisorId = userId;

            await _unitOfWork.Comments.Add(comment);
            await _unitOfWork.Complete();

            var commentGetDto = _mapper.Map<CommentGetDto>(comment);
            
            return Ok(commentGetDto);
        }
//        [HttpGet("{id}")]
//        public async Task<ActionResult<CommentGetDto>> Get(Guid id)
//        {
//            var userId = ApplicationUserConfiguration.SupervisorIdTmp;
//            var comment = await _unitOfWork.Comments.Find(userId, id);
//            if (comment == null)
//                return NotFound("card not found");
//            
//            var commentDto = _mapper.Map<CommentGetDto>(comment); // TODO
//            return Ok(commentDto);
//        }
    }
}