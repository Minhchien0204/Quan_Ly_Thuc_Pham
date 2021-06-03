using DATN.Data;
using DATN.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.PhieuCungCapService
{
    public class PhieuCungCapService : IPhieuCungCapService
    {
        private readonly DataContext _context;
        public PhieuCungCapService(DataContext context)
        {
            _context = context;
        }
        public string SoPhieu()
        {
            string connString = @"Data Source=DESKTOP-FO8QLMB;Initial Catalog=QLThucPham;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string sql = @"SELECT * FROM PhieuCungCaps ";
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
        public async Task<PhieuCungCap> CreatePCC(PhieuCungCap phieucungcau)
        {
            phieucungcau.SoPhieuCugCap = SoPhieu();
            _context.PhieuCungCaps.Add(phieucungcau);
            await _context.SaveChangesAsync();
            return phieucungcau;
        }

        public async Task DeletePCC(string sophieucungcap)
        {
            PhieuCungCap pcc = await _context.PhieuCungCaps.FindAsync(sophieucungcap);
            if (pcc != null)
            {
                _context.PhieuCungCaps.Remove(pcc);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<PhieuCungCap>> GetAllPCC()
        {
            return await _context.PhieuCungCaps.ToListAsync();
        }

        public async Task<PhieuCungCap> GetByIdPYC(string sophieucungcap)
        {
            return await _context.PhieuCungCaps.FindAsync(sophieucungcap);
        }

        public async Task<IEnumerable<ChiTietCungCap>> GetDetailPYC(string sophieucungcap)
        {
            return await _context.ChiTietCungCaps.Where(ctyc => ctyc.SoPhieuCugCap == sophieucungcap).ToListAsync();
        }

        public async Task UpdatePYC(PhieuCungCap phieucungcau)
        {
            var _pcc = await _context.PhieuCungCaps.FindAsync(phieucungcau.SoPhieuCugCap);
            if (_pcc == null)
            {
                throw new ArgumentNullException("khong tim thay phieu");
            }

            //update
            _pcc.MaNhanVien = phieucungcau.MaNhanVien;
            _pcc.NgayLap = phieucungcau.NgayLap;
            _pcc.TrangThai = phieucungcau.TrangThai;
            _pcc.GhiChu = phieucungcau.GhiChu;
            _context.PhieuCungCaps.Update(_pcc);
            await _context.SaveChangesAsync();
        }
    }
}
