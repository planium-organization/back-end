using System;
using System.Threading.Tasks;
using KP.BackEnd.Core.Models;

namespace KP.BackEnd.Core.Repositories
{
    public interface IStudentRepository
    {
        Task<Student> Find(Guid studentId);
        Task<Student> FindBySupervisor(Guid supervisorId, Guid studentId);
    }
}