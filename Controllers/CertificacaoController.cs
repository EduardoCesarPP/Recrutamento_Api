using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecrutamentoApi.Dados;
using RecrutamentoApi.Dados.Dtos;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CertificacaoController : ControllerBase
    {
        private RecrutamentoContext _context;
        private IMapper _mapper;

        public CertificacaoController(RecrutamentoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public IActionResult Cadastrar([FromBody] CreateCertificacaoDto certificacaoDto)
        {
            try
            {
                Certificacao certificacao = _mapper.Map<Certificacao>(certificacaoDto);
                _context.Certificacoes.Add(certificacao);
                _context.SaveChanges();
                return CreatedAtAction(nameof(Listar), new { id = certificacao.CandidatoId }, certificacao);
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
                return Ok(_mapper.Map<List<ReadCertificacaoDto>>(_context.Curriculos.Where(c => c.CandidatoId == id).FirstOrDefault().Certificacoes.ToList()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
