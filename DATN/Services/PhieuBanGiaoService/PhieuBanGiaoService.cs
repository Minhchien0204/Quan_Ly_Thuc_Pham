using DATN.Data;
using DATN.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.PhieuBanGiaoService
{
    public class PhieuBanGiaoService : IPhieuBanGiaoService
    {
        public readonly DataContext _context;
        public PhieuBanGiaoService(DataContext context)
        {
            _context = context;
        }
        public string SoPhieu()
        {
            string connString = @"Data Source=DESKTOP-FO8QLMB;Initial Catalog=QLThucPham;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string sql = @"SELECT * FROM PhieuBanGiaos ";
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
        public async Task<PhieuBanGiao> CreatePBG(PhieuBanGiao phieubangiao)
        {
            phieubangiao.SoPhieuBanGiao = SoPhieu();
            _context.PhieuBanGiaos.Add(phieubangiao);
            await _context.SaveChangesAsync();
            return phieubangiao;
        }

        public async Task DeletePBG(string sophieubangiao)
        {
            PhieuBanGiao pbg = await _context.PhieuBanGiaos.FindAsync(sophieubangiao);
            if (pbg != null)
            {
                _context.PhieuBanGiaos.Remove(pbg);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<PhieuBanGiao>> GetAllPBG()
        {
            return await _context.PhieuBanGiaos.ToListAsync();
        }

        public async Task<PhieuBanGiao> GetByIdPBG(string sophieubangiao)
        {
            return await _context.PhieuBanGiaos.FindAsync(sophieubangiao);
        }

        public async Task<IEnumerable<ChiTietBanGiao>> GetDetailPBG(string sophieubangiao)
        {
            return await _context.ChiTietBanGiaos.Where(ctg => ctg.SoPhieuBanGiao == sophieubangiao).ToListAsync();
        }

        public async Task UpdatePBG(PhieuBanGiao phieubangiao)
        {
            var _pbg = await _context.PhieuBanGiaos.FindAsync(phieubangiao.SoPhieuBanGiao);
            if (_pbg == null)
            {
                throw new ArgumentNullException("khong tim thay phieu");
            }
            //update
            _pbg.MaNhanVien = phieubangiao.MaNhanVien;
            _pbg.NgayLap = phieubangiao.NgayLap;
            _pbg.SoPhieuYeuCau = phieubangiao.SoPhieuYeuCau;
            _pbg.GhiChu = phieubangiao.GhiChu;
            _context.PhieuBanGiaos.Update(_pbg);
            await _context.SaveChangesAsync();
        }
    }
}
