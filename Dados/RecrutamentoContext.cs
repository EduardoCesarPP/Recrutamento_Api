using Microsoft.EntityFrameworkCore;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Dados
{
    public class RecrutamentoContext : DbContext
    {
        public RecrutamentoContext(DbContextOptions<RecrutamentoContext> opts) : base(opts)
        {

        }
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Certificacao> Certificacoes { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<ExperienciaProfissional> ExperienciasProfissionais { get; set; }
        public DbSet<FormacaoAcademica> FormacoesAcademicas { get; set; }
        public DbSet<Idioma> Idiomas { get; set; }
        public DbSet<Proficiencia> Proficiencias { get; set; }
        public DbSet<Vaga> Vagas { get; set; }
        public DbSet<Inscricao> Inscricoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CandidatoConfiguration());
            modelBuilder.ApplyConfiguration(new EmpresaConfiguration());
            modelBuilder.ApplyConfiguration(new ProficienciasConfiguration());
            modelBuilder.ApplyConfiguration(new VagaConfiguration());
            modelBuilder.ApplyConfiguration(new InscricaoConfiguration());
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                   .HaveConversion<DateOnlyConverter>()
                   .HaveColumnType("date");
        }
    }
}
