using System;
using System.Threading.Tasks;
using AutoMapper;
using KP.BackEnd.Core;
using KP.BackEnd.Core.DTOs.Shared.SchoolClass;
using KP.BackEnd.Core.DTOs.Student.SchoolClass;
using KP.BackEnd.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KP.BackEnd.Areas.Student.Controllers
{
    [Authorize(Roles = "Student")]
    [Route("api/student/[controller]")]
    [ApiController]
    public class SchoolClassController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        
        public SchoolClassController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<SchoolClassGetDto>> Get()
        {
            var userId = Guid.Parse(_userManager.GetUserId(User));
            var student = await _unitOfWork.Students.Find(userId);
            var sClass = _mapper.Map<SchoolClassGetDto>(student.SchoolClass);
            return Ok(sClass);
        }

        [HttpPost("join")]
        public async Task<ActionResult<SchoolClassGetDto>> Join([FromBody] SchoolClassJoinDto joinDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var sClass = await _unitOfWork.SchoolClasses.FindByToken(joinDto.Token);
            if (sClass == null)
                return BadRequest("Token is not valid");
            
            var userId = Guid.Parse(_userManager.GetUserId(User));
            var student = await _unitOfWork.Students.Find(userId);
            student.SchoolClass = sClass;
            
            await _unitOfWork.Complete();
            
            return Ok(_mapper.Map<SchoolClassGetDto>(sClass));
        }
    }
}