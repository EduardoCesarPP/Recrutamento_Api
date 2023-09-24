using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecrutamentoApi.Dados;
using RecrutamentoApi.Dados.Dtos;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdmnistradorController : CRUDLogavelController<Admnistrador, CreateAdmnistradorDto, UpdateAdmnistradorDto, ReadAdmnistradorDto>
    {
        public AdmnistradorController(RecrutamentoContext context, IMapper mapper) : base(context, mapper)
        {           
        }

        protected override void Adicionar(Admnistrador modelo)
        {
            _context.Admnistradores.Add(modelo);
        }

        protected override List<Admnistrador> ObterListaModelo()
        {
            return _context.Admnistradores.ToList();
        }

        protected override Admnistrador? ObterModelo(int id)
        {
            return _context.Admnistradores.FirstOrDefault(admnistrador => admnistrador.Id == id);
        }

        protected override Admnistrador ObterModeloLogin(string email, string senha)
        {
            return _context.Admnistradores.FirstOrDefault(candidato => candidato.Email == email && candidato.Senha == senha);
        }
    }
}
