using DATN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.DinhLuongMonAnService
{
    public interface IDinhLuongMAService
    {
        Task<DinhLuongMonAn> CreateDLMA(DinhLuongMonAn dinhluongma);
        Task UpdateDLMA(DinhLuongMonAn dinhluongma);
        Task DeleteDLMA(int id);
        Task<IEnumerable<DinhLuongMonAn>> GetAllDLMA();
        Task<DinhLuongMonAn> GetById(int id);
    }
}
