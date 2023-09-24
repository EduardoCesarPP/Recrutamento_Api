using RecrutamentoApi.Dados.Dtos.Interfaces;

namespace RecrutamentoApi.Dados.Dtos
{
    public class ReadCandidatoInscricaoDto : IReadDto
    {
        public ReadCandidatoDto Candidato { get; set; }
        public string StatusInscricao { get; set; }
    }
}
