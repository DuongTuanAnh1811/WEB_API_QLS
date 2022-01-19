using Microsoft.EntityFrameworkCore;
using WEB_API_QLS.Domain.Entities;
using WEB_API_QLS.Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API_QLS.Application.Interfaces;

namespace WEB_API_QLS.Domain.Repositories
{
    public class QuequanRepository : IQuequanRepository
    {

        private readonly quanlysachContext _context;

        public QuequanRepository(quanlysachContext context)
        {
            _context = context;
        }
        public async Task<List<Quequan>> Read()
        {
            var quequan = await _context.Quequans.ToListAsync();
            return quequan;
        }

        public async Task<int> AddItem(Quequan quequan)
        {
            _context.Quequans.Add(quequan);
            await _context.SaveChangesAsync();
            return quequan.Id;
        }

        public void UpdateItem(Quequan quequan, int id)
        {
            var que_quan = _context.Quequans.First(c => c.Id == id);
            if (que_quan != null)
            {
                que_quan.Quan = quequan.Quan;
                que_quan.Huyen =quequan.Huyen;
                que_quan.Thanhpho =quequan.Thanhpho;
                _context.SaveChanges();
            }
        }
        public void DeleteItem(int id)
        {
            var Id = _context.Quequans.Find(id);
            if (Id != null)
            {
                _context.Quequans.Remove(Id);
                _context.SaveChanges();
            }
        }
    }
}
