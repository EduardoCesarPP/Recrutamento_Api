using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecrutamentoApi.Extensions;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Dados
{
    public class CurriculoConfiguration : IEntityTypeConfiguration<Curriculo>
    {
        public void Configure(EntityTypeBuilder<Curriculo> builder)
        {
            builder
                .Property(c => c.DataNascimento)
                .HasColumnType("date");

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
                .HasOne(c => c.Endereco)
                .WithMany(e => e.Curriculos);

            builder
                .HasMany(c => c.FormacoesAcademicas)
                .WithOne(f => f.Curriculo)
                .HasForeignKey(f => f.CandidatoId);

            builder
                .HasMany(c => c.Certificacoes)
                .WithOne(c => c.Curriculo)
                .HasForeignKey(c => c.CandidatoId);

            builder
                .HasMany(c => c.ExperienciasProfissionais)
                .WithOne(e => e.Curriculo)
                .HasForeignKey(e => e.CandidatoId);

            //builder
            //    .HasOne(c => c.Candidato);

            builder
                .HasKey(c => c.CandidatoId);






            //builder
            //    .Property(e => e.TextosDeficiencias)
            //    .HasConversion(
            //        lista => string.Join(",", lista.ToArray()),
            //        concat => (string.IsNullOrEmpty(concat) ? null : concat.Split(new[] { ',' })
            //            .Cast<string>()
            //            .ToList())
            //);



            builder.Ignore(c => c.Id);
            builder.Ignore(c => c.Genero);
            builder.Ignore(c => c.Raca);
            //builder.Ignore(c => c.Deficiencias);

        }
    }
}
