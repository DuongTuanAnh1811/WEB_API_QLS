using Microsoft.AspNetCore.Mvc;
using WEB_API_QLS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using WEB_API_QLS.Application.Interfaces;

namespace WEB_API_QLS.Controllers
{
    [ApiController]
    [Route("qlnv/[controller]")]
    public class NhanvienController : ControllerBase
    {
        private readonly INhanvienRepository _nhanvienRepository;

        public NhanvienController(INhanvienRepository nhanvienRepository)
        {
            _nhanvienRepository = nhanvienRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Nhanvien>>> XemNhanvien()
        {
            var nhanvien = await _nhanvienRepository.Read();
            return Ok(nhanvien);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Nhanvien>> XemNhanvienId([FromRoute]int id)
        {
            
            var nhanvien = await _nhanvienRepository.Findbyid(id);
            if(nhanvien == null)
            {
                return Ok(new {message = "Không tồn tại"});
            }
            return Ok(nhanvien);
        }
        [HttpPost]
        public async Task<ActionResult<List<Nhanvien>>> ThemNhanvien(Nhanvien nhanvien)
        {
            var nhan_vienId= await _nhanvienRepository.AddItem(nhanvien);
            if (nhan_vienId == 0)
            {
                return Ok(new { message = "Lỗi" });
            }
            return Ok(new { message = " Thành công" });
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Nhanvien>> Update([FromRoute] int id, [FromBody] Nhanvien nhanvien)
        {
            var nhan_vienid = await _nhanvienRepository.UpdateItem(nhanvien, id);
            if (nhan_vienid == 0)
            {
                return Ok(new { message = "Lỗi" });
            }
            return Ok(new { message = " Thành công" });
        }
        
        [HttpDelete("{id:int}")]

        public IActionResult Delete([FromRoute] int id)
        {
            _nhanvienRepository.DeleteItem(id);
            return Ok(new { message = " Thành công" });
        }
    }
}
