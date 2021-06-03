using DATN.Data;
using DATN.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.Lop
{
    public class ClassService : IClassService
    {
        private readonly DataContext _context;
        public ClassService(DataContext context)
        {
            _context = context;
        }
        public async Task<Class> CreateClass(Class lop)
        {
            _context.Classes.Add(lop);
            await _context.SaveChangesAsync();
            return lop;
        }

        public async Task Delete(string MaLop)
        {
            Class lop = await _context.Classes.FindAsync(MaLop);
            if (lop != null)
            {
                _context.Classes.Remove(lop);
                await _context.SaveChangesAsync();
            } 
        }

        public async Task<IEnumerable<Class>> GetAllClass()
        {
            return await _context.Classes.ToListAsync();
        }

        public async Task<Class> GetById(string Malop)
        {
            return await _context.Classes.FindAsync(Malop);
        }

        public async Task<IEnumerable<HocSinh>> GetByIdClass(string MaLop)
        {
            return await _context.HocSinhs.Where(hs => hs.MaLop == MaLop).ToListAsync();
        }

        public async Task UpdateClass(Class lop)
        {
            var _lop = await _context.Classes.FindAsync(lop.MaLop);
            if(lop.MaLop == null)
            {
                throw new ArgumentNullException("ko tim thay lop");
            }
            if(lop.TenLop != null)
            {
                _lop.TenLop = lop.TenLop;
            }
            if(lop.SoLuong != 0 )
            {
                _lop.SoLuong = lop.SoLuong;
            }
            _context.Classes.Update(_lop);
            _context.SaveChanges();
        }
    }
}
