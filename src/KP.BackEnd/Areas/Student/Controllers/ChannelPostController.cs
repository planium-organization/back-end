using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KP.BackEnd.Areas.Shared.DTOs.ChannelPost;
using KP.BackEnd.Areas.Supervisor.DTOs.ChannelPost;
using KP.BackEnd.Data;
using KP.BackEnd.Migrations;
using KP.BackEnd.Models;
using KP.BackEnd.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KP.BackEnd.Areas.Student.Controllers
{
    [Authorize]
    [Area("Student")]
    [ApiController]
    public class ChannelPostController : ControllerBase
    {
        private readonly ChannelPostRepository _channelPostRepository;
        public ChannelPostController(ChannelPostRepository channelPostRepository)
        {
            _channelPostRepository = channelPostRepository;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ChannelPostGetDto>> Get(Guid id)
        {
            var channelPost = await _channelPostRepository.Find(id); // TODO filter by classId
            var channelPostGetDto = new ChannelPostGetDto(channelPost);
            return Ok(channelPostGetDto);
        }

        [HttpGet("{page}/{count}")]
        public async Task<ActionResult<IEnumerable<ChannelPostGetDto>>> GetAll(int page, int count)
        {
            var channelPosts = await _channelPostRepository.GetRange(page, count);
            var channelPostGetDtos = channelPosts.Select(p => new ChannelPostGetDto(p)).ToList();
            return Ok(channelPostGetDtos);
        }
    }
}