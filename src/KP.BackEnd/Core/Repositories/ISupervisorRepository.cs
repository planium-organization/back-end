using System;
using System.Threading.Tasks;
using KP.BackEnd.Core.Models;

namespace KP.BackEnd.Core.Repositories
{
    public interface ISupervisorRepository
    {
        Task<Supervisor> Find(Guid id);
    }
}