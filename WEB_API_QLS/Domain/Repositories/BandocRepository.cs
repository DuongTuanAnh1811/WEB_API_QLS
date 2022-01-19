using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API_QLS.Application.Interfaces;
using WEB_API_QLS.Domain.Entities;
using WEB_API_QLS.Infrastructure.Context;

namespace WEB_API_QLS.Domain.Repositories
{
    public class BandocRepository : IBandocRepository
    {
        private readonly quanlysachContext _context;

        public BandocRepository(quanlysachContext context)
        {
            _context = context;
        }
        public async Task<List<Bandoc>> Read()
        {
            var bandoc = await _context.Bandocs.ToListAsync();
            return bandoc;
        }
        public async Task<Bandoc> Findbyid(int id)
        {
            var bandoc = await _context.Bandocs.FirstOrDefaultAsync(x=>x.Id==id);
            return bandoc;
        }
        public async Task<int> AddItem(Bandoc bandoc)
        {
            _context.Bandocs.Add(bandoc);
            await _context.SaveChangesAsync();
            return bandoc.Id;
        }

        public void UpdateItem(Bandoc bandoc, int id)
        {
            var ban_doc = _context.Bandocs.First(c => c.Id == id);
            if(ban_doc != null)
            {
                ban_doc.Ho= bandoc.Ho;
                ban_doc.Ten= bandoc.Ten;
                ban_doc.Gioitinh= bandoc.Gioitinh;
                ban_doc.Ngaysinh= bandoc.Ngaysinh;
                ban_doc.Thangsinh= bandoc.Thangsinh;
                ban_doc.Namsinh= bandoc.Namsinh;
                ban_doc.Sodienthoai =bandoc.Sodienthoai;
                ban_doc.MaSv= bandoc.MaSv;
                _context.SaveChanges();
            }
        }
        public void DeleteItem(int id)
        {
            var Id = _context.Bandocs.Find(id);
            if(Id != null)
            {
                _context.Bandocs.Remove(Id);
                _context.SaveChanges();
            }
        }
    }
}
