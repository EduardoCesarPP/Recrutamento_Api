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
            try
            {
                ExperienciaProfissional experienciaProfissional = _mapper.Map<ExperienciaProfissional>(experienciaProfissionalDto);
                _context.ExperienciasProfissionais.Add(experienciaProfissional);
                _context.SaveChanges();
                return CreatedAtAction(nameof(Listar), new { id = experienciaProfissional.CandidatoId }, experienciaProfissional);
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
                return Ok(_mapper.Map<List<ReadExperienciaProfissionalDto>>(_context.Curriculos.Where(c => c.CandidatoId == id).FirstOrDefault().ExperienciasProfissionais.ToList()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
