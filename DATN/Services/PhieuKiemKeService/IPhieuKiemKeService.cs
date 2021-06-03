using DATN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.PhieuKiemKeService
{
    public interface IPhieuKiemKeService
    {
        Task<PhieuKiemKe> CreatePKK(PhieuKiemKe phieukiemke);
        Task<IEnumerable<PhieuKiemKe>> GetAllPKK();
        Task<PhieuKiemKe> GetByIdPKK(string sophieukiemke);
        Task DeletePKK(string sophieukiemke);
        Task UpdatePKK(PhieuKiemKe phieukiemke);
        Task<IEnumerable<ChiTietKiemKe>> GetDetailPKK(string sophieukiemke);
    }
}
