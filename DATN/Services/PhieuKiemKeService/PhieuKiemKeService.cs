using DATN.Data;
using DATN.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.PhieuKiemKeService
{
    public class PhieuKiemKeService : IPhieuKiemKeService
    {
        private readonly DataContext _context;
        public PhieuKiemKeService(DataContext context)
        {
            _context = context;
        }
        public string SoPhieu()
        {
            string connString = @"Data Source=DESKTOP-FO8QLMB;Initial Catalog=QLThucPham;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string sql = @"SELECT * FROM PhieuKiemKes ";
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
        public async Task<PhieuKiemKe> CreatePKK(PhieuKiemKe phieukiemke)
        {
            phieukiemke.SoPhieuKiemKe = SoPhieu();
            _context.PhieuKiemKes.Add(phieukiemke);
            await _context.SaveChangesAsync();
            return phieukiemke;
        }

        public async Task DeletePKK(string sophieukiemke)
        {
            PhieuKiemKe pkk = await _context.PhieuKiemKes.FindAsync(sophieukiemke);
            if (pkk != null)
            {
                _context.PhieuKiemKes.Remove(pkk);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<PhieuKiemKe>> GetAllPKK()
        {
            return await _context.PhieuKiemKes.ToListAsync();
        }

        public async Task<PhieuKiemKe> GetByIdPKK(string sophieukiemke)
        {
            return await _context.PhieuKiemKes.FindAsync(sophieukiemke);
        }

        public async Task<IEnumerable<ChiTietKiemKe>> GetDetailPKK(string sophieukiemke)
        {
            return await _context.ChiTietKiemKes.Where(ctkk => ctkk.SoPhieuKiemKe == sophieukiemke).ToListAsync();
        }

        public async Task UpdatePKK(PhieuKiemKe phieukiemke)
        {
            var _pkk = await _context.PhieuKiemKes.FindAsync(phieukiemke.SoPhieuKiemKe);
            if (_pkk == null)
            {
                throw new ArgumentNullException("khong tim thay phieu");
            }
            //update
            _pkk.MaNhanVien = phieukiemke.MaNhanVien;
            _pkk.NgayLap = phieukiemke.NgayLap;
            _pkk.GhiChu = phieukiemke.GhiChu;
            _context.PhieuKiemKes.Update(_pkk);
            await _context.SaveChangesAsync();
        }
    }
}
