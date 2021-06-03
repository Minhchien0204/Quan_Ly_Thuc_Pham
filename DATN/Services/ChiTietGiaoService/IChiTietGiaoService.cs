using DATN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.ChiTietGiaoService
{
    public interface IChiTietGiaoService
    {
        Task<ChiTietGiao> Create(ChiTietGiao chitietg);
        Task<IEnumerable<ChiTietGiao>> GetAllCTG();
        Task<ChiTietGiao> GetByIdCTG(int id);
        Task DeleteCTG(int id);
        Task UpdateCTG(ChiTietGiao chitietg);
    }
}
