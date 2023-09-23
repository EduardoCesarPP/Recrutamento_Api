using RecrutamentoApi.Modelo;

using Newtonsoft.Json;
namespace RecrutamentoApi.Dados.Dtos
{
    public class ReadFormacaoAcademicaDto
    {
        public string NivelFormacao { get; set; }
        public string Curso { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly DataInicio { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly DataFim { get; set; }
    }
}
