using DATN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.ChiTietCungCapService
{
    public interface IChiTietCungCapService
    {
        Task<ChiTietCungCap> Create(ChiTietCungCap chitietcc);
        Task<IEnumerable<ChiTietCungCap>> GetAllCTCC();
        Task<ChiTietCungCap> GetByIdCTCC(int id);
        Task DeleteCTCC(int id);
        Task UpdateCTCC(ChiTietCungCap chitietcc);
    }
}
