using DATN.Data;
using DATN.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.PhieuYeuCauService
{
    public class PhieuYeuCauService : IPhieuYeuCauService
    {
        private readonly DataContext _context;
        public PhieuYeuCauService(DataContext context)
        {
            _context = context;
        }

        public string SoPhieu()
        {
            string connString = @"Data Source=DESKTOP-FO8QLMB;Initial Catalog=QLThucPham;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string sql = @"SELECT * FROM PhieuYeuCaus ";
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
        public async Task<PhieuYeuCau> CreatePYC(PhieuYeuCau phieuyeucau)
        {
            phieuyeucau.SoPhieuYeuCau = SoPhieu();
            _context.PhieuYeuCaus.Add(phieuyeucau);
            await _context.SaveChangesAsync();
            return phieuyeucau;
        }

        public async Task DeletePYC(string sophieuyeucau)
        {
            PhieuYeuCau pyc = await _context.PhieuYeuCaus.FindAsync(sophieuyeucau);
            if(pyc != null )
            {
                _context.PhieuYeuCaus.Remove(pyc);
                await _context.SaveChangesAsync();            }
        }

        public async Task<IEnumerable<PhieuYeuCau>> GetAllPYC()
        {
            return await _context.PhieuYeuCaus.ToListAsync();
        }

        public async Task<PhieuYeuCau> GetByIdPYC(string sophieuyeucau)
        {
            return await _context.PhieuYeuCaus.FindAsync(sophieuyeucau);
        }

        public async Task<IEnumerable<ChiTietYeuCau>> GetDetailPYC(string sophieuyeucau)
        {
            return await _context.ChiTietYeuCaus.Where(ctyc => ctyc.SoPhieuYeuCau == sophieuyeucau).ToListAsync();
        }

        public async Task UpdatePYC(PhieuYeuCau phieuyeucau)
        {
            var _pyc = await _context.PhieuYeuCaus.FindAsync(phieuyeucau.SoPhieuYeuCau);
            if (_pyc == null)
            {
                throw new ArgumentNullException("khong tim thay phieu");
            }
            // update
            _pyc.TrangThai = phieuyeucau.TrangThai;
            _pyc.NgayLap = phieuyeucau.NgayLap;
            _pyc.MaNhanVien = phieuyeucau.MaNhanVien;
            _pyc.GhiChu = phieuyeucau.GhiChu;
            _context.PhieuYeuCaus.Update(_pyc);
            await _context.SaveChangesAsync();
        }
    }
}
