using DATN.Data;
using DATN.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.HocSinhService
{
    public class HocSinhService : IHocSinhService
    {
        private readonly DataContext _context;
        public HocSinhService(DataContext context)
        {
            _context = context;
        }

        public async Task<HocSinh> CreateHs(HocSinh hocsinh)
        {
            _context.HocSinhs.Add(hocsinh);
            await _context.SaveChangesAsync();
            return  hocsinh;
        }

        public async Task DeleteHs(int id)
        {
            HocSinh hocsinh = await _context.HocSinhs.FirstAsync(hs => hs.Idhs == id);
            if(hocsinh != null)
            {
                _context.HocSinhs.Remove(hocsinh);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<HocSinh>> GetAllHs()
        {
            return await _context.HocSinhs.ToListAsync();
        }

        public async Task<HocSinh> GetByIdHs(int id)
        {
            return await _context.HocSinhs.FindAsync(id);
        }

        public async Task UpdateHs(HocSinh hocsinh)
        {
            var hs = await _context.HocSinhs.FindAsync(hocsinh.Idhs);
            if (hocsinh.Idhs != hs.Idhs)
            {
                throw new ArgumentNullException();
            }
            if (hs.Idhs == 0)
            {
                throw new ArgumentNullException("ko tim thay hoc sinh");
            }
            if(hocsinh.HoTen != null)
            {
                hs.HoTen = hocsinh.HoTen;
            }
            if(hocsinh.NgaySinh != null)
            {
                hs.NgaySinh = hocsinh.NgaySinh;
            }
            hs.GioiTinh = hocsinh.GioiTinh;
            if(hocsinh.DiaChi != null)
            {
                hs.DiaChi = hocsinh.DiaChi;
            }
            if(hocsinh.DienThoai != null)
            {
                hs.DienThoai = hocsinh.DienThoai;
            }
            if(hocsinh.MaLop != null)
            {
                hs.MaLop = hocsinh.MaLop;
            }
            _context.HocSinhs.Update(hs);
            await _context.SaveChangesAsync();
        }
    }
}
