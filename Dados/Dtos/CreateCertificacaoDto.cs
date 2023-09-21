namespace RecrutamentoApi.Dados.Dtos
{
    public class CreateCertificacaoDto
    {
        public int  CandidatoId { get; set; }
        public string Titulo { get; set; }
        public string Organizacao { get; set; }
        public DateOnly DataEmissao { get; set; }
    }
}
