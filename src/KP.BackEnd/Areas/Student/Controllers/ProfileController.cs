using System;
using System.Threading.Tasks;
using AutoMapper;
using KP.BackEnd.Core;
using KP.BackEnd.Core.DTOs.Shared.Profile;
using KP.BackEnd.Core.DTOs.Student.Profile;
using KP.BackEnd.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KP.BackEnd.Areas.Student.Controllers
{
    [Authorize(Roles = "Student")]
    [Route("api/student/[controller]")]
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
            var student = await _unitOfWork.Students.Find(userId);

            var profileDto = _mapper.Map<StudentGetDto>(student);

            return Ok(profileDto);
        }

        [HttpPut]
        public async Task<ActionResult<StudentGetDto>> Edit([FromBody] StudentPutDto putDto)
        {
            var userId = Guid.Parse(_userManager.GetUserId(User));
            var student = await _unitOfWork.Students.Find(userId);

            if (putDto.FirstName != null)
                student.Identity.FirstName = putDto.FirstName;
            if (putDto.LastName != null)
                student.Identity.LastName = putDto.LastName;
            if (putDto.UserName != null)
                student.Identity.UserName = putDto.UserName;
            if (putDto.Email != null)
                student.Identity.Email = putDto.Email;
            if (putDto.Image != null)
                student.Identity.Image = putDto.Image;
            if (putDto.Major != null)
                student.Major = putDto.Major;
            
            await _unitOfWork.Complete();

            return Ok(_mapper.Map<StudentGetDto>(student));
        }
        
        
    }
}