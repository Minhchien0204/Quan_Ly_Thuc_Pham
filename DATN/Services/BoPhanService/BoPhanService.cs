using DATN.Data;
using DATN.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.BoPhanService
{
    public class BoPhanService : IBoPhanServive
    {
        private readonly DataContext _context;
        public BoPhanService(DataContext context)
        {
            _context = context;
        }
        public async Task<BoPhan> CreateBoPhan(BoPhan bophan)
        {
            _context.BoPhans.Add(bophan);
            await _context.SaveChangesAsync();
            return bophan;
        }

        public async Task Delete(string MaBoPhan)
        {
            BoPhan boPhan = await _context.BoPhans.FindAsync(MaBoPhan);
            if(boPhan != null)
            {
                _context.BoPhans.Remove(boPhan);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BoPhan>> GetBoPhans()
        {
            return await _context.BoPhans.ToListAsync();
        }

        public async Task<IEnumerable<NhanVien>> GetBoPhanDetail(string MaBoPhan)
        {
            return await _context.NhanViens.Where(nv => nv.MaBoPhan == MaBoPhan).ToListAsync();
        }

        public async Task UpdateBP(BoPhan boPhan)
        {
            var _bophan = await _context.BoPhans.FindAsync(boPhan.MaBoPhan);
            if(boPhan.TenBoPhan != null)
            {
                _bophan.TenBoPhan = boPhan.TenBoPhan;
            }
            _context.BoPhans.Update(_bophan);
            await _context.SaveChangesAsync();
        }

        public async Task<BoPhan> GetByIdBP(string MaBoPhan)
        {
            return await _context.BoPhans.FindAsync(MaBoPhan);
        }
    }
}
