using System.Threading.Tasks;
using KP.BackEnd.Repositories;

namespace KP.BackEnd.Persistence
{
    public interface IUnitOfWork
    {
        ICardRepository Cards { get; }
        ICommentRepository Comments { get; }
        IChannelPostRepository ChannelPosts { get; }
        Task Complete();
    }
}