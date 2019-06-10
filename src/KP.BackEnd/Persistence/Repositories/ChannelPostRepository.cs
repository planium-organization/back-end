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
    public class ChannelPostRepository : IChannelPostRepository
    {
        private readonly ApplicationDbContext _context;

        public ChannelPostRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ChannelPost> Find(Guid id)
        {
            return await _context.ChannelPosts.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ChannelPost> Find(Guid userId, Guid id)
        {
            return await _context.ChannelPosts.FirstOrDefaultAsync(p => p.Id == id && p.CreatorId == userId);
        }
        
        public async Task<List<ChannelPost>> GetRange(Guid classId,int page, int count)
        {
            return await _context.ChannelPosts
                .Where(x=> x.ClassId ==classId)
                .Skip(page * count)
                .Take(count)
                .ToListAsync();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Add(ChannelPost channelPost)
        {
            await _context.ChannelPosts.AddAsync(channelPost);
            await _context.SaveChangesAsync();
        }
    }
}