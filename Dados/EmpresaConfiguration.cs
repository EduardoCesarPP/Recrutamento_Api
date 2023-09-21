using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Dados
{


    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder
                .HasOne(e => e.Endereco)
                .WithMany(e => e.Empresas);

            builder
                .Property(e => e.Cnpj)
                .HasMaxLength(14)
                .IsRequired();

            builder
               .Property(e => e.RazaoSocial)
               .IsRequired();

            builder
               .Property(e => e.EnderecoId)
               .IsRequired();

            builder
               .Property(e => e.Email)
               .IsRequired();

            builder
               .Property(e => e.Senha)
               .IsRequired();
        }
    }
}
