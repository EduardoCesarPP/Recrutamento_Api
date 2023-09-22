using RecrutamentoApi.Modelo;
using System.ComponentModel.DataAnnotations;

namespace RecrutamentoApi.Dados.Dtos
{
    public class CreateCurriculoDto
    {
       public int CandidatoId { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string Genero { get; set; }
        public string Raca { get; set; }
        public Deficiencias Deficiencias { get; set; }
        public CreateEnderecoDto Endereco { get; set; }
        public string LinkedIn { get; set; }
    }
}
