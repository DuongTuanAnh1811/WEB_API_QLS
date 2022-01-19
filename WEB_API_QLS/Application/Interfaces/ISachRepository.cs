using WEB_API_QLS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace WEB_API_QLS.Application.Interfaces
{
    public interface ISachRepository
    {
        Task<List<Sach>> Read();
        Task<Sach> Findbyid(int id);
        Task<int> AddItem(Sach sach);
        Task<int> UpdateItem(Sach sach, int id);
        void DeleteItem(int id);
    }
}
