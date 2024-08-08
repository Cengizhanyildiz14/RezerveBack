using Business.Interfaces;
using Dtos;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuyuruController : ControllerBase
    {
        private readonly IDuyuruService _service;

        public DuyuruController(IDuyuruService service)
        {
            _service = service;
        }

        [HttpPost("DuyuruEkle")]
        public IActionResult AddDuyuru([FromBody] DuyuruCreateDto duyuruDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // DTO'dan domain modeline dönüşüm
            var duyuru = new Duyuru
            {
                Title = duyuruDto.Title,
                Content = duyuruDto.Content,
                CreatedAt = duyuruDto.Date
            };
            _service.AddDuyuru(duyuru);
            return Ok(duyuru);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDuyuru([FromBody] DuyuruUpdateDto duyuruDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var duyuru = _service.GetDuyuruById(duyuruDTO.Id);
            if (duyuru == null)
            {
                return NotFound("Duyuru bulunamadı");
            }

            duyuru.Title = duyuruDTO.Title;
            duyuru.Content = duyuruDTO.Content;
            duyuru.CreatedAt = duyuruDTO.CreatedAt;

            var result = _service.UpdateDuyuru(duyuru);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("TumDuyurulariGetir")]
        public IActionResult GetAllDuyurular()
        {
            var duyurular = _service.GetAllDuyurular();
            if (!duyurular.Any())
            {
                return NotFound("Herhangi bir duyuru bulunamadı.");
            }

            return Ok(duyurular);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDuyuru(int id)
        {
            try
            {
                _service.DeleteDuyuru(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Duyuru silinemedi");
            }
        }
    }
}
