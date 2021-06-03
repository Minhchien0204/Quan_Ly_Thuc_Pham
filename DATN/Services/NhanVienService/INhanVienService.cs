using DATN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.NhanVienService
{
    public interface INhanVienService
    {
        Task<IEnumerable<NhanVien>> GetAllNV();
        Task<NhanVien> GetByIdNV(string MaNhanVien);
        Task UpdateNV(NhanVien nhanvien);
        Task DeleteNV(string MaNhanVien);
    }
}
