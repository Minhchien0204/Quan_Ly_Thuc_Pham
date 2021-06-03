using DATN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.MonAnService
{
    public interface IMonAnServiece
    {
        Task<MonAn> CreateMA(MonAn monan);
        Task<IEnumerable<MonAn>> GetAllMA();
        Task DeleteMA(string mamonan);
        Task UpdateMA(MonAn monan);
        Task<MonAn> GetById(string MaMonAn);
        Task<IEnumerable<DinhLuongMonAn>> GetDetalMA(string MaMonAn);
    }
}
