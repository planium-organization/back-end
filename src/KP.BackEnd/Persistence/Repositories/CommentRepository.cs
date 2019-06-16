using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KP.BackEnd.Core.Models;
using KP.BackEnd.Core.Repositories;
using KP.BackEnd.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace KP.BackEnd.Persistence.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Comment>> GetRange(Guid supervisorId, Guid studentId, DateTime date, int page, int count)
        {
            return await _context.Comments
                .Where(c => c.SupervisorId == supervisorId && c.StudentId == studentId && c.CreationTime.Date == date)
                .OrderBy(c => c.CreationTime)
                .Skip(page * count)
                .Take(count)
                .ToListAsync();
        }

        public async Task<Comment> Find(Guid userId, Guid id)
        {
            return await _context.Comments.FirstOrDefaultAsync(c => c.StudentId == userId && c.Id == id);
        }
    }
}