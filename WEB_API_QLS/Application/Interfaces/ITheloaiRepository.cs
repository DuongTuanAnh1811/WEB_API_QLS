using WEB_API_QLS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace WEB_API_QLS.Application.Interfaces
{
    public interface ITheloaiRepository
    {
        Task<List<Theloai>> Read();
        Task<int> AddItem(Theloai theloai);
        Task<int> UpdateItem(Theloai theloai, int id);
        void DeleteItem(int id);
    }
}
