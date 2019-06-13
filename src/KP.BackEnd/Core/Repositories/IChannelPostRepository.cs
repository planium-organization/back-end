using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KP.BackEnd.Core.Models;

namespace KP.BackEnd.Core.Repositories
{
    public interface IChannelPostRepository
    {
        Task<ChannelPost> Find(Guid id);
        Task<ChannelPost> Find(Guid userId, Guid id);
        Task<IEnumerable<ChannelPost>> GetRange(Guid classId, int page, int count);
        Task Add(ChannelPost channelPost);
    }
}