using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using KP.BackEnd.Core;
using KP.BackEnd.Core.DTOs.Supervisor.Student;
using KP.BackEnd.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KP.BackEnd.Areas.Supervisor.Controllers
{
    [Authorize(Roles = "Supervisor")]
    [Route("api/supervisor/[controller]")]
    [ApiController]
    public class StudentController:ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        
        public StudentController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet("{classId}")]
        public async Task<ActionResult<IEnumerable<StudentGetDto>>> GetAll(Guid classId)
        {
            var userId = Guid.Parse(_userManager.GetUserId(User));

            var students = await _unitOfWork.SchoolClasses.GetAll(userId);
            var studentsDtos = _mapper.Map<IEnumerable<StudentGetDto>>(students);
            //TODO student's emails as username should be mapped also 
            return Ok(studentsDtos);
        }
    }
}