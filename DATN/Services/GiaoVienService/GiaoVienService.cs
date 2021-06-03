using DATN.Data;
using DATN.Entities;
using DATN.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.GiaoVienService
{
    public class GiaoVienService : IGiaoVienService
    {
        private readonly DataContext _context;
        public GiaoVienService( DataContext context)
        {
            _context = context;
        }

        public async Task DeleteGiaoVien(string MaGV)
        {
            throw new NotImplementedException();
        }


        public async Task UpdateGiaoVien(GiaoVien giaovien)
        {
            var _giaovien = _context.GiaoViens.Find(giaovien.MaGV);
            if(giaovien.MaGV != _giaovien.MaGV)
            {
                throw new ArgumentNullException();
            }
            if(_giaovien.MaGV == null)
            {
                throw new ArgumentNullException("ko tim thay giao vien");
            }
            //_giaovien.MaGV = giaovien.MaGV;
            _giaovien.NgayVao = giaovien.NgayVao;
            _giaovien.TrinhDo = giaovien.TrinhDo;
            _giaovien.MaLop = giaovien.MaLop;
            _context.GiaoViens.Update(_giaovien);
            _context.SaveChanges();
        }

        public async Task<GiaoVien> GetByIdGiaoVien(string MaGV)
        {
            return await _context.GiaoViens.FindAsync(MaGV);
        }

        public async Task DeleteGV(string MaGV)
        {
            GiaoVien giaovien = _context.GiaoViens.First(gv => gv.MaGV == MaGV);
            if (giaovien != null)
            {
                User user = await _context.Users.FindAsync(giaovien.UserId);
                _context.GiaoViens.Remove(giaovien);
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<GiaoVien>> GetAllGiaoViens()
        {
            return await _context.GiaoViens.ToListAsync();
        }
        /* public void DeleteGV(int id)
 {
     var giaovien = _context.GiaoViens.Find(id);
     if(giaovien != null)
     {
         User user = _context.Users.Find(giaovien.UserId);
         _context.GiaoViens.Remove(giaovien);
         _context.Users.Remove(user);
         _context.SaveChanges();
     }
 }*/
    }
}
