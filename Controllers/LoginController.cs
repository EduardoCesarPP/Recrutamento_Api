using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecrutamentoApi.Dados;
using RecrutamentoApi.Dados.Dtos;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Controllers
{
    public class LoginController : ControllerBase
    {
        private RecrutamentoContext _context;
        private IMapper _mapper;

        public LoginController(RecrutamentoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("login")]
        public IActionResult Login([FromQuery] string email, [FromQuery] string senha)
        {
            try
            {
                var candidato = _context.Candidatos.FirstOrDefault(candidato => candidato.Email == email && candidato.Senha == senha);
                Login login = null;
                if (candidato is not null)
                {
                    login = new Login(TipoAcesso.CANDIDATO, candidato.Id);
                }
                else
                {
                    var empresa = _context.Empresas.FirstOrDefault(empresa => empresa.Email == email && empresa.Senha == senha);
                    if (empresa is not null)
                    {
                        login = new Login(TipoAcesso.EMPRESA, empresa.Id);
                    }
                    else
                    {
                        var admninstrador = _context.Admnistradores.FirstOrDefault(admninstrador => admninstrador.Email == email && admninstrador.Senha == senha);
                        if (admninstrador is not null)
                        {
                            login = new Login(TipoAcesso.ADMNINISTRACAO, admninstrador.Id);
                        }
                    }
                }



                if (login is null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<LoginDto>(login));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
