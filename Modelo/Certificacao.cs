namespace RecrutamentoApi.Modelo
{
    public class Certificacao
    {
        public int Id { get; set; }
        public virtual Curriculo Curriculo { get; set; }
        public int CandidatoId { get; set; }
        public string Titulo { get; set; }
        public string Organizacao { get; set; }
        public DateOnly DataEmissao { get; set; }
    }
}
