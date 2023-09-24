using Newtonsoft.Json;
using RecrutamentoApi.Dados.Dtos.Interfaces;

namespace RecrutamentoApi.Dados.Dtos
{
    public class CreateFormacaoAcademicaDto : ICreateDto
    {
        public int  CandidatoId { get; set; }
        public string NivelFormacao { get; set; }
        public string Curso { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly DataInicio { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly DataFim { get; set; }
    }
}
