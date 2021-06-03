using DATN.Data;
using DATN.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.DinhLuongMonAnService
{
    public class DinhLuongMAService : IDinhLuongMAService
    {
        private readonly DataContext _context;

        public DinhLuongMAService(DataContext context)
        {
            _context = context;
        }
        public async Task<DinhLuongMonAn> CreateDLMA(DinhLuongMonAn dinhluongma)
        {
            _context.DinhLuongMonAns.Add(dinhluongma);
            await _context.SaveChangesAsync();
            return dinhluongma;
        }

        public async Task DeleteDLMA(int id)
        {
            DinhLuongMonAn dlma = await _context.DinhLuongMonAns.FindAsync(id);
            if( dlma != null )
            {
                _context.DinhLuongMonAns.Remove(dlma);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<DinhLuongMonAn>> GetAllDLMA()
        {
            return await _context.DinhLuongMonAns.ToListAsync();
        }

        public async Task<DinhLuongMonAn> GetById(int id)
        {
            return await _context.DinhLuongMonAns.FindAsync(id);
        }

        public async Task UpdateDLMA(DinhLuongMonAn dinhluongma)
        {
            var _dlma = await _context.DinhLuongMonAns.FindAsync(dinhluongma.Id);
            if(_dlma == null)
            {
               throw new ArgumentNullException("ko tim thay id");
            }
            // update
            _dlma.SoLuong = dinhluongma.SoLuong;
            _context.DinhLuongMonAns.Update(_dlma);
            await _context.SaveChangesAsync();
        }
    }
}
