using RecrutamentoApi.Modelo;

using Newtonsoft.Json;
namespace RecrutamentoApi.Dados.Dtos
{
    public class ReadCertificacaoDto
    {
        public string Titulo { get; set; }
        public string Organizacao { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly DataEmissao { get; set; }
    }
}
