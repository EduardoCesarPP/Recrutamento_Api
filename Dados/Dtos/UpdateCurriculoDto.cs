using Newtonsoft.Json;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Dados.Dtos
{
    public class UpdateCurriculoDto
    {
        public int CandidatoId { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly DataNascimento { get; set; }
        public string Genero { get; set; }
        public string Raca { get; set; }
        public Deficiencias Deficiencias { get; set; }
        public CreateEnderecoDto Endereco { get; set; }
        public string LinkedIn { get; set; }
    }
}
