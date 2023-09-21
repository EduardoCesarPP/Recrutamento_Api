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
            Inscricao inscricao = _mapper.Map<Inscricao>(inscricaoDto);
            inscricao.StatusInscricao = StatusInscricao.ENVIO_CURRICULO;
            _context.Inscricoes.Add(inscricao);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("candidato/{id}")]
        public IEnumerable<ReadVagaInscricaoDto> RecuperaVagasPorCandidato(int id, [FromQuery] int skip = 0, [FromQuery] int take = 50, [FromQuery] string? textoSituacaoInscricao = null)
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

            return _mapper.Map<List<ReadVagaInscricaoDto>>(vagas);
        }

        [HttpGet("vaga/{id}")]
        public IEnumerable<ReadCandidatoInscricaoDto> RecuperaCandidatosPorVaga(int id, [FromQuery] int skip = 0, [FromQuery] int take = 50,
            [FromQuery] string? textoSituacaoInscricao = null)
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

            return _mapper.Map<List<ReadCandidatoInscricaoDto>>(candidatos);
        }

        [HttpPut]
        public IActionResult AtualizarStatus([FromQuery] int vagaId, [FromQuery] int candidatoId, UpdateInscricaoDto updateInscricaoDto)
        {
            Inscricao inscricao = _context.Inscricoes.Where(i => i.VagaId == vagaId && i.CandidatoId == candidatoId).FirstOrDefault();
            inscricao.TextoStatusInscricao = updateInscricaoDto.StatusInscricao;
            _context.SaveChanges();
            return Ok();
        }
    }
}
