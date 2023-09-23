using Newtonsoft.Json;
namespace RecrutamentoApi.Dados.Dtos
{
    public class CreateCertificacaoDto
    {
        public int  CandidatoId { get; set; }
        public string Titulo { get; set; }
        public string Organizacao { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly DataEmissao { get; set; }
    }
}
