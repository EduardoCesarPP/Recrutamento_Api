namespace RecrutamentoApi.Dados.Dtos
{
    public class ReadEmpresaDto
    {
        public int Id { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public ReadEnderecoDto Endereco { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string LinkedIn { get; set; }
        public string SiteInstitucional { get; set; }
    }
}
