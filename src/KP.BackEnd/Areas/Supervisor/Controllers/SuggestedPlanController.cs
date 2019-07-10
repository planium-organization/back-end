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

        
        
        
        [HttpPut("{classId}/{cardId}")]
        public async Task<ActionResult> EditCard(Guid classId, Guid cardId,[FromBody] CardPutDto cardPut)
        {
            var userId = Guid.Parse(_userManager.GetUserId(User));
            var supervisor = await _unitOfWork.Supervisors.Find(userId);

            var sClass = supervisor.SchoolClasses.FirstOrDefault(c => c.Id == classId);
            if (sClass == null)
                return BadRequest("Class Id is not valid");

            var card = sClass.SuggestedPlan.Cards.FirstOrDefault(c=>c.Id == cardId);
            if (card == null)
                return NotFound("card not found");

            
            bool expired = card.StartTime == null
                ? (DateTime.Today - card.DueDate.Date).Days >= 1
                : (card.StartTime + card.Duration) < DateTime.Now;
            bool editable = !expired && card.Status != CardStatus.Done;
            if (!editable)
                return BadRequest("card isn't editable!!");

            if (cardPut.StartTime.HasValue)
                card.StartTime = cardPut.StartTime.Value;

            if (cardPut.Duration.HasValue)
                card.Duration = cardPut.Duration.Value;

            if (cardPut.DueDate.HasValue)
                card.DueDate = cardPut.DueDate.Value;

            if (cardPut.Course != null)
                card.Course = _mapper.Map<Course>(cardPut.Course);

            if (cardPut.Description != null)
                card.Description = cardPut.Description;

            await _unitOfWork.Complete();


            var cardGetDto = _mapper.Map<CardGetDto>(card);

            cardGetDto.Done = card.Status == CardStatus.Done;
            cardGetDto.SupervisorCreated = card.SupervisorId.HasValue;
            cardGetDto.Expired = cardGetDto.StartTime == null
                ? (DateTime.Today - cardGetDto.DueDate.Date).Days >= 1
                : (cardGetDto.StartTime + cardGetDto.Duration) < DateTime.Now;
            cardGetDto.Editable = !cardGetDto.Expired && card.Status != CardStatus.Done;

            return Ok(cardGetDto);
        }
        
        [HttpDelete("{classId}/{cardId}")]
        public async Task<ActionResult> Remove(Guid classId, Guid cardId)
        {
            var userId = Guid.Parse(_userManager.GetUserId(User));
            var supervisor = await _unitOfWork.Supervisors.Find(userId);

            var sClass = supervisor.SchoolClasses.FirstOrDefault(c => c.Id == classId);
            if (sClass == null)
                return BadRequest("Class Id is not valid");

            var card = sClass.SuggestedPlan.Cards.FirstOrDefault(c=>c.Id == cardId);
            if (card == null)
                return NotFound("card not found");
            
            sClass.SuggestedPlan.Cards.Remove(card);
            await _unitOfWork.Complete();
            
            return Ok();
        }
    }
}