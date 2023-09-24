using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecrutamentoApi.Extensions;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Dados.Configurations
{
    public class InscricaoConfiguration : IEntityTypeConfiguration<Inscricao>
    {
        public void Configure(EntityTypeBuilder<Inscricao> builder)
        {
            builder
                .HasKey(inscricao => new { inscricao.CandidatoId, inscricao.VagaId });

            // Relação Sessao n:1 Cinema
            builder
                .HasOne(inscricao => inscricao.Candidato)
                .WithMany(candidato => candidato.Inscricoes)
                .HasForeignKey(vaga => vaga.CandidatoId);

            // Relação Sessao n:1 Filme
            builder
                .HasOne(proficiencia => proficiencia.Vaga)
                .WithMany(vaga => vaga.Inscricoes)
                .HasForeignKey(candidato => candidato.VagaId);

            builder.Ignore(c => c.StatusInscricao);

        }
    }
}
