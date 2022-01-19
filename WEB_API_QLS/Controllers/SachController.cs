using Microsoft.AspNetCore.Mvc;
using WEB_API_QLS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using WEB_API_QLS.Application.Interfaces;

namespace WEB_API_QLS.Controllers
{
    [ApiController]
    [Route("qls/[controller]")]
    public class SachController : ControllerBase
    {
        private readonly ISachRepository _sachRepository;
        public SachController(ISachRepository sachRepository)
        {
            _sachRepository = sachRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Sach>>> XemSach()
        {
            var sach = await _sachRepository.Read();
            return Ok(sach);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Sach>> XemSachId([FromRoute] int id)
        {

            var sachid = await _sachRepository.Findbyid(id);
            if (sachid == null)
            {
                return Ok(new { message = "Không tồn tại" });
            }
            return Ok(sachid);
        }
        [HttpPost]
        public async Task<ActionResult<List<Sach>>> ThemSach(Sach sach)
        {

            var sachid = await _sachRepository.AddItem(sach);
            if (sachid == 0)
            {
                return Ok(new { message = " Tên sách đã tồn tại" });
            }
            return Ok(new { message = " Thành công" });
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Sach>> Update([FromRoute] int id, [FromBody] Sach sach)
        {
            var sachid =await _sachRepository.UpdateItem(sach, id);
            if (sachid == 0)
            {
                return Ok(new { message = "Tên sách đã tồn tại" });
            }
            return Ok(new { message = " Thành công" });
        }
        [HttpDelete("{id:int}")]

        public IActionResult Delete([FromRoute] int id)
        {
            _sachRepository.DeleteItem(id);
            return Ok(new { message = " Thành công" });
        }
    }
}
