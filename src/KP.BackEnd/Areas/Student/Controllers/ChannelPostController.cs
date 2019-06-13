using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KP.BackEnd.Core;
using KP.BackEnd.Core.DTOs.Shared.ChannelPost;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KP.BackEnd.Areas.Student.Controllers
{
    [Authorize]
    [Area("Student")]
    [ApiController]
    public class ChannelPostController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ChannelPostController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ChannelPostGetDto>> Get(Guid id)
        {
            var channelPost = await _unitOfWork.ChannelPosts.Find(id); // TODO filter by classId
            var channelPostGetDto = new ChannelPostGetDto(channelPost);
            return Ok(channelPostGetDto);
        }

        [HttpGet("{page}/{count}")]
        public async Task<ActionResult<IEnumerable<ChannelPostGetDto>>> GetAll(Guid classId, int page, int count)
        {
//            var userId = Guid.Parse(User.Identity.Name);
            var channelPosts = await _unitOfWork.ChannelPosts.GetRange(classId,page, count);
            var channelPostGetDtos = channelPosts.Select(p => new ChannelPostGetDto(p)).ToList();
            return Ok(channelPostGetDtos);
        }
    }
}