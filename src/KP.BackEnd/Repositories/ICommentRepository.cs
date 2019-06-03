using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KP.BackEnd.Models;

namespace KP.BackEnd.Repositories
{
    public interface ICommentRepository
    { 
        Task<IEnumerable<Comment>> GetRange(Guid supervisorId, Guid studentId, DateTime date, int page, int count);
        Task<Comment> Find(Guid userId, Guid id);
    }
}