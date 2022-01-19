using Microsoft.EntityFrameworkCore;
using WEB_API_QLS.Domain.Entities;
using WEB_API_QLS.Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API_QLS.Application.Interfaces;

namespace WEB_API_QLS.Domain.Repositories
{
    public class NgaymuonRepository : INgaymuonRepository
    {
        private readonly quanlysachContext _context;

        public NgaymuonRepository(quanlysachContext context)
        {
            _context = context;
        }
        public async Task<List<Ngaymuon>> Read()
        {
            var ngaymuon = await _context.Ngaymuons.Include(x => x.Sach).Include(y => y.Bandoc).ToListAsync();
            return ngaymuon;
        }

        public async Task<int> AddItem(Ngaymuon ngaymuon)
        {
            _context.Ngaymuons.Add(ngaymuon);
            await _context.SaveChangesAsync();
            return ngaymuon.Id;
        }

        public void UpdateItem(Ngaymuon ngaymuon, int id)
        {
            var ngay_muon = _context.Ngaymuons.First(c => c.Id == id);
            if (ngay_muon != null)
            {
                ngay_muon.NgayMuon = ngaymuon.NgayMuon;
                ngay_muon.SachId = ngaymuon.SachId;
                ngay_muon.BandocId = ngaymuon.BandocId;
                _context.SaveChanges();
            }
        }
        public void DeleteItem(int id)
        {
            var Id = _context.Ngaymuons.Find(id);
            if (Id != null)
            {
                _context.Ngaymuons.Remove(Id);
                _context.SaveChanges();
            }
        }

    }
}
