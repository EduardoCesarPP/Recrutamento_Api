using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Dados.Dtos
{
    public class ReadCertificacaoDto
    {
        public string Titulo { get; set; }
        public string Organizacao { get; set; }
        public DateOnly DataEmissao { get; set; }
    }
}
