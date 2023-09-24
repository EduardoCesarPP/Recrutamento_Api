using Newtonsoft.Json;
using RecrutamentoApi.Dados.Dtos.Interfaces;

namespace RecrutamentoApi.Dados.Dtos
{
    public class UpdateCertificacaoDto : IUpdateDto
    {
        public int  CandidatoId { get; set; }
        public string Titulo { get; set; }
        public string Organizacao { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly DataEmissao { get; set; }
    }
}
