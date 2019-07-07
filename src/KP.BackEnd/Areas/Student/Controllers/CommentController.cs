using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KP.BackEnd.Core;
using KP.BackEnd.Core.DTOs.Shared.Comment;
using KP.BackEnd.Core.Models;
using KP.BackEnd.Persistence.EntityConfigurations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KP.BackEnd.Areas.Student.Controllers
{
    [Authorize(Roles = "Student")]
    [Route("api/student/[controller]")]
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

        [HttpGet("{date}/{page}/{count}")]
        public async Task<ActionResult<IEnumerable<CommentGetDto>>> GetAll(DateTime date, int page, int count)
        {
            var userId = ApplicationUserConfiguration.StudentIdTmp;
            var supervisorId= ApplicationUserConfiguration.SupervisorIdTmp;
            var comments = await _unitOfWork.Comments.GetRange(supervisorId,userId , date, page, count);

            var commentDtos = comments.Select(c => _mapper.Map<CommentGetDto>(c));
            
            return Ok(commentDtos);
        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<CommentGetDto>> Get(Guid id)
//        {
//            var userId = ApplicationUserConfiguration.StudentIdTmp;
//
//            var comment = await _unitOfWork.Comments.Find(userId, id);//QQ Guid id isn't enough?
//            if (comment == null)
//                return NotFound("card not found");
//            
//            var commentDto = _mapper.Map<CommentGetDto>(comment); // TODO
//            
//            return Ok(commentDto);
//        }
    }
}