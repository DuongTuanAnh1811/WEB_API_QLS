using Microsoft.AspNetCore.Mvc;
using WEB_API_QLS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using WEB_API_QLS.Application.Interfaces;
using Microsoft.AspNetCore.JsonPatch;

namespace WEB_API_QLS.Controllers
{
    [ApiController]
    [Route("qltk/[controller]")]
    public class TaikhoanController : ControllerBase
    {
        private readonly ITaikhoanRepository _taikhoanRepository;

        public TaikhoanController(ITaikhoanRepository taikhoanRepository)
        {
            _taikhoanRepository = taikhoanRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Taikhoan>>> XemTaikhoan()
        {
            var taikhoan = await _taikhoanRepository.Read();
            return Ok(taikhoan);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Taikhoan>> XemTaikhoanId([FromRoute] int id)
        {

            var tai_khoanid = await _taikhoanRepository.Findbyid(id);
            if (tai_khoanid == null)
            {
                return Ok(new { message = "Không tồn tại" });
            }
            return Ok(tai_khoanid);
        }
        [HttpPost]
        public async Task<ActionResult<List<Taikhoan>>> ThemTaikhoan(Taikhoan taikhoan)
        {
            var tai_khoanid = await _taikhoanRepository.AddItem(taikhoan);
            if (tai_khoanid == 0)
            {
                ModelState.AddModelError("taiKhoan", "Tài khoản đã tồn tại");
                return BadRequest(ModelState);
            }
            return Ok(new { message = " Thành công" });
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Taikhoan>> Update([FromRoute] int id, [FromBody] Taikhoan taikhoan)
        {
            var tai_khoanid = await _taikhoanRepository.UpdateItem(taikhoan, id);
            if (tai_khoanid == 0)
            {
                ModelState.AddModelError("taiKhoan", "Tài khoản đã tồn tại");
                return BadRequest(ModelState);
            }
            return Ok(new { message = " Thành công" });
        }
        [HttpPatch("{id:int}")]
        public async Task<ActionResult<Taikhoan>> UpdatePatch([FromRoute] int id, [FromBody] JsonPatchDocument taikhoan)
        {
            var tai_khoanid = await _taikhoanRepository.UpdateItemPatch(taikhoan, id);
            return Ok(new { message = " Thành công" });
        }
        [HttpDelete("{id:int}")]

        public IActionResult Delete([FromRoute] int id)
        {
            _taikhoanRepository.DeleteItem(id);
            return Ok(new { message = " Thành công" });
        }
    }
}
