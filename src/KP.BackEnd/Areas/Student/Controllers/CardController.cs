using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KP.BackEnd.Areas.Shared.DTOs.Card;
using KP.BackEnd.Areas.Student.DTOs.Card;
using KP.BackEnd.Data;
using KP.BackEnd.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KP.BackEnd.Areas.Student.Controllers
{
    [Authorize]
    [Area("Student")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly CardRepository _cardRepository;

        public CardController(CardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        [HttpGet("{date}/{range}")]
        public async Task<ActionResult<IEnumerable<CardGetDto>>> GetAll(DateTime date, int range)
        {
            var userId = Guid.Parse(User.Identity.Name);
            var cards = await _cardRepository.GetRange(userId, date, range);

            var cardDtos = cards.Select(c => new CardGetDto(c, userId));
            
            return Ok(cardDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CardGetDto>> Get(Guid id)
        {
            var userId = Guid.Parse(User.Identity.Name);
            var card = await _cardRepository.Find(userId, id);
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
        
        [HttpPatch("{id}")]
        public async Task<ActionResult> Edit(Guid id, [FromBody] JsonPatchDocument<CardPatchDto> cardPatch)
        {
            var userId = Guid.Parse(User.Identity.Name);

            var card = await _cardRepository.Find(userId, id);
            if (card == null)
                return NotFound("card not found");

            var cardPatchDto = new CardPatchDto(card, userId);
            cardPatch.ApplyTo(cardPatchDto);

            // TODO user automapper for general purpose editing
            card.Status = cardPatchDto.Status;

            await _cardRepository.SaveChanges();

            return Ok();
        }
    }
}