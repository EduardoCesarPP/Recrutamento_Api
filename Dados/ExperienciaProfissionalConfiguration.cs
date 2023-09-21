using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Dados
{
    public class ExperienciaProfissionalConfiguration : IEntityTypeConfiguration<ExperienciaProfissional>
    {
        public void Configure(EntityTypeBuilder<ExperienciaProfissional> builder)
        {
            builder
                 .Property(e => e.DataInicio)
                 .HasColumnType("date");

            builder
               .Property(e => e.DataFim)
               .HasColumnType("date");

        }
    }
}
