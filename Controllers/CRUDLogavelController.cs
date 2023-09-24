using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecrutamentoApi.Dados;
using RecrutamentoApi.Dados.Dtos.Interfaces;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Controllers
{
    public abstract class CRUDLogavelController<Tipo, Create, Update, Read> : CRUDCotroller<Tipo, Create, Update, Read> where Tipo : Identificado where Create : ICreateDto where Update : IUpdateDto where Read : IReadDto

    {
        protected CRUDLogavelController(RecrutamentoContext context, IMapper mapper) : base(context, mapper)
        {
        }


        public override abstract void Adicionar(Tipo modelo);

        public override abstract List<Tipo> ObterListaModelo();

        public override abstract Tipo? ObterModelo(int id);
        [HttpGet("login")]
        public IActionResult Logar([FromQuery] string email, [FromQuery] string senha)
        {
            try
            {
                var modelo = ObterModeloLogin(email, senha);
                if (modelo == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<Read>(modelo));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        protected abstract Tipo ObterModeloLogin(string email, string senha);


    }
}
