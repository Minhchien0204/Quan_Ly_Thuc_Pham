using DATN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.PhieuCungCapService
{
    public interface IPhieuCungCapService
    {
        Task<PhieuCungCap> CreatePCC(PhieuCungCap phieucungcau);
        Task<IEnumerable<PhieuCungCap>> GetAllPCC();
        Task<PhieuCungCap> GetByIdPYC(string sophieucungcap);
        Task DeletePCC(string sophieucungcap);
        Task UpdatePYC(PhieuCungCap phieucungcau);
        Task<IEnumerable<ChiTietCungCap>> GetDetailPYC(string sophieucungcap);
    }
}
