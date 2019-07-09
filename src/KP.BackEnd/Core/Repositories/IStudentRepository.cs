using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KP.BackEnd.Core.Models;

namespace KP.BackEnd.Core.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> FindAll(Guid classId);
        Task<Student> Find(Guid studentId);
        Task<Student> FindBySupervisor(Guid supervisorId, Guid studentId);
    }
}