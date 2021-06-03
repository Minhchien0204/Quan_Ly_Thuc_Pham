using DATN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.HocSinhService
{
    public interface IHocSinhService
    {
        Task<IEnumerable<HocSinh>> GetAllHs();
        Task<HocSinh> GetByIdHs(int id);
        Task UpdateHs(HocSinh hocsinh);
        Task<HocSinh> CreateHs(HocSinh hocsinh);
        Task DeleteHs(int id);
    }
}
