
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Dados.Dtos
{
    public class ReadCurriculoDto
    {
        public ReadCandidatoDto Candidato { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string Genero { get; private set; }
        public string Raca { get; private set; }
        public Deficiencia Deficiencias { get; private set; }
        public ReadEnderecoDto Endereco { get; set; }
        public int EnderecoId { get; set; }
        public string LinkedIn { get; set; }
        public List<ReadFormacaoAcademicaDto> FormacoesAcademicas { get; set; }
        public List<ReadProficienciaDto> Proficiencias { get; set; }
        public List<ReadCertificacaoDto> Certificacoes { get; set; }
        public List<ReadExperienciaProfissionalDto> ExperienciasProfissionais { get; set; }
    }
}
