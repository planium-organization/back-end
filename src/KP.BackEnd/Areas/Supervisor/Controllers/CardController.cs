using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KP.BackEnd.Areas.Shared.DTOs.Card;
using KP.BackEnd.Data;
using KP.BackEnd.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Internal;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CardCreateDto = KP.BackEnd.Areas.Supervisor.DTOs.Card.CardCreateDto;

namespace KP.BackEnd.Areas.Supervisor.Controllers
{
    [Authorize]
    [Area("Supervisor")]
    [ApiController]
    public class CardController :ControllerBase
    {
        private readonly CardRepository _cardRepository;
        public CardController(CardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        [HttpGet("{studentId}/{date}/{range}")]
        public async Task<ActionResult<IEnumerable<CardGetDto>>> GetAll(Guid studentId, DateTime date, int range)
        {
            var cards = await _cardRepository.GetRange(studentId, date, range);
            
            return Ok(cards);
        }
        
        [HttpGet("{studentId}/{id}")]
        public async Task<ActionResult<CardGetDto>> Get(Guid studentId, Guid id)
        {
            var userId = Guid.Parse(User.Identity.Name);
            var card = await _cardRepository.Find(studentId, id);
            if (card == null)
                return NotFound("card not found");
            
            var cardDto = new CardGetDto(card, userId);
            return Ok(cardDto);
        }
        
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CardCreateDto cardDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = Guid.Parse(User.Identity.Name);
            var card = cardDto.ToCard(userId);

            await _cardRepository.Add(card);                
            return CreatedAtAction(nameof(Get), new CardGetDto(card, userId));
        }

    }
}