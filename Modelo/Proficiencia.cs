using RecrutamentoApi.Extensions;

namespace RecrutamentoApi.Modelo
{
    public class Proficiencia
    {
        public virtual Curriculo Curriculo { get; set; }
        public int? CandidatoId { get; set; }
        public virtual Idioma Idioma { get; set; }
        public int? IdiomaId { get; set; }
        public string TextoNivelProficiencia { get; private set; }
        public virtual NivelProficiencia NivelProficiencia
        {
            get { return TextoNivelProficiencia.ParaNivelProficiencia(); }
            set { TextoNivelProficiencia = value.ParaString(); }
        }
    }
}
