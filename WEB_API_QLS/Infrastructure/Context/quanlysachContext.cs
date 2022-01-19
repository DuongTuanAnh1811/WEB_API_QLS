    using Microsoft.EntityFrameworkCore;
using WEB_API_QLS.Domain.Entities;
namespace WEB_API_QLS.Infrastructure.Context
{
    public class quanlysachContext :DbContext
    {
        public quanlysachContext(DbContextOptions<quanlysachContext> options)
          : base(options)
        {
        }
        public virtual DbSet<Bandoc> Bandocs { get; set; }
        public virtual DbSet<Ngaymuon> Ngaymuons { get; set; }
        public virtual DbSet<Nhanvien> Nhanviens { get; set; }
        public virtual DbSet<Quequan> Quequans { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<Taikhoan> Taikhoans { get; set; }
        public virtual DbSet<Theloai> Theloais { get; set; }
    }
}
