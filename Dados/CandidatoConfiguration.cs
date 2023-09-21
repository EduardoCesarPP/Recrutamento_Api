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
                .Property(c => c.DataNascimento)
                .HasColumnType("date");

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
                .Property(c => c.DataNascimento)
                .IsRequired();

            builder
                .Property(c => c.TextoGenero)
                .IsRequired();

            builder
                .Property(c => c.Raca)
                .IsRequired();

            builder
                .Property(c => c.EnderecoId)
                .IsRequired();

            builder
               .HasAlternateKey(c => new { c.Nome, c.Sobrenome });
                       
            builder
                .HasOne(c => c.Endereco)
                .WithMany(e => e.Candidatos);

            builder
                .HasMany(c => c.FormacoesAcademicas)
                .WithOne(f => f.Candidato);

            builder
                .HasMany(c => c.Certificacoes)
                .WithOne(c => c.Candidato);

            builder
                .HasMany(c => c.ExperienciasProfissionais)
                .WithOne(e => e.Candidato);


            builder
                .Property(e => e.TextosDeficiencias)
                .HasConversion(
                    lista => string.Join(",", lista.ToArray()),
                    concat => (string.IsNullOrEmpty(concat) ? null : concat.Split(new[] { ',' })
                        .Cast<string>()
                        .ToList())
            );

            builder.Ignore(c => c.Genero);
            builder.Ignore(c => c.Raca);
            builder.Ignore(c => c.Deficiencias);

        }
    }
}
