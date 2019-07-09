using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KP.BackEnd.Core;
using KP.BackEnd.Core.DTOs.Shared.Card;
using KP.BackEnd.Core.DTOs.Shared.SuggestedPlan;
using KP.BackEnd.Core.DTOs.Supervisor.SuggestedPlan;
using KP.BackEnd.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KP.BackEnd.Areas.Supervisor.Controllers
{
    [Authorize(Roles = "Supervisor")]
    [Route("api/supervisor/[controller]")]
    [ApiController]
    public class SuggestedPlanController:ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        
        public SuggestedPlanController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet("{classId}")]
        public async Task<ActionResult<SuggestedPlanGetDto>> Get(Guid classId)
        {
            var userId = Guid.Parse(_userManager.GetUserId(User));
            var supervisor = await _unitOfWork.Supervisors.Find(userId);

            var sClass = supervisor.SchoolClasses.FirstOrDefault(c => c.Id == classId);
            if (sClass == null)
                return BadRequest("Class Id is not valid");

            var plan = _mapper.Map<SuggestedPlanGetDto>(sClass.SuggestedPlan);

            return Ok(plan);
        }
        
        [HttpPost("{classId}")]
        public async Task<ActionResult<SuggestedPlanGetDto>> Create(Guid classId, [FromBody] SuggestedPlanPostDto postDto)
        {
            var userId = Guid.Parse(_userManager.GetUserId(User));
            var supervisor = await _unitOfWork.Supervisors.Find(userId);

            var sClass = supervisor.SchoolClasses.FirstOrDefault(c => c.Id == classId);
            if (sClass == null)
                return BadRequest("Class Id is not valid");

            var plan = _mapper.Map<SuggestedPlan>(postDto);
            plan.SchoolClass = sClass;

            await _unitOfWork.Complete();

            return Ok(_mapper.Map<SuggestedPlanGetDto>(plan));
        }
        
    }
}