using Newtonsoft.Json;
namespace RecrutamentoApi.Dados.Dtos
{
    public class UpdateVagaDto
    {
        public string Nome { get; set; }
        public string TipoVaga { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly DataPublicacao { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public decimal Salario { get; set; }
        public string Descricao { get; set; }
        public string Responsabilidades { get; set; }
        public string Qualificacoes { get; set; }
        public string Modalidade { get; set; }
    }
}

