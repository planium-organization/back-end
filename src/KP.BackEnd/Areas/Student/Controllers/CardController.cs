using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KP.BackEnd.Core;
using KP.BackEnd.Core.DTOs.Shared.Card;
using KP.BackEnd.Core.DTOs.Shared.Course;
using KP.BackEnd.Core.DTOs.Student.Card;
using KP.BackEnd.Core.Models;
using KP.BackEnd.Persistence.EntityConfigurations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace KP.BackEnd.Areas.Student.Controllers
{
    [Authorize(Roles = "Student")]
    [Route("api/student/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CardController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{date}/{range}")]
        public async Task<ActionResult<IEnumerable<CardGetDto>>> GetRangeByDate(string date, int range)
        {
            // var userId = Guid.Parse(User.Identity.Name);
            var userId = ApplicationUserConfiguration.StudentIdTmp;
            var cards = await _unitOfWork.Cards.GetRange(userId, DateTime.Parse(date), range);

            var cardDtos = new List<CardGetDto>();
            foreach (var card in cards)
            {
                var cardDto = _mapper.Map<CardGetDto>(card);
                
                cardDto.Done = card.Status == CardStatus.Done;
                cardDto.SupervisorCreated = card.SupervisorId.HasValue;
                cardDto.Expired = cardDto.StartTime == null
                    ? (DateTime.Today - cardDto.DueDate.Date).Days >= 1
                    : (cardDto.StartTime + cardDto.Duration) < DateTime.Now;
                cardDto.Editable = !cardDto.Expired && card.Status != CardStatus.Done;

                cardDtos.Add(cardDto);
            }

            return Ok(cardDtos);
        }


        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CardPostDto cardDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = ApplicationUserConfiguration.StudentIdTmp;
            var card = _mapper.Map<Card>(cardDto);
            card.Status = CardStatus.Todo;
            card.StudentId = userId;
            
            await _unitOfWork.Cards.Add(card);
            await _unitOfWork.Complete();
            
            var cardGetDto=_mapper.Map<CardGetDto>(card);
            
            cardGetDto.SupervisorCreated = card.SupervisorId.HasValue;
            cardGetDto.Expired = cardGetDto.StartTime == null
                ? (DateTime.Today - cardGetDto.DueDate.Date).Days >= 1
                : (cardGetDto.StartTime + cardGetDto.Duration) < DateTime.Now;
            cardGetDto.Editable = !cardGetDto.Expired && card.Status != CardStatus.Done;
            
            return Created(string.Empty, cardGetDto); 
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(Guid id, CardPutDto cardPut)
        {
            var userId = ApplicationUserConfiguration.StudentIdTmp;
            var card = await _unitOfWork.Cards.Find(userId, id);
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

            if (cardPut.Done.HasValue && cardPut.Done.Value)
                card.Status = CardStatus.Done;
            
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

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(Guid id)
        {
            var userId = ApplicationUserConfiguration.StudentIdTmp;
            var card = await _unitOfWork.Cards.Find(userId, id);
            if (card == null)
                return NotFound("card not found!");
            
            _unitOfWork.Cards.Remove(card);
            await _unitOfWork.Complete();
            
            return Ok();
        }
        // [HttpGet("{id}")]
        // public async Task<ActionResult<CardGetDto>> Get(Guid id)
        // {
        //     // var userId = Guid.Parse(User.Identity.Name);
        //     var userId = ApplicationUserConfiguration.StudentIdTmp;
        //     var card = await _unitOfWork.Cards.Find(userId, id); //QQ Guid id isn't enough?
        //     if (card == null)
        //         return NotFound("card not found!");

        //     CardGetDto cardDto = _mapper.Map<CardGetDto>(card); // TODO
        //     cardDto.Expired = cardDto.StartTime == null
        //         ? (DateTime.Today - cardDto.DueDate.Date).Days >= 1
        //         : (cardDto.StartTime + cardDto.Duration) < DateTime.Now;
        //     cardDto.Editable = !cardDto.Expired && card.Status != CardStatus.Done && card.StudentId == userId;

        //     return Ok(cardDto);
        // }
    }
}
