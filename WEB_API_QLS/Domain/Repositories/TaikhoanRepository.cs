using Microsoft.EntityFrameworkCore;
using WEB_API_QLS.Domain.Entities;
using WEB_API_QLS.Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API_QLS.Application.Interfaces;
using Microsoft.AspNetCore.JsonPatch;

namespace WEB_API_QLS.Domain.Repositories
{
    public class TaikhoanRepository : ITaikhoanRepository
    {
        private readonly quanlysachContext _context;

        public TaikhoanRepository(quanlysachContext context)
        {
            _context = context;
        }
        public async Task<List<Taikhoan>> Read()
        {
            var taikhoan = await _context.Taikhoans.ToListAsync();
            return taikhoan;
        }
        public async Task<Taikhoan> Findbyid(int id)
        {
            var taikhoanid = await _context.Taikhoans.FirstOrDefaultAsync(x => x.Id == id);
            return taikhoanid;
        }
        public async Task<int> AddItem(Taikhoan taikhoan)
        {
            if (_context.Taikhoans.Where(x => x.Email == taikhoan.Email).FirstOrDefault() != null)
            {
                return 0;
            }
            await _context.SaveChangesAsync();
            _context.Taikhoans.Add(taikhoan);
            await _context.SaveChangesAsync();
            return taikhoan.Id;
        }

        public async Task<int> UpdateItem(Taikhoan taikhoan, int id)
        {
            var tai_khoanid = _context.Taikhoans.First(c => c.Id == id);
            if (tai_khoanid != null)
            {
                tai_khoanid.Username = taikhoan.Username;
                tai_khoanid.Email = taikhoan.Email;
                tai_khoanid.Password= taikhoan.Password;

                if (_context.Taikhoans.Where(x => x.Email == taikhoan.Email).FirstOrDefault() != null)
                {
                    return 0;
                }
                await _context.SaveChangesAsync();
            }
            return tai_khoanid.Id;
        }

        public async Task<int> UpdateItemPatch(JsonPatchDocument taikhoan, int id)
        {
            var tai_khoanid = _context.Taikhoans.First(c => c.Id == id);
            if (tai_khoanid != null)
            {
               taikhoan.ApplyTo(tai_khoanid);
                await _context.SaveChangesAsync();
            }
            return tai_khoanid.Id;
        }
        public void DeleteItem(int id)
        {
            var Id = _context.Taikhoans.Find(id);
            if (Id != null)
            {
                _context.Taikhoans.Remove(Id);
                _context.SaveChanges();
            }
        }
    }
}
