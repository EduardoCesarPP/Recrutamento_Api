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
    public class CurriculoController : ControllerBase
    {
        private RecrutamentoContext _context;
        private IMapper _mapper;

        public CurriculoController(RecrutamentoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Cadastrar([FromBody] CreateCurriculoDto curriculoDto)
        {
            try
            {
                Curriculo curriculo = _mapper.Map<Curriculo>(curriculoDto);
                _context.Enderecos.Add(curriculo.Endereco);
                _context.Curriculos.Add(curriculo);
                _context.SaveChanges();
                return CreatedAtAction(nameof(RecuperarPorId), new { id = curriculo.CandidatoId }, curriculo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] UpdateCurriculoDto curriculoDto)
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
        public IActionResult Deletar(int id)
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

        [HttpGet("{id}")]
        public IActionResult RecuperarPorId(int id)
        {
            try
            {
                var curriculo = _context.Curriculos.FirstOrDefault(curriculo => curriculo.CandidatoId == id);
                if (curriculo == null) return NotFound();
                var curriculoDto = _mapper.Map<ReadCurriculoDto>(curriculo);
                return Ok(curriculoDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult Listar(
            [FromQuery] int skip = 0,
            [FromQuery] int take = 50,
            [FromQuery] List<string>? nomesIdiomas = null,
            [FromQuery] List<string>? nomesRacas = null,
            [FromQuery] bool? deficienciaVisual = null,

            [FromQuery] bool? deficienciaAuditiva = null,
            [FromQuery] bool? deficienciaAutista = null,
            [FromQuery] bool? deficienciaFisica = null,
            [FromQuery] bool? deficienciaIntelectual = null
            )
        {
            try
            {
                var curriculos = _context.Curriculos.Skip(skip).Take(take).ToList();
                if (nomesIdiomas != null && nomesIdiomas.Count() > 0)
                {
                    curriculos = curriculos.Where(curriculo => curriculo.Proficiencias is not null && curriculo.Proficiencias.Any(proficiencia => nomesIdiomas.Contains(proficiencia.Idioma.Nome))).ToList();
                }
                if (nomesRacas != null && nomesRacas.Count() > 0)
                {
                    curriculos = curriculos.Where(curriculo => nomesRacas.Contains(curriculo.Raca.ParaString())).ToList();
                }
                if (deficienciaAuditiva is not null && (bool)deficienciaAuditiva)
                {
                    curriculos = curriculos.Where(curriculo => curriculo.DeficienciaAuditiva).ToList();
                }
                if (deficienciaAutista is not null && (bool)deficienciaAutista)
                {
                    curriculos = curriculos.Where(curriculo => curriculo.DeficienciaAutista).ToList();
                }
                if (deficienciaFisica is not null && (bool)deficienciaFisica)
                {
                    curriculos = curriculos.Where(curriculo => curriculo.DeficienciaFisica).ToList();
                }
                if (deficienciaVisual is not null && (bool)deficienciaVisual)
                {
                    curriculos = curriculos.Where(curriculo => curriculo.DeficienciaVisual).ToList();
                }
                if (deficienciaIntelectual is not null && (bool)deficienciaIntelectual)
                {
                    curriculos = curriculos.Where(curriculo => curriculo.DeficienciaIntelectual).ToList();
                }
                
                return Ok(_mapper.Map<List<ReadCurriculoDto>>(curriculos));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
