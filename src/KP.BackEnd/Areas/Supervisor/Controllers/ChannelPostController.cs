using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KP.BackEnd.Core;
using KP.BackEnd.Core.DTOs.Shared.ChannelPost;
using KP.BackEnd.Core.DTOs.Supervisor.ChannelPost;
using KP.BackEnd.Core.Models;
using KP.BackEnd.Persistence;
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
            
            var supervisor = await _unitOfWork.Supervisors.Find(userId);
            
            var schoolClass =  supervisor.SchoolClasses.FirstOrDefault(sc => sc.Id == classId);
            if (schoolClass == null)
                return NotFound("Class not found");

            var channelPosts = schoolClass.ChannelPosts.Skip(page * count).Take(count).ToList();
            var channelPostDtos = _mapper.Map<IEnumerable<ChannelPostGetDto>>(channelPosts); 
            
            return Ok(channelPostDtos);
        }
        
        [HttpPost("{classId}")]
        public async Task<ActionResult<ChannelPostGetDto>> Create([FromBody] ChannelPostPostDto dto,Guid classId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = Guid.Parse(_userManager.GetUserId(User));
            var supervisor = await _unitOfWork.Supervisors.Find(userId);

            var schoolClass =  supervisor.SchoolClasses.FirstOrDefault(sc => sc.Id == classId);
            if (schoolClass == null)
                return NotFound("Class not found");

            var channelPost = _mapper.Map<ChannelPost>(dto);
            
            schoolClass.ChannelPosts.Add(channelPost);
            await _unitOfWork.Complete();
            
            return CreatedAtAction(null, _mapper.Map<ChannelPostGetDto>(channelPost), null);
        }
        
        [HttpDelete("{classId}/{id}")]
        public async Task<ActionResult> Remove(Guid classId, Guid id)
        {
            var userId = Guid.Parse(_userManager.GetUserId(User));
            var supervisor = await _unitOfWork.Supervisors.Find(userId);

            var schoolClass =  supervisor.SchoolClasses.FirstOrDefault(sc => sc.Id == classId);
            if (schoolClass == null)
                return NotFound("Class not found");

            var channelPost = schoolClass.ChannelPosts.FirstOrDefault(cp => cp.Id == id);
            if (channelPost == null)
                return NotFound("ChannelPost not found!");
            
            schoolClass.ChannelPosts.Remove(channelPost);
            await _unitOfWork.Complete();
            
            return Ok();
        }
    }
}