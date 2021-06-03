using DATN.Data;
using DATN.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.ChiTietBanGiaoService
{
    public class ChiTietBanGiaoService : IChiTietBanGiaoService
    {
        private readonly DataContext _context;
        public ChiTietBanGiaoService(DataContext context)
        {
            _context = context;
        }

        public async Task<ChiTietBanGiao> Create(ChiTietBanGiao chitietbg)
        {
            _context.ChiTietBanGiaos.Add(chitietbg);
            await _context.SaveChangesAsync();
            return chitietbg;
        }

        public async Task DeleteCTBG(int id)
        {
            ChiTietBanGiao ctbg = await _context.ChiTietBanGiaos.FindAsync(id);
            if (ctbg != null)
            {
                _context.ChiTietBanGiaos.Remove(ctbg);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ChiTietBanGiao>> GetAllCTBG()
        {
            return await _context.ChiTietBanGiaos.ToListAsync();
        }

        public async Task<ChiTietBanGiao> GetByIdCTBG(int id)
        {
            return await _context.ChiTietBanGiaos.FindAsync(id);
        }

        public async Task UpdateCTBG(ChiTietBanGiao chitietbg)
        {
            var _ctbg = await _context.ChiTietBanGiaos.FindAsync(chitietbg.Id);
            if (_ctbg == null)
            { 
                throw new ArgumentNullException("khong tim thay chi tiet phieu");
            }
            //update
            _ctbg.MaThucPham = chitietbg.MaThucPham;
            _ctbg.SoLuong = chitietbg.SoLuong;
            _context.ChiTietBanGiaos.Update(_ctbg);
            await _context.SaveChangesAsync();
        }
    }
}
