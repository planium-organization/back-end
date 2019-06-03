using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KP.BackEnd.Data;
using KP.BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace KP.BackEnd.Repositories
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