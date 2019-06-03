using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KP.BackEnd.Models;

namespace KP.BackEnd.Repositories
{
    public interface IChannelPostRepository
    {
        Task<ChannelPost> Find(Guid id);
        Task<ChannelPost> Find(Guid userId, Guid id);
        Task<List<ChannelPost>> GetRange(Guid classId,int page, int count);
        Task SaveChanges();
        Task Add(ChannelPost channelPost);
    }
}