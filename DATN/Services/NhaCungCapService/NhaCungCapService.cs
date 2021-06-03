using DATN.Data;
using DATN.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.NhaCungCapService
{
    public class NhaCungCapService : INhaCungCapService
    {
        private readonly DataContext _context;
        public NhaCungCapService(DataContext context)
        {
            _context = context;
        }
        public string MaNhaCungCap()
        {
            string connString = @"Data Source=DESKTOP-FO8QLMB;Initial Catalog=QLThucPham;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string sql = @"SELECT * FROM NhaCungCaps ";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString;
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string ma = "";
            if (dt.Rows.Count <= 0)
            {
                ma = "NCC001";
            }
            else
            {
                int k;
                ma = "NCC";
                k = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(3, 3));
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
        public async Task<NhaCungCap> Create(NhaCungCap nhacungcap)
        {
            nhacungcap.MaNhaCungCap = MaNhaCungCap();
            _context.NhaCungCaps.Add(nhacungcap);
            await _context.SaveChangesAsync();
            return nhacungcap;
        }

        public async Task Delete(string MaNhaCungcap)
        {
            NhaCungCap ncc = await _context.NhaCungCaps.FindAsync(MaNhaCungcap);
            if (ncc != null)
            {
                _context.NhaCungCaps.Remove(ncc);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<NhaCungCap>> GetAllNhaCC()
        {
            return await _context.NhaCungCaps.ToListAsync();
        }

        public async Task<NhaCungCap> GetByIdNhaCC(string MaNhaCungCap)
        {
            return await _context.NhaCungCaps.FindAsync(MaNhaCungCap);
        }

        public async Task UpdateNhaCC(NhaCungCap nhacungcap)
        {
            var ncc = await _context.NhaCungCaps.FindAsync(nhacungcap.MaNhaCungCap);
            if (ncc == null)
            {
                throw new ArgumentNullException("khong tim thay ncc");
            }
            // update
            ncc.TenNhaCungCap = nhacungcap.TenNhaCungCap;
            ncc.DiaChi = nhacungcap.DiaChi;
            ncc.DienThoai = nhacungcap.DienThoai;
            _context.NhaCungCaps.Update(ncc);
            await _context.SaveChangesAsync();
        }
    }
}
