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
            try
            {
                Proficiencia proficiencia = _mapper.Map<Proficiencia>(proficienciaDto);
                _context.Proficiencias.Add(proficiencia);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("candidato/{id}")]
        public IActionResult Listar(int id, [FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            try
            {
                return Ok(_mapper.Map<List<ReadProficienciaDto>>(_context.Curriculos.Where(c => c.CandidatoId == id).FirstOrDefault().Proficiencias.ToList()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
