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


        /// <summary>
        /// Retorna a quantidade de inscrições com base em uma lista de filtros.
        /// </summary>
        /// <param name="idEmpresa">Utilizado para considerar apenas as inscrições realizadas em vagas de uma empresa específica.</param>
        /// <param name="idCandidato">Utilizado para considerar apenas as inscrições realizadas por um candidato específico.</param>
        /// <param name="listaStatusInscricao">Utilizado para considerar apenas as inscrições que estejam em determinada(s) fases. <br/>Valores permitidos: <br/>"ENVIO_CURRICULO", <br/>"TESTE_DISSERTACAO", <br/>"ANALISE_CURRICULO", <br/>"ENTREVISTA_RH", <br/>"ENTREVISTA_GESTOR", <br/>"FINALIZADA"</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso o registro seja realizado com sucesso</response> 
        /// <response code="400">Caso ocorra algum erro.</response> 
        [HttpGet("quantidadeInscricoes")]
        public IActionResult ConsultarQuantidadeInscricoes(
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


        /// <summary>
        /// Retorna a quantidade de candidatos cadastrados com base em uma lista de filtros.
        /// </summary>
        /// <param name="listaStatusInscricao">Utilizado para considerar apenas os candidatos que contenham alguma inscrição em determinada(s) fases. Valores permitidos: ["ENVIO_CURRICULO", "TESTE_DISSERTACAO", "ANALISE_CURRICULO", "ENTREVISTA_RH", "ENTREVISTA_GESTOR", "FINALIZADA"]</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso o registro seja realizado com sucesso</response> 
        /// <response code="400">Caso ocorra algum erro.</response> 
        [HttpGet("quantidadeCandidatos")]
        public IActionResult ConsultarQuantidadeCandidatos(
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

        /// <summary>
        /// Retorna a quantidade de empresas cadastradas.
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso o registro seja realizado com sucesso</response> 
        /// <response code="400">Caso ocorra algum erro.</response> 
        [HttpGet("quantidadeEmpresas")]
        public IActionResult ConsultarQuantidadeEmpresas()
        {
            try
            {
                var empresas = _context.Empresas.ToList();
                return Ok(empresas is null ? 0 : empresas.Count);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
