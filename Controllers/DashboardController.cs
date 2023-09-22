using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecrutamentoApi.Dados;
using RecrutamentoApi.Dados.Dtos;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Controllers
{
    public class DashboardController : ControllerBase
    {
        private RecrutamentoContext _context;
        private IMapper _mapper;

        public DashboardController(RecrutamentoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{quantidadeInscricoes}")]
        public IActionResult QuantidadeInscricoes(
            [FromQuery] int? idEmpresa = null,
            [FromQuery] int? idCandidato = null,
            [FromQuery] List<string> listaStatusInscricao = null)
        {
            try
            {
                var inscricoes = _context.Inscricoes.ToList();
                if (idEmpresa is not null)
                {
                    inscricoes = inscricoes.Where(i => i.Vaga.EmpresaId == idEmpresa).ToList();
                }
                if (idCandidato is not null)
                {
                    inscricoes = inscricoes.Where(i => i.CandidatoId == idCandidato).ToList();
                }
                if (listaStatusInscricao is not null && listaStatusInscricao.Count > 0)
                {
                    inscricoes = inscricoes.Where(i => listaStatusInscricao.Contains(i.TextoStatusInscricao)).ToList();
                }

                return Ok(inscricoes is null ? 0 : inscricoes.Count);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{quantidadeCandidatos}")]
        public IActionResult QuantidadeCandidatos(
            [FromQuery] List<string> listaStatusInscricao = null)
        {
            try
            {
                var candidatos = _context.Candidatos.ToList();
                if (listaStatusInscricao is not null && listaStatusInscricao.Count > 0)
                {
                    candidatos = candidatos.Where(c => c.Inscricoes.Any(i => listaStatusInscricao.Contains(i.TextoStatusInscricao))).ToList();
                }

                return Ok(candidatos is null ? 0 : candidatos.Count);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
