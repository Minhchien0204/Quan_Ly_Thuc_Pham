using DATN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.NhaCungCapService
{
    public interface INhaCungCapService
    {
        Task<NhaCungCap> Create(NhaCungCap nhacungcap);
        Task<IEnumerable<NhaCungCap>> GetAllNhaCC();
        Task<NhaCungCap> GetByIdNhaCC(string MaNhaCungCap);
        Task Delete(string MaNhaCungcap);
        Task UpdateNhaCC(NhaCungCap nhacungcap);
    }
}
