using WEB_API_QLS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace WEB_API_QLS.Application.Interfaces
{
    public interface INhanvienRepository
    {
        Task<List<Nhanvien>> Read();
        Task<Nhanvien>Findbyid(int id);
        Task<int> AddItem(Nhanvien nhanvien);
         Task<int> UpdateItem(Nhanvien nhanvien, int id);
        void DeleteItem(int id);
    }
}
