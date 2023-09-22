using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecrutamentoApi.Dados;
using RecrutamentoApi.Dados.Dtos;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormacaoAcademicaController : ControllerBase
    {
        private RecrutamentoContext _context;
        private IMapper _mapper;

        public FormacaoAcademicaController(RecrutamentoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public IActionResult AdicionaFormacaoAcademica([FromBody] CreateFormacaoAcademicaDto formacaoAcademicaDto)
        {
            FormacaoAcademica formacaoAcademica = _mapper.Map<FormacaoAcademica>(formacaoAcademicaDto);
            _context.FormacoesAcademicas.Add(formacaoAcademica);
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet("candidato/{id}")]
        public IEnumerable<ReadFormacaoAcademicaDto> Listar(int id, [FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadFormacaoAcademicaDto>>(_context.Curriculos.Where(c => c.CandidatoId == id).FirstOrDefault().FormacoesAcademicas.ToList());
        }
    }
}
