using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WEB_API_QLS.Application.Interfaces;
using WEB_API_QLS.Domain.Entities;

namespace WEB_API_QLS.Controllers
{
    [ApiController]
    [Route("qlbd/[controller]")]
    public class BandocController : ControllerBase
    {
        private readonly IBandocRepository _bandocRepository;
        public BandocController(IBandocRepository bandocRepository)
        {
            _bandocRepository = bandocRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Bandoc>>> XemBandoc()
        {
            var bandoc = await _bandocRepository.Read();
            return Ok(bandoc);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Bandoc>> XemBandocId([FromRoute] int id)
        {

            var bandoc = await _bandocRepository.Findbyid(id);
            if (bandoc == null)
            {
                return Ok(new { message = "Không tồn tại" });
            }
            return Ok(bandoc);
        }
        [HttpPost]
        public async Task<ActionResult<List<Bandoc>>> ThemBandoc(Bandoc bandoc)
        {
            var ban_doc = await _bandocRepository.AddItem(bandoc);
            return Ok(new { message = " Thành công" }); 
        }
        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute] int id, [FromBody] Bandoc bandoc)
        {
            _bandocRepository.UpdateItem(bandoc, id);
            return Ok(new { message = " Thành công" });
        }
        [HttpDelete("{id:int}")]

        public IActionResult Delete([FromRoute] int id)
        {
            _bandocRepository.DeleteItem(id);
            return Ok(new { message = " Thành công" });
        }
    }
}
