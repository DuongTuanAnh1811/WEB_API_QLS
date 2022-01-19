using WEB_API_QLS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WEB_API_QLS.Application.Interfaces
{
    public interface IQuequanRepository
    {
        Task<List<Quequan>> Read();
        Task<int> AddItem(Quequan quequan);
        void UpdateItem(Quequan quequan, int id);
        void DeleteItem(int id);
    }
}
