using RecrutamentoApi.Extensions;

namespace RecrutamentoApi.Modelo
{
    public class Inscricao
    {
        public virtual Candidato Candidato { get; set; }
        public int? CandidatoId { get; set; }
        public virtual Vaga Vaga { get; set; }
        public int? VagaId { get; set; }
        public string TextoStatusInscricao { get; set; }
        public virtual StatusInscricao StatusInscricao
        {
            get { return TextoStatusInscricao.ParaStatusInscricao(); }
            set { TextoStatusInscricao = value.ParaString(); }
        }        
    }
}
