using DATN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.PhieuBanGiaoService
{
    public interface IPhieuBanGiaoService
    {
        Task<PhieuBanGiao> CreatePBG(PhieuBanGiao phieubangiao);
        Task<IEnumerable<PhieuBanGiao>> GetAllPBG();
        Task<PhieuBanGiao> GetByIdPBG(string sophieubangiao);
        Task DeletePBG(string sophieubangiao);
        Task UpdatePBG(PhieuBanGiao phieubangiao);
        Task<IEnumerable<ChiTietBanGiao>> GetDetailPBG(string sophieubangiao);
    }
}
