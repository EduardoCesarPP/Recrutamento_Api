using RecrutamentoApi.Extensions;

namespace RecrutamentoApi.Modelo
{
    public class FormacaoAcademica
    {
        public int Id { get; set; }
        public virtual Candidato Candidato { get; set; }
        public int CandidatoId { get; set; }
        public string TextoNivelFormacao { get; private set; }
        public virtual NivelFormacao NivelFormacao
        {
            get { return TextoNivelFormacao.ParaNivelFormacao(); }
            set { TextoNivelFormacao = value.ParaString(); }
        }
        public string Curso { get; set; }
        public DateOnly DataInicio { get; set; }
        public DateOnly DataFim { get; set; }
    }
}
