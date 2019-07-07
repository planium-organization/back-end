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
        public async Task<ActionResult<IEnumerable<ChannelPostGetDto>>> GetAll(Guid classId, int page, int count)
        {
//            TODO get posts via student/user id (finding class id) 
            var userId = Guid.Parse(_userManager.GetUserId(User));
            
            var channelPosts = await _unitOfWork.ChannelPosts.GetRange(classId, page, count);
            
            var channelPostGetDtos = channelPosts.Select<ChannelPost,ChannelPostGetDto>(p => _mapper.Map<ChannelPostGetDto>(p)).ToList(); // TODO
            
            return Ok(channelPostGetDtos);
        }
    }
}