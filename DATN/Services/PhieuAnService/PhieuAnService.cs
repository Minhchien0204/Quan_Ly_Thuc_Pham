using DATN.Data;
using DATN.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.PhieuAnService
{
    public class PhieuAnService : IPhieuAnService
    {
        private readonly DataContext _context;
        public PhieuAnService(DataContext context)
        {
            _context = context;
        }
        public string SoPhieu()
        {
            string connString = @"Data Source=DESKTOP-FO8QLMB;Initial Catalog=QLThucPham;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string sql = @"SELECT * FROM PhieuAns ";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString;
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string ma = "";
            if (dt.Rows.Count <= 0)
            {
                ma = "SP001";
            }
            else
            {
                int k;
                ma = "SP";
                k = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(2, 3));
                k = k + 1;
                if (k < 10)
                {
                    ma = ma + "00";
                }
                else if (k < 100)
                {
                    ma = ma + "0";
                }
                ma = ma + k.ToString();
            }
            return ma;
        }
        public async Task<PhieuAn> CreatePA(PhieuAn phieuan)
        {
              phieuan.SophieuAn = SoPhieu();
            _context.PhieuAns.Add(phieuan);
            await _context.SaveChangesAsync();
            return phieuan;
        }

        public async Task Delete(string sophieuan)
        {
            PhieuAn pa = await _context.PhieuAns.FindAsync(sophieuan);
            if(pa != null)
            {
                _context.PhieuAns.Remove(pa);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<PhieuAn>> GetAllPA()
        {
            return await _context.PhieuAns.ToListAsync();
        }

        public async Task<PhieuAn> GetByIdPA(string sophieuan)
        {
            return await _context.PhieuAns.FindAsync(sophieuan);
        }

        public async Task UpdatePA(PhieuAn phieuan)
        {
            var _phieuan = await _context.PhieuAns.FindAsync(phieuan.SophieuAn);
            if(_phieuan == null)
            {
                throw new ArgumentNullException("khong tim thay phieu");
            }
            // update
            _phieuan.NgayLap = phieuan.NgayLap;
            _phieuan.SoLuong = phieuan.SoLuong;
            _phieuan.TrangThai = phieuan.TrangThai;
            _phieuan.GhiChu = phieuan.GhiChu;
            _context.PhieuAns.Update(_phieuan);
            await _context.SaveChangesAsync();
        }
    }
}
