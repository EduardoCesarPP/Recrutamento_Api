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
    public class VagaController : ControllerBase
    {
        private RecrutamentoContext _context;
        private IMapper _mapper;

        public VagaController(RecrutamentoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public IActionResult AdicionaVaga([FromBody] CreateVagaDto vagaDto)
        {
            Vaga vaga = _mapper.Map<Vaga>(vagaDto);
            _context.Vagas.Add(vaga);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaVagaPorId(int id)
        {
            var vaga = _context.Vagas.FirstOrDefault(vaga => vaga.Id == id);
            if (vaga == null) return NotFound();
            var vagaDto = _mapper.Map<ReadVagaDto>(vaga);
            return Ok(vagaDto);
        }

        [HttpGet("empresa/{id}")]
        public IEnumerable<ReadVagaDto> RecuperaVagasPorEmpresa(int id, [FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadVagaDto>>(_context.Vagas.Skip(skip).Take(take).Where(v => v.EmpresaId == id).ToList());
        }
    }
}
