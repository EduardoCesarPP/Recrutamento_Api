using RecrutamentoApi.Extensions;

namespace RecrutamentoApi.Modelo
{
    public class Vaga
    {
        public int Id { get; set; }
        public virtual Empresa Empresa { get; set; }
        public int EmpresaId { get; set; }
        public string Nome { get; set; }
        public string TextoTipoVaga { get; private set; }
        public virtual TipoVaga TipoVaga
        {
            get { return TextoTipoVaga.ParaTipoVaga(); }
            set { TextoTipoVaga = value.ParaString(); }
        }
            public DateOnly DataPublicacao { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public decimal Salario { get; set; }
        public string Descricao { get; set; }
        public string Responsabilidades { get; set; }
        public string Qualificacoes { get; set; }
        public string TextoModalidade { get; private set; }
        public virtual Modalidade Modalidade
        {
            get { return TextoModalidade.ParaModalidade(); }
            set { TextoModalidade = value.ParaString(); }
        }
        public virtual List<Inscricao> Inscricoes { get; set; }

    }
}
