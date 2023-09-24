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
        //public DateOnly DataNascimento { get; set; }
        //public string Genero { get; set; }
        //public string Raca { get; set; }    
        //public List<string>? Deficiencias { get; set; }
        //public CreateEnderecoDto Endereco { get; set; }
        //public string LinkedIn { get; set; }
    }
}
