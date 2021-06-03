using DATN.Data;
using DATN.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.ChiTietGiaoService
{
    public class ChiTietGiaoService : IChiTietGiaoService
    {
        private readonly DataContext _context;
        public ChiTietGiaoService(DataContext context)
        {
            _context = context;
        }

        public async Task<ChiTietGiao> Create(ChiTietGiao chitietg)
        {
            _context.ChiTietGiaos.Add(chitietg);
            await _context.SaveChangesAsync();
            return chitietg;
        }

        public async Task DeleteCTG(int id)
        {
            ChiTietGiao ctg = await _context.ChiTietGiaos.FindAsync(id);
            if (ctg != null)
            {
                _context.ChiTietGiaos.Remove(ctg);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ChiTietGiao>> GetAllCTG()
        {
            return await _context.ChiTietGiaos.ToListAsync();
        }

        public async Task<ChiTietGiao> GetByIdCTG(int id)
        {
            return await _context.ChiTietGiaos.FindAsync(id);
        }

        public async Task UpdateCTG(ChiTietGiao chitietg)
        {
            var _ctg = await _context.ChiTietGiaos.FindAsync(chitietg.Id);
            if (_ctg == null)
            {
                throw new ArgumentNullException("khong tim thay chi tiet phieu");
            }
            //update
            _ctg.MaNhaCungCap = chitietg.MaNhaCungCap;
            _ctg.MaThucPham = chitietg.MaThucPham;
            _ctg.SoLuong = chitietg.SoLuong;
            _ctg.DonGia = chitietg.DonGia;
            _context.ChiTietGiaos.Update(_ctg);
            await _context.SaveChangesAsync();
        }
    }
}
