using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Dados.Dtos
{
    public class UpdateCurriculoDto
    {
        public int CandidatoId { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string Genero { get; set; }
        public string Raca { get; set; }
        public Deficiencia Deficiencias { get; set; }
        public CreateEnderecoDto Endereco { get; set; }
        public string LinkedIn { get; set; }
    }
}
