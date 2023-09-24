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
    public class CandidatoController : CRUDLogavelController<Candidato, CreateCandidatoDto, UpdateCandidatoDto, ReadCandidatoDto>
    {
        public CandidatoController(RecrutamentoContext context, IMapper mapper) : base(context, mapper)
        {

        }

        protected override void Adicionar(Candidato modelo)
        {
            _context.Candidatos.Add(modelo);
        }
        protected override List<Candidato> ObterListaModelo()
        {
            return _context.Candidatos.ToList();
        }
        protected override Candidato? ObterModelo(int id)
        {
            return _context.Candidatos.FirstOrDefault(admnistrador => admnistrador.Id == id);
        }
        protected override Candidato ObterModeloLogin(string email, string senha)
        {
            return _context.Candidatos.FirstOrDefault(candidato => candidato.Email == email && candidato.Senha == senha);
        }

        [HttpGet("listaFiltrada")]
        public new IActionResult ListarComFiltros(
            [FromQuery] int skip = 0,
            [FromQuery] int take = 50,
            [FromQuery] List<string>? nomesIdiomas = null,
            [FromQuery] List<string>? nomesRacas = null,
            [FromQuery] bool? deficienciaVisual = null,
            [FromQuery] bool? deficienciaAuditiva = null,
            [FromQuery] bool? deficienciaAutista = null,
            [FromQuery] bool? deficienciaFisica = null,
            [FromQuery] bool? deficienciaIntelectual = null)
        {
            try
            {
                var candidatos = ObterListaModelo().Skip(skip).Take(take);

                if (nomesIdiomas is not null && nomesIdiomas.Count > 0)
                {
                    candidatos = candidatos.Where(c => c.Curriculo.Proficiencias.Any(p => nomesIdiomas.Contains(p.Idioma.Nome))).ToList();
                }

                if (nomesRacas is not null && nomesRacas.Count > 0)
                {
                    candidatos = candidatos.Where(c => nomesRacas.Contains(c.Curriculo.TextoRaca)).ToList();
                }

                if (deficienciaAuditiva is not null && (bool)deficienciaAuditiva)
                {
                    candidatos = candidatos.Where(c => c.Curriculo.DeficienciaAuditiva).ToList();
                }
                if (deficienciaAutista is not null && (bool)deficienciaAutista)
                {
                    candidatos = candidatos.Where(c => c.Curriculo.DeficienciaAutista).ToList();
                }
                if (deficienciaFisica is not null && (bool)deficienciaFisica)
                {
                    candidatos = candidatos.Where(c => c.Curriculo.DeficienciaFisica).ToList();
                }
                if (deficienciaVisual is not null && (bool)deficienciaVisual)
                {
                    candidatos = candidatos.Where(c => c.Curriculo.DeficienciaVisual).ToList();
                }
                if (deficienciaIntelectual is not null && (bool)deficienciaIntelectual)
                {
                    candidatos = candidatos.Where(c => c.Curriculo.DeficienciaIntelectual).ToList();
                }

                return Ok(_mapper.Map<List<ReadCandidatoDto>>(candidatos));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
