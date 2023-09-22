using RecrutamentoApi.Extensions;

namespace RecrutamentoApi.Modelo
{
    public class Curriculo
    {
        public int CandidatoId { get; set; }
        public virtual Candidato Candidato { get; set; }
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
        //public List<string>? TextosDeficiencias { get; private set; }
        public bool DeficienciaFisica { get; set; }
        public bool DeficienciaAuditiva { get; set; }
        public bool DeficienciaVisual { get; set; }
        public bool DeficienciaIntelectual { get; set; }
        public bool DeficienciaAutista { get; set; }
        
        //{
        //    get { return TextosDeficiencias is null ? null : TextosDeficiencias.ConvertAll<Deficiencia>(t => t.ParaDeficiencia()); }
        //    set { TextosDeficiencias = value is null ? null : value.ConvertAll<string>(d => d.ParaString()); }
        //}
        public virtual Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }
        public string LinkedIn { get; set; }
        public virtual List<FormacaoAcademica> FormacoesAcademicas { get; set; }
        public virtual List<Proficiencia> Proficiencias { get; set; }
        public virtual List<Certificacao> Certificacoes { get; set; }
        public virtual List<ExperienciaProfissional> ExperienciasProfissionais { get; set; }
    }
}
