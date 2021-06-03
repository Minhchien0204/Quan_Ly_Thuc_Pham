using DATN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.Lop
{
    public interface IClassService
    {
        Task<Class> CreateClass(Class lop);
        Task<IEnumerable<Class>> GetAllClass();
        Task<IEnumerable<HocSinh>> GetByIdClass(string MaLop);
        Task UpdateClass(Class lop);
        Task Delete(string MaLop);
        Task<Class> GetById(string Malop);
    }
}
