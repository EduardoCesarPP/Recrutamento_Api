using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecrutamentoApi.Dados;
using RecrutamentoApi.Dados.Dtos;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProficienciaController : ControllerBase
    {
        private RecrutamentoContext _context;
        private IMapper _mapper;

        public ProficienciaController(RecrutamentoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public IActionResult AdicionaProficiencia([FromBody] CreateProficienciaDto proficienciaDto)
        {
            Proficiencia proficiencia = _mapper.Map<Proficiencia>(proficienciaDto);
            _context.Proficiencias.Add(proficiencia);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("candidato/{id}")]
        public IEnumerable<ReadProficienciaDto> Listar(int id, [FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadProficienciaDto>>(_context.Curriculos.Where(c => c.CandidatoId == id).FirstOrDefault().Proficiencias.ToList());
        }



        [HttpPost("teste")]
        public IActionResult Teste(Teste teste)
        {
            Console.WriteLine(teste.dadosRM);
            return Ok();
        }
    }
}
