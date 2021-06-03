using DATN.Data;
using DATN.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.ChiTietKiemKeService
{
    public class ChiTietKiemKeService : IChiTietKiemKeService
    {
        private readonly DataContext _context;
        public ChiTietKiemKeService(DataContext context)
        {
            _context = context;
        }

        public async Task<ChiTietKiemKe> Create(ChiTietKiemKe chitietkk)
        {
            _context.ChiTietKiemKes.Add(chitietkk);
            await _context.SaveChangesAsync();
            return chitietkk;
        }

        public async Task DeleteCTKK(int id)
        {
            ChiTietKiemKe ctkk = await _context.ChiTietKiemKes.FindAsync(id);
            if (ctkk != null)
            {
                _context.ChiTietKiemKes.Remove(ctkk);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ChiTietKiemKe>> GetAllCTKK()
        {
            return await _context.ChiTietKiemKes.ToListAsync();
        }

        public async Task<ChiTietKiemKe> GetCTKKById(int id)
        {
            return await _context.ChiTietKiemKes.FindAsync(id);
        }

        public async Task UpdateCTKK(ChiTietKiemKe chitietkk)
        {
            var _ctkk = await _context.ChiTietKiemKes.FindAsync(chitietkk.Id);
            if (_ctkk == null)
            {
                throw new ArgumentNullException("khong tim thay chi tiet phieu");
            }
            //update
            _ctkk.MaThucPham = chitietkk.MaThucPham;
            _ctkk.ChatLuong = chitietkk.ChatLuong;
            _ctkk.SoLuong = chitietkk.SoLuong;
            _context.ChiTietKiemKes.Update(_ctkk);
            await _context.SaveChangesAsync();
        }
    }
}
