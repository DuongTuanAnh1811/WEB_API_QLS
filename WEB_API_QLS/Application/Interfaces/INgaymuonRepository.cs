using WEB_API_QLS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace WEB_API_QLS.Application.Interfaces
{
    public interface INgaymuonRepository
    {
        Task<List<Ngaymuon>> Read();
        Task<int> AddItem(Ngaymuon ngaymuon);
        void UpdateItem(Ngaymuon ngaymuon, int id);
        void DeleteItem(int id);
    }
}
