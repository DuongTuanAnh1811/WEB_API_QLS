using Microsoft.EntityFrameworkCore;
using WEB_API_QLS.Domain.Entities;
using WEB_API_QLS.Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API_QLS.Application.Interfaces;
using System;

namespace WEB_API_QLS.Domain.Repositories
{
    public class TheloaiRepository : ITheloaiRepository
    {
        private readonly quanlysachContext _context;

        public TheloaiRepository(quanlysachContext context)
        {
            _context = context;
        }
        public async Task<List<Theloai>> Read()
        {
            var theloai = await _context.Theloais.ToListAsync();
            return theloai;
        }

        public async Task<int> AddItem(Theloai theloai)
        {
            if (_context.Theloais.Where(x => x.TheLoai == theloai.TheLoai).FirstOrDefault() != null)
            {
                return 0;
            }
            _context.Theloais.Add(theloai);
            await _context.SaveChangesAsync();
            return theloai.Id;
        }

        public async Task<int> UpdateItem(Theloai theloai, int id)
        {
            var the_loai =  _context.Theloais.First(c => c.Id == id);
            if (the_loai != null)
            {
                the_loai.TheLoai = theloai.TheLoai;
                if (_context.Theloais.Where(x => x.TheLoai == theloai.TheLoai).FirstOrDefault() != null)
                {
                    return 0;
                }
                await _context.SaveChangesAsync();
            }
            return the_loai.Id;
        }
        public void DeleteItem(int id)
        {
            var Id = _context.Theloais.Find(id);
            if (Id != null)
            {
                _context.Theloais.Remove(Id);
                _context.SaveChanges();
            }
        }
    }
}
