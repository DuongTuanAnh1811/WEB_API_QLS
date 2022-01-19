using Microsoft.EntityFrameworkCore;
using WEB_API_QLS.Domain.Entities;
using WEB_API_QLS.Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API_QLS.Application.Interfaces;

namespace WEB_API_QLS.Domain.Repositories
{
    public class SachRepository : ISachRepository
    {
        private readonly quanlysachContext _context;

        public SachRepository(quanlysachContext context)
        {
            _context = context;
        }
        public async Task<List<Sach>> Read()
        {
            var sach = await _context.Saches.Include(x => x.Theloai).ToListAsync();
            return sach;
        }
        public async Task<Sach> Findbyid(int id)
        {
            var sachid = await _context.Saches.Include(x => x.Theloai).FirstOrDefaultAsync(x => x.Id == id);
            return sachid;
        }
        public async Task<int> AddItem(Sach sach)
        {
            if (_context.Saches.Where(x => x.Tensach == sach.Tensach).FirstOrDefault() != null)
            {
                return 0;
            }
            _context.Saches.Add(sach);
            await _context.SaveChangesAsync();
            return sach.Id;
        }

        public async Task<int> UpdateItem(Sach sach, int id)
        {
            var sachid =  _context.Saches.First(c => c.Id == id);
            if (sachid != null)
            {
                sachid.Tensach = sach.Tensach;
                sachid.Soluong = sach.Soluong;
                sachid.Tinhtrang = sach.Tinhtrang;
                sachid.Tacgia = sach.Tacgia;
                sachid.Ngaynhap = sach.Ngaynhap;
                sachid.TheloaiId = sach.TheloaiId;
                //if (_context.Saches.Where(x => x.Tensach == sach.Tensach).FirstOrDefault() != null)
                //{
                //    return 0;
                //}
                await _context.SaveChangesAsync();
            }
            return sachid.Id;
        }
        public void DeleteItem(int id)
        {
            var Id = _context.Saches.Find(id);
            if (Id != null)
            {
                _context.Saches.Remove(Id);
                _context.SaveChanges();
            }
        }
    }
}
