using Microsoft.AspNetCore.Mvc;
using WEB_API_QLS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using WEB_API_QLS.Application.Interfaces;

namespace WEB_API_QLS.Controllers
{
    [ApiController]
    [Route("qlqq/[controller]")]
    public class QuequanController : ControllerBase
    {
        private readonly IQuequanRepository _quequanRepository;

        public QuequanController(IQuequanRepository quequanRepository)
        {
            _quequanRepository = quequanRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Quequan>>> XemQuequan()
        {
            var quequan = await _quequanRepository.Read();
            return Ok(quequan);
        }
        [HttpPost]
        public async Task<ActionResult<List<Quequan>>> ThemQuequan(Quequan quequan)
        {
            var que_quan = await _quequanRepository.AddItem(quequan);
            return Ok(new { message = " Thành công" });
        }
        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute] int id,[FromBody] Quequan quequan)
            {
                _quequanRepository.UpdateItem(quequan, id);
            return Ok(new { message = " Thành công" });
        }
        [HttpDelete("{id:int}")]

        public IActionResult Delete([FromRoute] int id)
        {
            _quequanRepository.DeleteItem(id);
            return Ok(new { message = " Thành công" });
        }
    }
}
