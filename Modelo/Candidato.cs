

namespace RecrutamentoApi.Modelo
{
    public class Candidato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual List<Inscricao> Inscricoes { get; set; }
        public virtual Curriculo Curriculo { get; set; }
    }
}