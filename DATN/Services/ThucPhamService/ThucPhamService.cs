using DATN.Data;
using DATN.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.ThucPhamService
{
    public class ThucPhamService : IThucPhamService
    {
        private readonly DataContext _context;
        public ThucPhamService(DataContext context)
        {
            _context = context;
        }
        public string MaThucPham()
        {
            string connString = @"Data Source=DESKTOP-FO8QLMB;Initial Catalog=QLThucPham;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string sql = @"SELECT * FROM ThucPhams ";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString;
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string ma = "";
            if (dt.Rows.Count <= 0)
            {
                ma = "TP001";
            }
            else
            {
                int k;
                ma = "TP";
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
        public async Task<ThucPham> CreateTP(ThucPham thucpham)
        {
            thucpham.MaThucPham = MaThucPham();
            _context.ThucPhams.Add(thucpham);
            await _context.SaveChangesAsync();
            return thucpham;
        }
        public async Task Delete(string mathucpham)
        {
            ThucPham thucpham = await _context.ThucPhams.FindAsync(mathucpham);
            if( thucpham != null )
            {
                _context.ThucPhams.Remove(thucpham);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ThucPham>> GetAllTP()
        {
            return await _context.ThucPhams.ToListAsync();
        }

        public async Task<ThucPham> GetByteIdTP(string mathucpham)
        {
            return await _context.ThucPhams.FindAsync(mathucpham);
        }

        public async Task UpdateTP(ThucPham thucpham)
        {
            var tp = await _context.ThucPhams.FindAsync(thucpham.MaThucPham);
            if(tp == null)
            {
                throw new ArgumentNullException("ko tim thuc pham");
            }
            // update thuc pham
            tp.TenThucPham = thucpham.TenThucPham;
            tp.DonVi = thucpham.DonVi;
            _context.ThucPhams.Update(tp);
            await _context.SaveChangesAsync();
        }
    }
}
