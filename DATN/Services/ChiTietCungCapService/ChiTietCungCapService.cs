using DATN.Data;
using DATN.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.ChiTietCungCapService
{
    public class ChiTietCungCapService : IChiTietCungCapService
    {
        private readonly DataContext _context;
        public ChiTietCungCapService(DataContext context)
        {
            _context = context;
        }

        public async Task<ChiTietCungCap> Create(ChiTietCungCap chitietcc)
        {
            _context.ChiTietCungCaps.Add(chitietcc);
            await _context.SaveChangesAsync();
            return chitietcc;
        }

        public async Task DeleteCTCC(int id)
        {
            ChiTietCungCap ctcc = await _context.ChiTietCungCaps.FindAsync(id);
            if (ctcc != null)
            {
                _context.ChiTietCungCaps.Remove(ctcc);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ChiTietCungCap>> GetAllCTCC()
        {
            return await _context.ChiTietCungCaps.ToListAsync();
        }

        public async Task<ChiTietCungCap> GetByIdCTCC(int id)
        {
            return await _context.ChiTietCungCaps.FindAsync(id);
        }

        public async Task UpdateCTCC(ChiTietCungCap chitietcc)
        {
            var _ctcc = await _context.ChiTietCungCaps.FindAsync(chitietcc.Id);
            if (_ctcc == null)
            {
                throw new ArgumentNullException("khong tim thay chi tiet phieu");
            }
            //update
            _ctcc.MaNhaCungCap = chitietcc.MaNhaCungCap;
            _ctcc.MaThucPham = chitietcc.MaThucPham;
            _ctcc.SoLuong = chitietcc.SoLuong;
            _context.ChiTietCungCaps.Update(_ctcc);
            await _context.SaveChangesAsync();
        }
    }
}
