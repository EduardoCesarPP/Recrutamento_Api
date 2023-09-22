using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecrutamentoApi.Dados;
using RecrutamentoApi.Dados.Dtos;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdmnistradorController : ControllerBase
    {
        private RecrutamentoContext _context;
        private IMapper _mapper;

        public AdmnistradorController(RecrutamentoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public IActionResult Adiciona([FromBody] CreateAdmnistradorDto admnistradorDto)
        {
            try
            {
                Admnistrador admnistrador = _mapper.Map<Admnistrador>(admnistradorDto);
                _context.Admnistradores.Add(admnistrador);
                _context.SaveChanges();
                return CreatedAtAction(nameof(RecuperaPorId), new { id = admnistrador.Id }, admnistrador);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaPorId(int id)
        {
            try
            {
                var admnistrador = _context.Admnistradores.FirstOrDefault(admnistrador => admnistrador.Id == id);
                if (admnistrador == null) return NotFound();
                var admnistradorDto = _mapper.Map<ReadAdmnistradorDto>(admnistrador);
                return Ok(admnistradorDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult Recupera([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            try
            {
                return Ok(_mapper.Map<List<ReadAdmnistradorDto>>(_context.Admnistradores.Skip(skip).Take(take).ToList()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //[HttpGet("login")]
        //public IActionResult Login([FromQuery] string email, [FromQuery] string senha)
        //{
        //    try
        //    {
        //        var admnistrador = _context.Admnistradores.FirstOrDefault(admnistrador => admnistrador.Email == email && admnistrador.Senha == senha);
        //        if (admnistrador == null)
        //        {
        //            Response.StatusCode = 404;
        //        }
        //        return Ok(_mapper.Map<ReadAdmnistradorDto>(admnistrador));
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //}

        [HttpPut("{id}")]
        public IActionResult Atualiza(int id, [FromBody] UpdateAdmnistradorDto curriculoDto)
        {
            try
            {
                var curriculo = _context.Curriculos.FirstOrDefault(curriculo => curriculo.CandidatoId == id);
                if (curriculo == null) return NotFound();
                _mapper.Map(curriculoDto, curriculo);
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deleta(int id)
        {
            try
            {
                var curriculo = _context.Curriculos.FirstOrDefault(curriculo => curriculo.CandidatoId == id);
                if (curriculo == null) return NotFound();
                _context.Remove(curriculo);
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
