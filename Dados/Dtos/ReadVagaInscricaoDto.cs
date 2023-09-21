using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Dados.Dtos
{
    public class ReadVagaInscricaoDto
    {
        public ReadVagaDto Vaga { get; set; }
        public string StatusInscricao { get; set; }
    }
}
