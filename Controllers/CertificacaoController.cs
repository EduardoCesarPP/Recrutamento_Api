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

        public IActionResult AdicionaCertificacao([FromBody] CreateCertificacaoDto certificacaoDto)
        {
            Certificacao certificacao = _mapper.Map<Certificacao>(certificacaoDto);
            _context.Certificacoes.Add(certificacao);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("candidato/{id}")]
        public IEnumerable<ReadCertificacaoDto> Listar(int id, [FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadCertificacaoDto>>(_context.Candidatos.Where(c => c.Id == id).FirstOrDefault().Certificacoes.ToList());
        }
    }
}
