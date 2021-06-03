using DATN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.ChiTietBanGiaoService
{
    public interface IChiTietBanGiaoService
    {
        Task<ChiTietBanGiao> Create(ChiTietBanGiao chitietbg);
        Task<IEnumerable<ChiTietBanGiao>> GetAllCTBG();
        Task<ChiTietBanGiao> GetByIdCTBG(int id);
        Task DeleteCTBG(int id);
        Task UpdateCTBG(ChiTietBanGiao chitietbg);
    }
}
