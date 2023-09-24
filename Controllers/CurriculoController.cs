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
    public class CurriculoController : CRUDController<Curriculo, CreateCurriculoDto, UpdateCurriculoDto, ReadCurriculoDto>
    {


        public CurriculoController(RecrutamentoContext context, IMapper mapper) : base(context, mapper)
        {

        }

        [HttpGet("listaFiltrada")]
        public IActionResult ListarComFiltros(
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
                var curriculos = ObterListaModelo().Skip(skip).Take(take);
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

        protected override Curriculo? ObterModelo(int id)
        {
            return _context.Curriculos.FirstOrDefault(curriculo => curriculo.CandidatoId == id);
        }

        protected override List<Curriculo> ObterListaModelo()
        {
            return _context.Curriculos.ToList();
        }

        protected override void Adicionar(Curriculo modelo)
        {
            _context.Enderecos.Add(modelo.Endereco);
            _context.Curriculos.Add(modelo);
        }
    }
}
