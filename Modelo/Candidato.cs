using RecrutamentoApi.Extensions;


namespace RecrutamentoApi.Modelo
{
    public class Candidato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string TextoGenero { get; private set; }
        public virtual Genero Genero
        {
            get { return TextoGenero.ParaGenero(); }
            set { TextoGenero = value.ParaString(); }
        }
        public string TextoRaca { get; private set; }
        public virtual Raca Raca
        {
            get { return TextoRaca.ParaRaca(); }
            set { TextoRaca = value.ParaString(); }
        }
        public List<string>? TextosDeficiencias { get; private set; }
        public virtual List<Deficiencia>? Deficiencias
        {
            get { return TextosDeficiencias is null ? null : TextosDeficiencias.ConvertAll<Deficiencia>(t => t.ParaDeficiencia()); }
            set { TextosDeficiencias = value is null ? null : value.ConvertAll<string>(d => d.ParaString()); }
        }
        public virtual Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }
        public string LinkedIn { get; set; }
        public virtual List<FormacaoAcademica> FormacoesAcademicas { get; set; }
        public virtual List<Proficiencia> Proficiencias { get; set; }
        public virtual List<Certificacao> Certificacoes { get; set; }
        public virtual List<ExperienciaProfissional> ExperienciasProfissionais { get; set; }
        public virtual List<Inscricao> Inscricoes { get; set; }

    }
}