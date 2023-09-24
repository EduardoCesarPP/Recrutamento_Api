using RecrutamentoApi.Dados.Dtos.Interfaces;

namespace RecrutamentoApi.Dados.Dtos
{
    public class CreateInscricaoDto : ICreateDto
    {
        public int CandidatoId { get; set; }
        public int VagaId { get; set; }
    }
}
