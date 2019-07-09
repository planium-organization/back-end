using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using KP.BackEnd.Core;
using KP.BackEnd.Core.DTOs.Shared.Profile;
using KP.BackEnd.Core.DTOs.Shared.SchoolClass;
using KP.BackEnd.Core.DTOs.Supervisor.SchoolClass;
using KP.BackEnd.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KP.BackEnd.Areas.Supervisor.Controllers
{
    [Authorize(Roles = "Supervisor")]
    [Route("api/supervisor/[controller]")]
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

        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolClassGetDto>> Get(Guid id)
        {
            var userId = Guid.Parse(_userManager.GetUserId(User));

            var schoolClass = await _unitOfWork.SchoolClasses.Find(userId,id);
            
            return Ok(_mapper.Map<SchoolClassGetDto>(schoolClass));
        }
        
        [HttpPost]
        public async Task<ActionResult<SchoolClassGetDto>> Create([FromBody] SchoolClassPostDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var userId = Guid.Parse(_userManager.GetUserId(User));

            var schoolClass = _mapper.Map<SchoolClass>(dto);
            schoolClass.SupervisorId = userId;

            await _unitOfWork.SchoolClasses.Add(schoolClass);
            await _unitOfWork.Complete();

            return CreatedAtAction(nameof(Get), _mapper.Map<SchoolClassGetDto>(schoolClass), null);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchoolClassGetDto>>> GetAll()
        {
            var userId = Guid.Parse(_userManager.GetUserId(User));

            var schoolClasses = await _unitOfWork.SchoolClasses.GetAll(userId);
            if (schoolClasses == null)
                return NotFound("No registered classes found for this supervisor");
            
            var sClassesDtos = _mapper.Map<IEnumerable<SchoolClass>, IEnumerable<SchoolClassGetDto>>(schoolClasses);
            
            return Ok(sClassesDtos);
        }
        
        [HttpGet("{classId}/students")]
        public async Task<ActionResult<IEnumerable<StudentGetDto>>> GetAllStudents(Guid classId)
        {
            var userId = Guid.Parse(_userManager.GetUserId(User));

            var schoolClass = await _unitOfWork.SchoolClasses.Find(userId, classId);
            if(schoolClass == null)
                return NotFound("Class not found");

            var students = _unitOfWork.Students.FindAll(classId);
            var studentsDtos = _mapper.Map<IEnumerable<StudentGetDto>>(students);
            //TODO student's emails as username should be mapped also 
            return Ok(studentsDtos);
        }
    }
}