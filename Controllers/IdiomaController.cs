using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecrutamentoApi.Dados;
using RecrutamentoApi.Dados.Dtos;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IdiomaController : ControllerBase
    {
        private RecrutamentoContext _context;
        private IMapper _mapper;

        public IdiomaController(RecrutamentoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public IActionResult Cadastrar([FromBody] CreateIdiomaDto idiomaDto)
        {
            try
            {
                Idioma idioma = _mapper.Map<Idioma>(idiomaDto);
                _context.Idiomas.Add(idioma);
                _context.SaveChanges();
                return CreatedAtAction(nameof(RecuperarPorId), new { id = idioma.Id }, idioma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("lote")]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public IActionResult CadastrarLote([FromBody] List<CreateIdiomaDto> idiomasDto)
        {
            try
            {
                foreach (var idiomaDto in idiomasDto)
                {
                    Idioma idioma = _mapper.Map<Idioma>(idiomaDto);
                    _context.Idiomas.Add(idioma);
                    _context.SaveChanges();
                }          
                                
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarPorId(int id)
        {
            try
            {
                var idioma = _context.Idiomas.FirstOrDefault(idioma => idioma.Id == id);
                if (idioma == null) return NotFound();
                var idiomaDto = _mapper.Map<ReadIdiomaDto>(idioma);
                return Ok(idiomaDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult Listar([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            try
            {
                return Ok(_mapper.Map<List<ReadIdiomaDto>>(_context.Idiomas.Skip(skip).Take(take).ToList()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

