using RecrutamentoApi.Modelo;
using System.ComponentModel.DataAnnotations;

namespace RecrutamentoApi.Dados.Dtos
{
    public class UpdateCandidatoDto
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
