using RecrutamentoApi.Dados.Dtos.Interfaces;

namespace RecrutamentoApi.Dados.Dtos
{
    public class CreateProficienciaDto : ICreateDto
    {
        public int CandidatoId { get; set; }
        public int IdiomaId { get; set; }
        public string NivelProficiencia { get; set; }
    }
}
