using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecrutamentoApi.Dados;
using RecrutamentoApi.Dados.Dtos;
using RecrutamentoApi.Extensions;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidatoController : ControllerBase
    {
        private RecrutamentoContext _context;
        private IMapper _mapper;

        public CandidatoController(RecrutamentoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public IActionResult AdicionaCandidato([FromBody] CreateCandidatoDto candidatoDto)
        {
            Candidato candidato = _mapper.Map<Candidato>(candidatoDto);
            _context.Candidatos.Add(candidato);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCandidatoPorId(int id)
        {
            var candidato = _context.Candidatos.FirstOrDefault(candidato => candidato.Id == id);
            if (candidato == null) return NotFound();
            var candidatoDto = _mapper.Map<ReadCandidatoDto>(candidato);
            return Ok(candidatoDto);
        }

        [HttpGet]
        public IEnumerable<ReadCandidatoDto> RecuperaCandidatos(
            [FromQuery] int skip = 0,
            [FromQuery] int take = 50,
            [FromQuery] List<string>? nomesIdiomas = null,
            [FromQuery] List<string>? nomesRacas = null,
            [FromQuery] List<string>? nomesDeficiencias = null)
        {
            var candidatos = _context.Candidatos.Skip(skip).Take(take).ToList();

            return _mapper.Map<List<ReadCandidatoDto>>(candidatos);
        }
    }
}
