using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecrutamentoApi.Extensions;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Dados
{
    public class CandidatoConfiguration : IEntityTypeConfiguration<Candidato>
    {
        public void Configure(EntityTypeBuilder<Candidato> builder)
        {
            builder
                .Property(c => c.Nome)
                .IsRequired();

            builder
                .Property(c => c.Sobrenome)
                .IsRequired();

            builder
                .Property(c => c.Email)
                .IsRequired();

            builder
                .Property(c => c.Senha)
                .IsRequired();

            builder
                .HasOne(c => c.Curriculo)
                .WithOne(c => c.Candidato)
                .HasForeignKey<Curriculo>(e => e.CandidatoId)
                .IsRequired(false);
        }
    }
}
