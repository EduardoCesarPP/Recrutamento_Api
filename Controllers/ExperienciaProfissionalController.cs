using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecrutamentoApi.Dados;
using RecrutamentoApi.Dados.Dtos;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExperienciaProfissionalController : ControllerBase
    {
        private RecrutamentoContext _context;
        private IMapper _mapper;

        public ExperienciaProfissionalController(RecrutamentoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public IActionResult AdicionaExperienciaProfissional([FromBody] CreateExperienciaProfissionalDto experienciaProfissionalDto)
        {
            ExperienciaProfissional experienciaProfissional = _mapper.Map<ExperienciaProfissional>(experienciaProfissionalDto);
            _context.ExperienciasProfissionais.Add(experienciaProfissional);
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet("candidato/{id}")]
        public IEnumerable<ReadExperienciaProfissionalDto> Listar(int id, [FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadExperienciaProfissionalDto>>(_context.Candidatos.Where(c => c.Id == id).FirstOrDefault().ExperienciasProfissionais.ToList());
        }
    }
}
