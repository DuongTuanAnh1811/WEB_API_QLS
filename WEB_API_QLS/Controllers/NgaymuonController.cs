using Microsoft.AspNetCore.Mvc;
using WEB_API_QLS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using WEB_API_QLS.Application.Interfaces;

namespace WEB_API_QLS.Controllers
{
    [ApiController]
    [Route("qlnm/[controller]")]
    public class NgaymuonController : ControllerBase
    {
        private readonly INgaymuonRepository _ngaymuonRepository;

        public NgaymuonController(INgaymuonRepository ngaymuonRepository)
        {
            _ngaymuonRepository = ngaymuonRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Ngaymuon>>> XemNgaymuon()
        {
            var ngaymuon = await _ngaymuonRepository.Read();
            return Ok(ngaymuon);
        }
        [HttpPost]
        public async Task<ActionResult<List<Ngaymuon>>> ThemNgaymuon(Ngaymuon ngaymuon)
        {
            var ngay_muon = await _ngaymuonRepository.AddItem(ngaymuon);
            return Ok(new { message = " Thành công" });
        }
        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute] int id, [FromBody] Ngaymuon ngaymuon)
        {
            _ngaymuonRepository.UpdateItem(ngaymuon, id);
            return Ok(new { message = " Thành công" });
        }
        [HttpDelete("{id:int}")]

        public IActionResult Delete([FromRoute] int id)
        {
            _ngaymuonRepository.DeleteItem(id);
            return Ok(new { message = " Thành công" });
        }
    }
}
