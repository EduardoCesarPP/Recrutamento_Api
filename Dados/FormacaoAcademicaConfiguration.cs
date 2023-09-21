using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Dados
{
    public class FormacaoAcademicaConfiguration : IEntityTypeConfiguration<FormacaoAcademica>
    {
        public void Configure(EntityTypeBuilder<FormacaoAcademica> builder)
        {
            builder
                 .Property(e => e.DataInicio)
                 .HasColumnType("date");

            builder
               .Property(e => e.DataFim)
               .HasColumnType("date");

            builder
                .Ignore(proficiencia => proficiencia.NivelFormacao);
        }
    }
}
