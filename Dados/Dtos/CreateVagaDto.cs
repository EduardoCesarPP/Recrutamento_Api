namespace RecrutamentoApi.Dados.Dtos
{
    public class CreateVagaDto
    {
        public int EmpresaId { get; set; }
        public string Nome { get; set; }
        public string TipoVaga { get; set; }
        public DateOnly DataPublicacao { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public decimal Salario { get; set; }
        public string Descricao { get; set; }
        public string Responsabilidades { get; set; }
        public string Qualificações { get; set; }
        public string Modalidade { get; set; }
    }
}

