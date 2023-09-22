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

        public IActionResult AdicionaCurriculo([FromBody] CreateCurriculoDto curriculoDto)
        {
            Curriculo curriculo = _mapper.Map<Curriculo>(curriculoDto);
            _context.Enderecos.Add(curriculo.Endereco);
            _context.Curriculos.Add(curriculo);
            _context.SaveChanges();
            return Ok();
        }


        [HttpPut("{id}")]
        public IActionResult AtualizaCurriculo(int id, [FromBody] UpdateCurriculoDto curriculoDto)
        {
            var curriculo = _context.Curriculos.FirstOrDefault(curriculo => curriculo.CandidatoId == id);
            var enderecoAtual = curriculo.Endereco;
            var enderecoNovo = _mapper.Map<>
            if (curriculo == null) return NotFound();
            _mapper.Map(curriculoDto, curriculo);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCurriculo(int id)
        {
            var curriculo = _context.Curriculos.FirstOrDefault(curriculo => curriculo.CandidatoId == id);
            if (curriculo == null) return NotFound();
            _context.Remove(curriculo);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCurriculoPorId(int id)
        {
            var curriculo = _context.Curriculos.FirstOrDefault(curriculo => curriculo.CandidatoId == id);
            if (curriculo == null) return NotFound();
            var curriculoDto = _mapper.Map<ReadCurriculoDto>(curriculo);
            return Ok(curriculoDto);
        }

        [HttpGet]
        public IEnumerable<ReadCurriculoDto> RecuperaCurriculos(
            [FromQuery] int skip = 0,
            [FromQuery] int take = 50,
            [FromQuery] List<string>? nomesIdiomas = null,
            [FromQuery] List<string>? nomesRacas = null,
            [FromQuery] List<string>? nomesDeficiencias = null)
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
            //if (nomesDeficiencias != null && nomesDeficiencias.Count() > 0)
            //{
            //    curriculos = curriculos.Where(curriculo => curriculo.Deficiencias is not null && curriculo.Deficiencias.Any(deficiencia => nomesDeficiencias.Contains(deficiencia.ParaString()))).ToList();

            //    //var aux = new List<Curriculo>(curriculos);
            //    //curriculos.ForEach(curriculo =>
            //    //{
            //    //    nomesDeficiencias.ForEach(nomeDeficiencia =>
            //    //    {
            //    //        if (curriculo.TextosDeficiencias is null || !curriculo.TextosDeficiencias.Contains(nomeDeficiencia))
            //    //        {
            //    //            aux.Remove(curriculo);
            //    //        }
            //    //    });
            //    //});
            //    //curriculos = aux;

            //}

            return _mapper.Map<List<ReadCurriculoDto>>(curriculos);
        }
    }
}
