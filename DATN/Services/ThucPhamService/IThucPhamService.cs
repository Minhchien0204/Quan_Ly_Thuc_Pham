using DATN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.ThucPhamService
{
    public interface IThucPhamService
    {
        Task<IEnumerable<ThucPham>> GetAllTP();
        Task<ThucPham> CreateTP(ThucPham thucpham);
        Task<ThucPham> GetByteIdTP(string mathucpham);
        Task UpdateTP(ThucPham thucpham);
        Task Delete(string mathucpham);
    }
}
