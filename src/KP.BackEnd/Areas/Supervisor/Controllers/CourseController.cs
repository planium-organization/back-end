using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KP.BackEnd.Core;
using KP.BackEnd.Core.DTOs.Shared.Course;
using KP.BackEnd.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KP.BackEnd.Areas.Supervisor.Controllers
{
    [Authorize(Roles = "Supervisor")]
    [Route("api/supervisor/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public CourseController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseGetDto>>> GetAll()
        {
            var userId = Guid.Parse(_userManager.GetUserId(User));
            var supervisor = await _unitOfWork.Supervisors.Find(userId);
            
            var courses = _mapper.Map<IEnumerable<CourseGetDto>>(supervisor.Courses);
            return Ok(courses);
        }
        
        [HttpPost]
        public async Task<ActionResult<CourseGetDto>> Create([FromBody] CoursePostDto postDto)
        {
            var userId = Guid.Parse(_userManager.GetUserId(User));
            var supervisor = await _unitOfWork.Supervisors.Find(userId);
            
            var courseExists = supervisor.Courses.Any(c => c.Title == postDto.Title);
            if (courseExists)
                return BadRequest("A course with this title exists");
            
            var course = _mapper.Map<Course>(postDto);
            supervisor.Courses.Add(course);

            await _unitOfWork.Complete();
            
            var courseGetDto = _mapper.Map<CourseGetDto>(course);
            return Ok(courseGetDto);
        }
    }
}