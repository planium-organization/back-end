using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KP.BackEnd.Core;
using KP.BackEnd.Core.DTOs.Shared.ChannelPost;
using KP.BackEnd.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KP.BackEnd.Areas.Student.Controllers
{
    [Authorize(Roles = "Student")]
    [Route("api/student/[controller]")]
    [ApiController]
    public class ChannelPostController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        
        public ChannelPostController(IUnitOfWork unitOfWork, IMapper mapper,UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<ChannelPostGetDto>> Get(Guid id)
//        {
//            var userId = _userManager.GetUserAsync(User);
//
//            var channelPost = await _unitOfWork.ChannelPosts.Find(userId, id); 
//            
//            var channelPostGetDto = _mapper.Map<ChannelPostGetDto>(channelPost); // TODO
//            
//            return Ok(channelPostGetDto);
//        }

        [HttpGet("{page}/{count}")]
        public async Task<ActionResult<IEnumerable<ChannelPostGetDto>>> GetAll(int page, int count)
        {
            var userId = Guid.Parse(_userManager.GetUserId(User));
            var student = await _unitOfWork.Students.Find(userId);
            var sClass = student.SchoolClass;
            if (sClass == null)
                return BadRequest("You have to join a class first");
            
            var channelPosts = sClass.ChannelPosts.Skip(page).Take(count).ToList();
            var channelPostGetDtos = _mapper.Map<IEnumerable<ChannelPostGetDto>>(channelPosts);
            
            return Ok(channelPostGetDtos);
        }
    }
}