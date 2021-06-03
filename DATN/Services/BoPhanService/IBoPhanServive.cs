using DATN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.BoPhanService
{
    public interface IBoPhanServive
    {
        Task<BoPhan> CreateBoPhan(BoPhan bophan);
        Task<IEnumerable<BoPhan>> GetBoPhans();
        Task<IEnumerable<NhanVien>> GetBoPhanDetail(string MaBoPhan);
        Task<BoPhan> GetByIdBP(string MaBoPhan);
        Task UpdateBP(BoPhan boPhan);
        Task Delete(string MaBoPhan);
    }
}
