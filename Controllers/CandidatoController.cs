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
            _context.Enderecos.Add(candidato.Endereco);
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
            if (nomesIdiomas != null && nomesIdiomas.Count() > 0)
            {
                candidatos = candidatos.Where(candidato => candidato.Proficiencias is not null && candidato.Proficiencias.Any(proficiencia => nomesIdiomas.Contains(proficiencia.Idioma.Nome))).ToList();
            }
            if (nomesRacas != null && nomesRacas.Count() > 0)
            {
                candidatos = candidatos.Where(candidato => nomesRacas.Contains(candidato.Raca.ParaString())).ToList();
            }
            if (nomesDeficiencias != null && nomesDeficiencias.Count() > 0)
            {
                candidatos = candidatos.Where(candidato => candidato.Deficiencias is not null && candidato.Deficiencias.Any(deficiencia => nomesDeficiencias.Contains(deficiencia.ParaString()))).ToList();

                //var aux = new List<Candidato>(candidatos);
                //candidatos.ForEach(candidato =>
                //{
                //    nomesDeficiencias.ForEach(nomeDeficiencia =>
                //    {
                //        if (candidato.TextosDeficiencias is null || !candidato.TextosDeficiencias.Contains(nomeDeficiencia))
                //        {
                //            aux.Remove(candidato);
                //        }
                //    });
                //});
                //candidatos = aux;

            }

            return _mapper.Map<List<ReadCandidatoDto>>(candidatos);
        }
    }
}
