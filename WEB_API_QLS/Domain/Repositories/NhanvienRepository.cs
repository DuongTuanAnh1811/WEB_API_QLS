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
    public class NhanvienRepository :INhanvienRepository 
    {
        private readonly quanlysachContext _context;

        public NhanvienRepository(quanlysachContext context)
        {
            _context = context;
        }

        public async Task<List<Nhanvien>> Read()
        {
            var nhanvien = await _context.Nhanviens.Include(x => x.Quequan).Include(y => y.Taikhoan).ToListAsync();
            return nhanvien;
        }
        public async Task<Nhanvien> Findbyid(int id)
        {   
            var nhanvien = await _context.Nhanviens.Include(x=>x.Quequan).Include(y=>y.Taikhoan).FirstOrDefaultAsync(x=>x.Id==id);
                return nhanvien;
        }
        public async Task<int> AddItem(Nhanvien nhanvien)
        {
            
            if (_context.Nhanviens.Where(x => x.TaikhoanId == nhanvien.TaikhoanId).FirstOrDefault() != null)
            { 
                return 0;
            }

            _context.Nhanviens.Add(nhanvien);
            await _context.SaveChangesAsync();
            return nhanvien.Id;
        }

        public async Task<int> UpdateItem(Nhanvien nhanvien, int id)
        {
            var nhan_vienid = _context.Nhanviens.First(c => c.Id == id);
            if (nhan_vienid != null)
            {
                nhan_vienid.Ho = nhanvien.Ho;
                nhan_vienid.Ten  = nhanvien.Ten;
                nhan_vienid.Gioitinh = nhanvien.Gioitinh;
                nhan_vienid.Sodienthoai = nhanvien.Sodienthoai;
                nhan_vienid.Ngaysinh= nhanvien.Ngaysinh;
                nhan_vienid.Thangsinh= nhanvien.Thangsinh;
                nhan_vienid.Namsinh = nhanvien.Namsinh;
                nhan_vienid.Chucvu = nhanvien.Chucvu;
                nhan_vienid.QuequanId=nhanvien.QuequanId;
                nhan_vienid.TaikhoanId=nhanvien.TaikhoanId;
                if (_context.Nhanviens.Where(x => x.TaikhoanId == nhanvien.TaikhoanId).FirstOrDefault() != null)
                {
                    return 0;

                }
                await _context.SaveChangesAsync();
            }
            return nhan_vienid.Id;
        }
        public void DeleteItem(int id)
        {
            var Id = _context.Nhanviens.Find(id);
            if (Id != null)
            {
                _context.Nhanviens.Remove(Id);
                _context.SaveChanges();
            }
        }
    }
}
