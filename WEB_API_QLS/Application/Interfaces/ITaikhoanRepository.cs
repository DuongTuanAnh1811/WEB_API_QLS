using WEB_API_QLS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;

namespace WEB_API_QLS.Application.Interfaces
{
    public interface ITaikhoanRepository
    {
        Task<List<Taikhoan>> Read();
        Task<Taikhoan> Findbyid(int id);
        Task<int> AddItem(Taikhoan taikhoan);
        Task<int> UpdateItem(Taikhoan taikhoan, int id);
        Task<int> UpdateItemPatch(JsonPatchDocument taikhoan, int id);
        void DeleteItem(int id);
    }
}
