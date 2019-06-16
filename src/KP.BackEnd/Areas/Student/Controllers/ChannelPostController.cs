using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KP.BackEnd.Core;
using KP.BackEnd.Core.DTOs.Shared.ChannelPost;
using KP.BackEnd.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KP.BackEnd.Areas.Student.Controllers
{
    // [Authorize]
    [Route("api/student/[controller]")]
    [ApiController]
    public class ChannelPostController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ChannelPostController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ChannelPostGetDto>> Get(Guid id)
        {
            var channelPost = await _unitOfWork.ChannelPosts.Find(id); // TODO filter by classId
            
            var channelPostGetDto = _mapper.Map<ChannelPostGetDto>(channelPost); // TODO
            
            return Ok(channelPostGetDto);
        }

        [HttpGet("{page}/{count}")]
        public async Task<ActionResult<IEnumerable<ChannelPostGetDto>>> GetAll(Guid classId, int page, int count)
        {
//            TODO get posts via student/user id (finding class id) 
//            var userId = Guid.Parse(User.Identity.Name);
            var channelPosts = await _unitOfWork.ChannelPosts.GetRange(classId, page, count);
            
            var channelPostGetDtos = channelPosts.Select<ChannelPost,ChannelPostGetDto>(p => _mapper.Map<ChannelPostGetDto>(p)).ToList(); // TODO
            
            return Ok(channelPostGetDtos);
        }
    }
}