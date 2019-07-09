using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KP.BackEnd.Core.Models;

namespace KP.BackEnd.Core.Repositories
{
    public interface IStudentRepository
    {
        Task<Student> Find(Guid id);
        Task<IEnumerable<Student>> FindAll(Guid classId);
    }
}