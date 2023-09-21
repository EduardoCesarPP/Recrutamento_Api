using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Dados.Dtos
{
    public class ReadFormacaoAcademicaDto
    {
        public string NivelFormacao { get; set; }
        public string Curso { get; set; }
        public DateOnly DataInicio { get; set; }
        public DateOnly DataFim { get; set; }
    }
}
