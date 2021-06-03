using DATN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.ChiTietKiemKeService
{
    public interface IChiTietKiemKeService
    {
        Task<ChiTietKiemKe> Create(ChiTietKiemKe chitietkk);
        Task<IEnumerable<ChiTietKiemKe>> GetAllCTKK();
        Task<ChiTietKiemKe> GetCTKKById(int id);
        Task DeleteCTKK(int id);
        Task UpdateCTKK(ChiTietKiemKe chitietkk);
    }
}
