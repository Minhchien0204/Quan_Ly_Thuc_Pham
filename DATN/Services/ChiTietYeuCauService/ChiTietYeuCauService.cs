using DATN.Data;
using DATN.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.ChiTietYeuCauService
{
    public class ChiTietYeuCauService : IChiTietYCService
    {
        private readonly DataContext _context;
        public ChiTietYeuCauService(DataContext context)
        {
            _context = context;
        }

        public async Task<ChiTietYeuCau> Create(ChiTietYeuCau chitietyc)
        {
            
            _context.ChiTietYeuCaus.Add(chitietyc);
            await _context.SaveChangesAsync();
            return chitietyc;
        }

        public async Task DeleteCTYC(int id)
        {
            ChiTietYeuCau ctyc = await _context.ChiTietYeuCaus.FindAsync(id);
            if(ctyc != null)
            {
                _context.ChiTietYeuCaus.Remove(ctyc);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ChiTietYeuCau>> GetAllCTYC()
        {
            return await _context.ChiTietYeuCaus.ToListAsync();
        }

        public async Task<ChiTietYeuCau> GetCTYCById(int id)
        {
            return await _context.ChiTietYeuCaus.FindAsync(id);
        }

        public async Task UpdateCTYC(ChiTietYeuCau chitietyc)
        {
            var _ctyc = await _context.ChiTietYeuCaus.FindAsync(chitietyc.Id);
            if(_ctyc == null)
            {
                throw new ArgumentNullException("khong tim thay chi tiet phieu");            
            }
            //update
            _ctyc.MaThucPham = chitietyc.MaThucPham;
            _ctyc.SoPhieuYeuCau = chitietyc.SoPhieuYeuCau;
            _ctyc.SoLuong = chitietyc.SoLuong;
            _context.ChiTietYeuCaus.Update(_ctyc);
            await _context.SaveChangesAsync();
        }
    }
}
