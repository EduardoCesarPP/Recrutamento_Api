using Newtonsoft.Json;

namespace RecrutamentoApi.Dados.Dtos
{
    public class CreateExperienciaProfissionalDto
    {
        public int  CandidatoId { get; set; }
        public string Titulo { get; set; }
        public string TipoEmprego { get; set; }
        public string NomeEmpresa { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly DataInicio { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly DataFim { get; set; }
    }
}
