using DATN.Data;
using DATN.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.NhanVienService
{
    public class NhanVienService : INhanVienService
    {
        private readonly DataContext _context;
        public NhanVienService(DataContext context)
        {
            _context = context;
        }
        public async Task DeleteNV(string MaNhanVien)
        {
            NhanVien nhanvien = await _context.NhanViens.FirstAsync(nv => nv.MaNhanVien == MaNhanVien);
            if(nhanvien != null)
            {
                User user = await _context.Users.FindAsync(nhanvien.UserId);
                _context.NhanViens.Remove(nhanvien);
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<NhanVien>> GetAllNV()
        {
            return await _context.NhanViens.ToListAsync();
        }

        public async Task<NhanVien> GetByIdNV(string MaNhanVien)
        {
            return await _context.NhanViens.FindAsync(MaNhanVien);
        }

        public async Task UpdateNV(NhanVien nhanvien)
        {
            var user = await _context.Users.FindAsync(nhanvien.UserId);
            var _nhanvien = await _context.NhanViens.FindAsync(nhanvien.MaNhanVien);
            if(_nhanvien.MaNhanVien != nhanvien.MaNhanVien)
            {
                throw new ArgumentNullException();
            }
            if(_nhanvien.MaNhanVien == null)
            {
                throw new ArgumentNullException("ko tim thay giao vien");
            }
            User _user = await _context.Users.FindAsync(_nhanvien.UserId);
            _user.Role = user.Role;
            _context.Users.Update(_user);
            await _context.SaveChangesAsync();
            var userupd = await _context.Users.FindAsync(nhanvien.UserId);
            if(userupd.Role == "NhaBep")
            {
                _nhanvien.MaBoPhan = "NB";
                _context.NhanViens.Update(_nhanvien);
                await _context.SaveChangesAsync();
            }
            if(userupd.Role == "ThucPham")
            {
                _nhanvien.MaBoPhan = "TP";
                _context.NhanViens.Update(_nhanvien);
                await _context.SaveChangesAsync();
            }
        }
    }
}
