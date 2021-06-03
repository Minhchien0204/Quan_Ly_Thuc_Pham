using DATN.Entities;
using DATN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.GiaoVienService
{
    public interface IGiaoVienService
    {
        Task<IEnumerable<GiaoVien>> GetAllGiaoViens();
        Task<GiaoVien> GetByIdGiaoVien(string MaGV);
        //Task<int> DeleteGiaoVien(string magiaovien);
        Task UpdateGiaoVien(GiaoVien giaovien);
        //void DeleteGV(int id);
        Task DeleteGV(string MaGV);
    }
}
