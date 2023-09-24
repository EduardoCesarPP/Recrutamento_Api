using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecrutamentoApi.Dados;
using RecrutamentoApi.Dados.Dtos;
using RecrutamentoApi.Dados.Dtos.Interfaces;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Controllers
{
    public abstract class CRUDController<Tipo, Create, Update, Read> : ControllerBase where Tipo : IIdentificado where Create : ICreateDto where Update : IUpdateDto where Read : IReadDto
    {
        protected RecrutamentoContext _context;
        protected IMapper _mapper;

        public CRUDController(RecrutamentoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <returns>IActionResult</returns>
        /// <response code="201">Caso o registro seja realizado com sucesso</response> 
        /// <response code="400">Caso ocorra algum erro.</response> 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public virtual IActionResult Cadastrar([FromBody] Create createDto)
        {
            Tipo modelo = _mapper.Map<Tipo>(createDto);
            Adicionar(modelo);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarPorId), new { id = modelo.Id }, modelo);
        }
        [HttpGet("{id}")]
        public virtual IActionResult RecuperarPorId(int id)
        {
            var modelo = ObterModelo(id);
            if (modelo == null) return NotFound();
            var readDto = _mapper.Map<Read>(modelo);
            return Ok(readDto);
        }
        [HttpGet]
        public virtual IActionResult Listar([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return Ok(_mapper.Map<List<Read>>(ObterListaModelo().Skip(skip).Take(take)));
        }


        [HttpPut("{id}")]
        public virtual IActionResult Atualizar(int id, [FromBody] Update updateDto)
        {
            var modelo = ObterModelo(id);
            if (modelo == null) return NotFound();
            _mapper.Map(updateDto, modelo);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public virtual IActionResult Deletar(int id)
        {
            try
            {
                var modelo = ObterModelo(id);
                if (modelo == null) return NotFound();
                _context.Remove(modelo);
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //-/////////////////////////////////

        [ApiExplorerSettings(IgnoreApi = true)]
        protected abstract Tipo? ObterModelo(int id);
        [ApiExplorerSettings(IgnoreApi = true)]
        protected abstract List<Tipo> ObterListaModelo();
        [ApiExplorerSettings(IgnoreApi = true)]
        protected abstract void Adicionar(Tipo modelo);
    }
}


