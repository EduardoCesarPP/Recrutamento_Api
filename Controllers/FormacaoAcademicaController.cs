using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecrutamentoApi.Dados;
using RecrutamentoApi.Dados.Dtos;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormacaoAcademicaController : CRUDController<FormacaoAcademica, CreateFormacaoAcademicaDto, UpdateFormacaoAcademicaDto, ReadFormacaoAcademicaDto>
    {
        private RecrutamentoContext _context;
        private IMapper _mapper;

        public FormacaoAcademicaController(RecrutamentoContext context, IMapper mapper) : base(context,mapper)
        {
            
        }

        [HttpGet("candidato/{id}")]
        public IActionResult Listar(int id, [FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            try
            {
                return Ok(_mapper.Map<List<ReadFormacaoAcademicaDto>>(_context.Curriculos.Where(c => c.CandidatoId == id).FirstOrDefault().FormacoesAcademicas.ToList()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        protected override void Adicionar(FormacaoAcademica modelo)
        {
            _context.FormacoesAcademicas.Add(modelo);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Listar([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult RecuperarPorId(int id)
        {
            throw new NotImplementedException();

        }

        protected override List<FormacaoAcademica> ObterListaModelo()
        {
            throw new NotImplementedException();
        }

        protected override FormacaoAcademica? ObterModelo(int id)
        {
            return _context.FormacoesAcademicas.FirstOrDefault(admnistrador => admnistrador.Id == id);
        }
    }
}
