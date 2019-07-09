using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KP.BackEnd.Core;
using KP.BackEnd.Core.DTOs.Shared.ChannelPost;
using KP.BackEnd.Core.DTOs.Supervisor.ChannelPost;
using KP.BackEnd.Core.Models;
using KP.BackEnd.Persistence.EntityConfigurations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KP.BackEnd.Areas.Supervisor.Controllers
{
    [Authorize(Roles = "Supervisor")]
    [Route("api/supervisor/[controller]")]
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
//            var userId = Guid.Parse(_userManager.GetUserId(User));
//            
//            var channelPost = await _unitOfWork.ChannelPosts.Find(userId,id);
//            return Ok(_mapper.Map<ChannelPostGetDto>(channelPost)); 
//        }
//        
        [HttpGet("{classId}/{page}/{count}")]
        public async Task<ActionResult<IEnumerable<ChannelPostGetDto>>> GetAll(Guid classId, int page, int count)
        {
            var userId = Guid.Parse(_userManager.GetUserId(User));

            var channelPosts = await _unitOfWork.ChannelPosts.GetRange(userId, classId, page, count);
            var channelPostDtos = channelPosts.Select(cp => _mapper.Map<ChannelPostGetDto>(cp)); 
            return Ok(channelPostDtos);
        }
        
        [HttpPost]
        public async Task<ActionResult<ChannelPostGetDto>> Create([FromBody] ChannelPostPostDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = Guid.Parse(_userManager.GetUserId(User));
            
            var channelPost = _mapper.Map<ChannelPost>(dto); // TODO
            
            await _unitOfWork.ChannelPosts.Add(channelPost);
            await _unitOfWork.Complete();
            
            return CreatedAtAction(null, _mapper.Map<ChannelPostGetDto>(channelPost), null);
        }
    }
}