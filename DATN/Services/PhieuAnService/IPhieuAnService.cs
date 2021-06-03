using DATN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.PhieuAnService
{
    public interface IPhieuAnService
    {
        Task<PhieuAn> CreatePA(PhieuAn phieuan);
        Task<IEnumerable<PhieuAn>> GetAllPA();
        Task<PhieuAn> GetByIdPA(string sophieuan);
        Task Delete(string sophieuan);
        Task UpdatePA(PhieuAn phieuan);

        
    }
}
