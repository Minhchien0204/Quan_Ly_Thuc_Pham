using DATN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.PhieuYeuCauService
{
    public interface IPhieuYeuCauService
    {
        Task<PhieuYeuCau> CreatePYC(PhieuYeuCau phieuyeucau);
        Task<IEnumerable<PhieuYeuCau>> GetAllPYC();
        Task<PhieuYeuCau> GetByIdPYC(string sophieuyeucau);
        Task DeletePYC(string sophieuyeucau);
        Task UpdatePYC(PhieuYeuCau phieuyeucau);
        Task<IEnumerable<ChiTietYeuCau>> GetDetailPYC(string sophieuyeucau);
    }
}
