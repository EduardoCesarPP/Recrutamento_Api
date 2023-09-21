﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecrutamentoApi.Dados;

#nullable disable

namespace RecrutamentoApi.Migrations
{
    [DbContext(typeof(RecrutamentoContext))]
    [Migration("20230919210720_Criar_Vaga3")]
    partial class Criar_Vaga3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("RecrutamentoApi.Modelo.Candidato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("LinkedIn")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TextoGenero")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TextoRaca")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TextosDeficiencias")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Candidatos");
                });

            modelBuilder.Entity("RecrutamentoApi.Modelo.Certificacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CandidatoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataEmissao")
                        .HasColumnType("date");

                    b.Property<string>("Organizacao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CandidatoId");

                    b.ToTable("Certificacoes");
                });

            modelBuilder.Entity("RecrutamentoApi.Modelo.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("LinkedIn")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SiteInstitucional")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("RecrutamentoApi.Modelo.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("RecrutamentoApi.Modelo.ExperienciaProfissional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CandidatoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("date");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("date");

                    b.Property<string>("NomeEmpresa")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TipoEmprego")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CandidatoId");

                    b.ToTable("ExperienciasProfissionais");
                });

            modelBuilder.Entity("RecrutamentoApi.Modelo.FormacaoAcademica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CandidatoId")
                        .HasColumnType("int");

                    b.Property<string>("Curso")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("date");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("date");

                    b.Property<string>("Opcao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CandidatoId");

                    b.ToTable("FormacoesAcademicas");
                });

            modelBuilder.Entity("RecrutamentoApi.Modelo.Idioma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Idiomas");
                });

            modelBuilder.Entity("RecrutamentoApi.Modelo.Inscricao", b =>
                {
                    b.Property<int?>("CandidatoId")
                        .HasColumnType("int");

                    b.Property<int?>("VagaId")
                        .HasColumnType("int");

                    b.Property<int>("StatusInscricao")
                        .HasColumnType("int");

                    b.HasKey("CandidatoId", "VagaId");

                    b.HasIndex("VagaId");

                    b.ToTable("Inscricoes");
                });

            modelBuilder.Entity("RecrutamentoApi.Modelo.Proficiencia", b =>
                {
                    b.Property<int?>("CandidatoId")
                        .HasColumnType("int");

                    b.Property<int?>("IdiomaId")
                        .HasColumnType("int");

                    b.HasKey("CandidatoId", "IdiomaId");

                    b.HasIndex("IdiomaId");

                    b.ToTable("Proficiencias");
                });

            modelBuilder.Entity("RecrutamentoApi.Modelo.Vaga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataPublicacao")
                        .HasColumnType("date");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Modalidade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Qualificações")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Responsabilidades")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Salario")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("TextoModalidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TextoTipoVaga")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TipoVaga")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Vagas");
                });

            modelBuilder.Entity("RecrutamentoApi.Modelo.Candidato", b =>
                {
                    b.HasOne("RecrutamentoApi.Modelo.Endereco", "Endereco")
                        .WithMany("Candidatos")
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("RecrutamentoApi.Modelo.Certificacao", b =>
                {
                    b.HasOne("RecrutamentoApi.Modelo.Candidato", "Candidato")
                        .WithMany("Certificacoes")
                        .HasForeignKey("CandidatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidato");
                });

            modelBuilder.Entity("RecrutamentoApi.Modelo.Empresa", b =>
                {
                    b.HasOne("RecrutamentoApi.Modelo.Endereco", "Endereco")
                        .WithMany("Empresas")
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("RecrutamentoApi.Modelo.ExperienciaProfissional", b =>
                {
                    b.HasOne("RecrutamentoApi.Modelo.Candidato", "Candidato")
                        .WithMany("ExperienciasProfissionais")
                        .HasForeignKey("CandidatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidato");
                });

            modelBuilder.Entity("RecrutamentoApi.Modelo.FormacaoAcademica", b =>
                {
                    b.HasOne("RecrutamentoApi.Modelo.Candidato", "Candidato")
                        .WithMany("FormacoesAcademicas")
                        .HasForeignKey("CandidatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidato");
                });

            modelBuilder.Entity("RecrutamentoApi.Modelo.Inscricao", b =>
                {
                    b.HasOne("RecrutamentoApi.Modelo.Candidato", "Candidato")
                        .WithMany("Inscricoes")
                        .HasForeignKey("CandidatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecrutamentoApi.Modelo.Vaga", "Vaga")
                        .WithMany("Inscricoes")
                        .HasForeignKey("VagaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidato");

                    b.Navigation("Vaga");
                });

            modelBuilder.Entity("RecrutamentoApi.Modelo.Proficiencia", b =>
                {
                    b.HasOne("RecrutamentoApi.Modelo.Candidato", "Candidato")
                        .WithMany("Proficiencias")
                        .HasForeignKey("CandidatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecrutamentoApi.Modelo.Idioma", "Idioma")
                        .WithMany("Proficiencias")
                        .HasForeignKey("IdiomaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidato");

                    b.Navigation("Idioma");
                });

            modelBuilder.Entity("RecrutamentoApi.Modelo.Vaga", b =>
                {
                    b.HasOne("RecrutamentoApi.Modelo.Empresa", "Empresa")
                        .WithMany("Vagas")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("RecrutamentoApi.Modelo.Candidato", b =>
                {
                    b.Navigation("Certificacoes");

                    b.Navigation("ExperienciasProfissionais");

                    b.Navigation("FormacoesAcademicas");

                    b.Navigation("Inscricoes");

                    b.Navigation("Proficiencias");
                });

            modelBuilder.Entity("RecrutamentoApi.Modelo.Empresa", b =>
                {
                    b.Navigation("Vagas");
                });

            modelBuilder.Entity("RecrutamentoApi.Modelo.Endereco", b =>
                {
                    b.Navigation("Candidatos");

                    b.Navigation("Empresas");
                });

            modelBuilder.Entity("RecrutamentoApi.Modelo.Idioma", b =>
                {
                    b.Navigation("Proficiencias");
                });

            modelBuilder.Entity("RecrutamentoApi.Modelo.Vaga", b =>
                {
                    b.Navigation("Inscricoes");
                });
#pragma warning restore 612, 618
        }
    }
}
