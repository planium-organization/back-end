using System;
using System.Threading.Tasks;
using AutoMapper;
using KP.BackEnd.Core;
using KP.BackEnd.Core.DTOs.Shared.Profile;
using KP.BackEnd.Core.DTOs.Supervisor.Profile;
using KP.BackEnd.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KP.BackEnd.Areas.Supervisor.Controllers
{
    [Authorize(Roles = "Supervisor")]
    [Route("api/supervisor/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        
        public ProfileController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }
        
        [HttpGet]
        public async Task<ActionResult<StudentGetDto>> Get()
        {
            var userId = Guid.Parse(_userManager.GetUserId(User));
            var supervisor = await _unitOfWork.Supervisors.Find(userId);

            var profileDto = _mapper.Map<SupervisorGetDto>(supervisor);

            return Ok(profileDto);
        }

        [HttpPut]
        public async Task<ActionResult<SupervisorGetDto>> Edit([FromBody] SupervisorPutDto putDto)
        {
            var userId = Guid.Parse(_userManager.GetUserId(User));
            var supervisor = await _unitOfWork.Supervisors.Find(userId);

            if (putDto.FirstName != null)
                supervisor.Identity.FirstName = putDto.FirstName;
            if (putDto.LastName != null)
                supervisor.Identity.LastName = putDto.LastName;
            if (putDto.UserName != null)
                supervisor.Identity.UserName = putDto.UserName;
            if (putDto.Email != null)
                supervisor.Identity.Email = putDto.Email;
            if (putDto.Image != null)
                supervisor.Identity.Image = putDto.Image;
           
            await _unitOfWork.Complete();

            return Ok(_mapper.Map<StudentGetDto>(supervisor));
        }
    }
}