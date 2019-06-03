using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KP.BackEnd.Models;

namespace KP.BackEnd.Repositories
{
    public interface ICardRepository
    {
        Task<List<Card>> GetRange(Guid studentId, DateTime date, int range);
        Task<Card> Find(Guid userId, Guid id);
        Task Add(Card card);
    }
}