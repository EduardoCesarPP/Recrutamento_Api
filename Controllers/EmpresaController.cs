using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecrutamentoApi.Dados;
using RecrutamentoApi.Dados.Dtos;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpresaController : ControllerBase
    {
        private RecrutamentoContext _context;
        private IMapper _mapper;

        public EmpresaController(RecrutamentoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public IActionResult AdicionaEmpresa([FromBody] CreateEmpresaDto empresaDto)
        {
            Empresa empresa = _mapper.Map<Empresa>(empresaDto);
            _context.Enderecos.Add(empresa.Endereco);
            _context.Empresas.Add(empresa);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEmpresaPorId(int id)
        {
            var empresa = _context.Empresas.FirstOrDefault(empresa => empresa.Id == id);
            if (empresa == null) return NotFound();
            var empresaDto = _mapper.Map<ReadEmpresaDto>(empresa);
            return Ok(empresaDto);
        }

        [HttpGet]
        public IEnumerable<ReadEmpresaDto> RecuperaEmpresas([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadEmpresaDto>>(_context.Empresas.Skip(skip).Take(take).ToList());
        }
    }
}
