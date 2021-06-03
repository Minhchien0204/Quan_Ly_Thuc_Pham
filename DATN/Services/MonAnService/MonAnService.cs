using DATN.Data;
using DATN.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.MonAnService
{
    public class MonAnService : IMonAnServiece
    {
        private readonly DataContext _context;
        public MonAnService(DataContext context)
        {
            _context = context;
        }
        public string MaMonAn()
        {
            string connString = @"Data Source=DESKTOP-FO8QLMB;Initial Catalog=QLThucPham;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string sql = @"SELECT * FROM MonAns ";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString;
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string ma = "";
            if (dt.Rows.Count <= 0)
            {
                ma = "MA001";
            }
            else
            {
                int k;
                ma = "MA";
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
        public async Task<MonAn> CreateMA(MonAn monan)
        {
            monan.MaMonAn = MaMonAn();
            _context.MonAns.Add(monan);
            await _context.SaveChangesAsync();
            return monan;
        }

        public async Task DeleteMA(string mamonan)
        {
            MonAn monan = await _context.MonAns.FindAsync(mamonan);
            if(monan != null)
            {
                _context.MonAns.Remove(monan);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MonAn>> GetAllMA()
        {
            return await _context.MonAns.ToListAsync();
        }

        public async Task<MonAn> GetById(string MaMonAn)
        {
            return await _context.MonAns.FindAsync(MaMonAn);
        }

        public async Task<IEnumerable<DinhLuongMonAn>> GetDetalMA(string MaMonAn)
        {
            return await _context.DinhLuongMonAns.Where(dlma => dlma.MaMonAn == MaMonAn).ToListAsync();
        }

        public async Task UpdateMA(MonAn monan)
        {
            var _monan = await _context.MonAns.FindAsync(monan.MaMonAn);
            if(monan == null)
            {
                throw new ArgumentException("Khong tim thay mon an");
            }
            if(monan.MaMonAn != _monan.MaMonAn)
            {
                throw new ArgumentException();
            }
            // update thong tin mon an
            _monan.MaNhanVien = monan.MaNhanVien;
            _monan.TenMonAn = monan.TenMonAn;
            _monan.BuaAn = monan.BuaAn;
            _context.MonAns.Update(_monan);
            await _context.SaveChangesAsync();
        }
    }
}
