using DATN.Data;
using DATN.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.PhieuGiaoService
{
    public class PhieuGiaoService : IPhieuGiaoService
    {
        private readonly DataContext _context;
        public PhieuGiaoService(DataContext context)
        {
            _context = context;
        }

        public string SoPhieu()
        {
            string connString = @"Data Source=DESKTOP-FO8QLMB;Initial Catalog=QLThucPham;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string sql = @"SELECT * FROM PhieuGiaos ";
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
        public async Task<PhieuGiao> CreatePG(PhieuGiao phieugiao)
        {
            phieugiao.SoPhieuGiao = SoPhieu();
            _context.PhieuGiaos.Add(phieugiao);
            await _context.SaveChangesAsync();
            return phieugiao;
        }

        public async Task DeletePG(string sophieugiao)
        {
            PhieuGiao pg = await _context.PhieuGiaos.FindAsync(sophieugiao);
            if(pg != null)
            {
                _context.PhieuGiaos.Remove(pg);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<PhieuGiao>> GetAllPG()
        {
            return await _context.PhieuGiaos.ToListAsync();
        }

        public async Task<PhieuGiao> GetByIdPG(string sophieugiao)
        {
            return await _context.PhieuGiaos.FindAsync(sophieugiao);
        }

        public async Task<IEnumerable<ChiTietGiao>> GetDetailPG(string sophieugiao)
        {
            return await _context.ChiTietGiaos.Where(ctg => ctg.SoPhieuGiao == sophieugiao).ToListAsync();
        }

        public async Task UpdatePG(PhieuGiao phieugiao)
        {
            var _pg = await _context.PhieuGiaos.FindAsync(phieugiao.SoPhieuGiao);
            if(_pg == null )
            {
                throw new ArgumentNullException("khong tim thay phieu");
            }

            //update 
            _pg.MaNhanVien = phieugiao.MaNhanVien;
            _pg.NgayLap = phieugiao.NgayLap;
            _pg.GhiChu = phieugiao.GhiChu;
            _pg.SoPhieuCugCap = phieugiao.SoPhieuCugCap;
            _context.PhieuGiaos.Update(_pg);
            await _context.SaveChangesAsync();
        }
    }
}
