using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecrutamentoApi.Dados;
using RecrutamentoApi.Dados.Dtos;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExperienciaProfissionalController : CRUDController<ExperienciaProfissional, CreateExperienciaProfissionalDto, UpdateExperienciaProfissionalDto, ReadExperienciaProfissionalDto>
    {
     
        public ExperienciaProfissionalController(RecrutamentoContext context, IMapper mapper) : base(context, mapper)
        {
         
        }


















        [HttpGet("candidato/{id}")]
        public IActionResult ListarPorCandidato(int id, [FromQuery] int skip = 0, [FromQuery] int take = 50)
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

        protected override void Adicionar(ExperienciaProfissional modelo)
        {
            _context.ExperienciasProfissionais.Add(modelo);
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

        protected override List<ExperienciaProfissional> ObterListaModelo()
        {
            throw new NotImplementedException();
        }

        protected override ExperienciaProfissional? ObterModelo(int id)
        {
            return _context.ExperienciasProfissionais.FirstOrDefault(admnistrador => admnistrador.Id == id);
        }
    }
}
