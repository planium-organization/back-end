using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KP.BackEnd.Core;
using KP.BackEnd.Core.DTOs.Shared.Course;
using KP.BackEnd.Core.DTOs.Student.Analysis;
using KP.BackEnd.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KP.BackEnd.Areas.Supervisor.Controllers
{
    [Authorize(Roles = "Supervisor")]
    [Route("api/supervisor/[controller]")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private readonly UserManager<ApplicationUser> _userManager;

        public AnalysisController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet("{studentId}/{date}/{range}")]
        public async Task<ActionResult<IEnumerable<WeeklyAnalysisGetDto>>> GetWeeklyAnalysis(Guid studentId, DateTime date, int range)
        {
            var userId = Guid.Parse(_userManager.GetUserId(User));
            var student = await _unitOfWork.Students.FindBySupervisor(userId, studentId);
            if (student == null)
                return BadRequest("Student Id is not valid");
            
            var analysis = student.Cards
                .Where(c => c.DueDate >= date && c.DueDate < date.AddDays(range))
                .GroupBy(c => c.Course)
                .Select(g => new WeeklyAnalysisGetDto
                {
                    Course = _mapper.Map<CourseGetDto>(g.Key),
                    TotalTime = g.Select(c => (long) c.Duration.TotalMinutes).Sum(),
                    TotalDoneTime = g.Where(c => c.Status == CardStatus.Done)
                        .Select(c => (long) c.Duration.TotalMinutes).Sum()
                })
                .ToList();

            return Ok(analysis);
        }

    }
}