using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KP.BackEnd.Core.Models;
using KP.BackEnd.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KP.BackEnd.Persistence.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly ApplicationDbContext _context;

        public CardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Card>> GetRange(Guid studentId, DateTime date, int range)
        {
            return await _context.Cards.Include(c => c.Course)
                .Where(x => x.StudentId == studentId &&
                            Math.Abs(x.DueDate.Date.Subtract(date.Date).Days) < range) //TODO can't generate sql
                .ToListAsync();
        }

        public async Task<IEnumerable<Card>> GetRange(Guid supervisorId, Guid studentId, DateTime date, int range)
        {
            //TODO check supervisor id 
            return await _context.Cards.Include(c => c.Course)
                .Where(x => x.StudentId == studentId &&
                            Math.Abs(x.DueDate.Date.Subtract(date.Date).Days) < range) //TODO can't generate sql
                .ToListAsync();
        }

        public async Task<Card> Find(Guid studentId, Guid id)
        {
            return await _context.Cards.Include(c => c.Course).Where(c => c.StudentId == studentId && c.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Card> Find(Guid supervisorId, Guid studentId, Guid id)
        {
            return await _context.Cards.Include(c => c.Course)
                .Where(c => c.StudentId == studentId && c.Id == id)//TODO check whether if students belongs to this supervisor
                .FirstOrDefaultAsync();
        }

        public async Task Add(Card card)
        {
            await _context.Cards.AddAsync(card);
        }

        public void Remove(Card card)
        {
            _context.Cards.Remove(card);
        }
    }
}