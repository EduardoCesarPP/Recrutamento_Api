using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecrutamentoApi.Dados;
using RecrutamentoApi.Dados.Dtos;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpresaController : CRUDLogavelController<Empresa, CreateEmpresaDto, UpdateEmpresaDto, ReadEmpresaDto>
    {
        public EmpresaController(RecrutamentoContext context, IMapper mapper) : base(context, mapper)
        {

        }

        protected override void Adicionar(Empresa modelo)
        {
            _context.Empresas.Add(modelo);
        }
        protected override List<Empresa> ObterListaModelo()
        {
            return _context.Empresas.ToList();
        }
        protected override Empresa? ObterModelo(int id)
        {
            return _context.Empresas.FirstOrDefault(admnistrador => admnistrador.Id == id);
        }
        protected override Empresa ObterModeloLogin(string email, string senha)
        {
            return _context.Empresas.FirstOrDefault(candidato => candidato.Email == email && candidato.Senha == senha);
        }
    }
}
