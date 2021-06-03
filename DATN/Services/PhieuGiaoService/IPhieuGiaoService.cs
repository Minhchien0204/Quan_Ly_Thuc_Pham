using DATN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.PhieuGiaoService
{
    public interface IPhieuGiaoService
    {
        Task<PhieuGiao> CreatePG(PhieuGiao phieugiao);
        Task<IEnumerable<PhieuGiao>> GetAllPG();
        Task<PhieuGiao> GetByIdPG(string sophieugiao);
        Task DeletePG(string sophieugiao);
        Task UpdatePG(PhieuGiao phieugiao);
        Task<IEnumerable<ChiTietGiao>> GetDetailPG(string sophieugiao);
    }
}
