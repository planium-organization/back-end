using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KP.BackEnd.Areas.Shared.DTOs.Card;
using KP.BackEnd.Areas.Student.DTOs.Card;
using KP.BackEnd.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KP.BackEnd.Areas.Supervisor.Controllers
{
    [Authorize]
    [Area("Supervisor")]
    [ApiController]
    public class CardController :ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CardController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{studentId}/{date}/{range}")]
        public async Task<ActionResult<IEnumerable<CardGetDto>>> GetAll(Guid studentId, DateTime date, int range)
        {
            var cards = await _context.Cards
                .Where(x => x.StudentId == studentId && x.DueDate.Date.Subtract(date.Date).Days < range)
                .ToListAsync();
            
            return Ok(cards);
        }

    }
}