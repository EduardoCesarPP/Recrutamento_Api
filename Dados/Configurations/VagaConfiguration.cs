using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecrutamentoApi.Extensions;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Dados.Configurations
{
    public class VagaConfiguration : IEntityTypeConfiguration<Vaga>
    {
        public void Configure(EntityTypeBuilder<Vaga> builder)
        {
            builder
                .Property(v => v.DataPublicacao)
                .HasColumnType("date");
        }
    }
}
