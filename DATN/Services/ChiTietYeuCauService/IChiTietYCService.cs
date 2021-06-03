using DATN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.ChiTietYeuCauService
{
    public interface IChiTietYCService
    {
        Task<ChiTietYeuCau> Create(ChiTietYeuCau chitietyc);
        Task<IEnumerable<ChiTietYeuCau>> GetAllCTYC();
        Task<ChiTietYeuCau> GetCTYCById(int id);
        Task DeleteCTYC(int id);
        Task UpdateCTYC(ChiTietYeuCau chitietyc);
    }
}
