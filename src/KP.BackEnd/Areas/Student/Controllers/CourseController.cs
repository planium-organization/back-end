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

namespace KP.BackEnd.Areas.Student.Controllers
{
    [Authorize(Roles = "Student")]
    [Route("api/student/[controller]")]
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

        [HttpPost]
        public async Task<ActionResult<CourseGetDto>> Create([FromBody] CoursePostDto postDto)
        {
            var userId = Guid.Parse(_userManager.GetUserId(User));
            var student = await _unitOfWork.Students.Find(userId);
            var courseExists = student.Courses.Any(c => c.Title == postDto.Title);
            if (courseExists)
                return BadRequest("A course with this title exists");
            
            var course = _mapper.Map<Course>(postDto);
            student.Courses.Add(course);

            await _unitOfWork.Complete();
            
            var courseGetDto = _mapper.Map<CourseGetDto>(course);
            return Ok(courseGetDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseGetDto>>> GetAll()
        {
            var userId = Guid.Parse(_userManager.GetUserId(User));
            var student = await _unitOfWork.Students.Find(userId);
            var courses = _mapper.Map<IEnumerable<CourseGetDto>>(student.Courses);
            return Ok(courses);
        }

        
    }
}