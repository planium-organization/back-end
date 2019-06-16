using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KP.BackEnd.Core.Models;

namespace KP.BackEnd.Core.Repositories
{
    public interface ICardRepository
    {
        Task<IEnumerable<Card>> GetRange(Guid studentId, DateTime date, int range);
        Task<IEnumerable<Card>> GetRange(Guid supervisorId, Guid studentId, DateTime date, int range);
        Task<Card> Find(Guid studentId, Guid id);
        void Remove(Card card);
        Task<Card> Find(Guid supervisorId, Guid studentId, Guid id);
        Task Add(Card card);
    }
}