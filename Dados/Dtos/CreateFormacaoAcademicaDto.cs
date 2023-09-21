namespace RecrutamentoApi.Dados.Dtos
{
    public class CreateFormacaoAcademicaDto
    {
        public int  CandidatoId { get; set; }
        public string NivelFormacao { get; set; }
        public string Curso { get; set; }
        public DateOnly DataInicio { get; set; }
        public DateOnly DataFim { get; set; }
    }
}
