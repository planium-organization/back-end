using System.Threading.Tasks;
using KP.BackEnd.Core.Repositories;

namespace KP.BackEnd.Core
{
    public interface IUnitOfWork
    {
        ICardRepository Cards { get; }
        ICommentRepository Comments { get; }
        ISchoolClassRepository SchoolClasses { get; }
        IChannelPostRepository ChannelPosts { get; }
        
        Task Complete();
    }
}