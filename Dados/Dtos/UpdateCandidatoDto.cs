using RecrutamentoApi.Dados.Dtos.Interfaces;
using RecrutamentoApi.Modelo;
using System.ComponentModel.DataAnnotations;

namespace RecrutamentoApi.Dados.Dtos
{
    public class UpdateCandidatoDto : IUpdateDto
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
