using Microsoft.AspNetCore.Mvc;
using WEB_API_QLS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using WEB_API_QLS.Application.Interfaces;

namespace WEB_API_QLS.Controllers
{
    [ApiController]
    [Route("qltl/[controller]")]
    public class TheloaiController : ControllerBase
    {
        private readonly ITheloaiRepository _theloaiRepository;

        public TheloaiController(ITheloaiRepository theloaiRepository)
        {
            _theloaiRepository = theloaiRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Theloai>>> XemTheloai()
        {
            var theloai = await _theloaiRepository.Read();
            return Ok(theloai);
        }
        [HttpPost]
        public async Task<ActionResult<List<Theloai>>> ThemTheloai(Theloai theloai)
        {

            var the_loaiid = await _theloaiRepository.AddItem(theloai);
            if(the_loaiid == 0)
            {
                return Ok(new { message = "Thể loại này đã tồn tại" });
            }
             return Ok(new { message = " Thành công" });
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Theloai>>Update([FromRoute] int id, [FromBody] Theloai theloai)
        {
            var the_loai = await _theloaiRepository.UpdateItem(theloai, id);
            if (the_loai == 0)
            {
                return Ok(new { message = "Thể loại này đã tồn tại" });
            }
            return Ok(new { message = " Thành công" });
        }
        [HttpDelete("{id:int}")]

        public IActionResult Delete([FromRoute] int id)
        {
            _theloaiRepository.DeleteItem(id);
            return Ok(new { message = " Thành công" });
        }
    }
}
