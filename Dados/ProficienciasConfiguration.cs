using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Dados
{
   

    public class ProficienciasConfiguration : IEntityTypeConfiguration<Proficiencia>
    {
        public void Configure(EntityTypeBuilder<Proficiencia> builder)
        {

            builder
                .HasKey(proficiencia => new { proficiencia.CandidatoId, proficiencia.IdiomaId });

            // Relação Sessao n:1 Cinema
            builder
                .HasOne(proficiencia => proficiencia.Candidato)
                .WithMany(candidato => candidato.Proficiencias)
                .HasForeignKey(idioma => idioma.CandidatoId);

            // Relação Sessao n:1 Filme
            builder
                .HasOne(proficiencia => proficiencia.Idioma)
                .WithMany(idioma => idioma.Proficiencias)
                .HasForeignKey(candidato => candidato.IdiomaId);

            builder
                .Ignore(proficiencia => proficiencia.NivelProficiencia);
        }
    }
}
