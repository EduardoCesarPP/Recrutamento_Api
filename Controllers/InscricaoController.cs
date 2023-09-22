using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecrutamentoApi.Dados;
using RecrutamentoApi.Dados.Dtos;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class InscricaoController : ControllerBase
    {
        private RecrutamentoContext _context;
        private IMapper _mapper;

        public InscricaoController(RecrutamentoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public IActionResult AdicionaInscricao([FromBody] CreateInscricaoDto inscricaoDto)
        {
            try
            {
                Inscricao inscricao = _mapper.Map<Inscricao>(inscricaoDto);
                inscricao.StatusInscricao = StatusInscricao.ENVIO_CURRICULO;
                _context.Inscricoes.Add(inscricao);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("candidato/{id}")]
        public IActionResult RecuperaVagasPorCandidato(int id, [FromQuery] int skip = 0, [FromQuery] int take = 50, [FromQuery] string? textoSituacaoInscricao = null)
        {
            try
            {
                var vagas = _context.Inscricoes
                              .Skip(skip)
                              .Take(take)
                              .Where(inscricao => inscricao.CandidatoId == id)
                              .ToList();

                if (!string.IsNullOrEmpty(textoSituacaoInscricao))
                {
                    vagas = vagas.Where(c => c.TextoStatusInscricao == textoSituacaoInscricao).ToList();
                }

                return Ok(_mapper.Map<List<ReadVagaInscricaoDto>>(vagas));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("quantidadeCandidatos/{id}")]
        public IActionResult QuantidadeCandidatosPorVaga(int id)
        {
            try
            {
                var vagas = _context.Inscricoes.Where(inscricao => inscricao.VagaId == id).Distinct().ToList();
                return Ok(vagas.Count);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("vaga/{id}")]
        public IActionResult RecuperaCandidatosPorVaga(int id, [FromQuery] int skip = 0, [FromQuery] int take = 50,
            [FromQuery] string? textoSituacaoInscricao = null)
        {
            try
            {
                var candidatos = _context.Inscricoes
                                    .Skip(skip)
                                    .Take(take)
                                    .Where(inscricao => inscricao.VagaId == id)
                                    .ToList();

                if (!string.IsNullOrEmpty(textoSituacaoInscricao))
                {
                    candidatos = candidatos.Where(c => c.TextoStatusInscricao == textoSituacaoInscricao).ToList();
                }

                return Ok(_mapper.Map<List<ReadCandidatoInscricaoDto>>(candidatos));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public IActionResult AtualizarStatus([FromQuery] int vagaId, [FromQuery] int candidatoId, UpdateInscricaoDto updateInscricaoDto)
        {
            try
            {
                Inscricao inscricao = _context.Inscricoes.Where(i => i.VagaId == vagaId && i.CandidatoId == candidatoId).FirstOrDefault();
                inscricao.TextoStatusInscricao = updateInscricaoDto.StatusInscricao;
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
