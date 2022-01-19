using WEB_API_QLS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace WEB_API_QLS.Application.Interfaces
{
    public interface IBandocRepository
    {
        Task<List<Bandoc>> Read();
        Task<Bandoc> Findbyid(int id);
        Task<int> AddItem(Bandoc bandoc);
        void UpdateItem(Bandoc bandoc, int id);
        void DeleteItem(int id);
    }
}
