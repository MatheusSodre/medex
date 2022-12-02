﻿// <auto-generated />
using System;
using Medex.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Medex.Migrations
{
    [DbContext(typeof(SistemaTarefasDBContex))]
    [Migration("20221130181424_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Medex.Models.ClienteModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Cpf")
                        .HasColumnType("text")
                        .HasColumnName("cpf");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("bairro");

                    b.Property<string>("Cat")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("cat");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("categoria");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("cep");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("complemento");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("create_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("email");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("character varying(120)")
                        .HasColumnName("endereco");

                    b.Property<string>("Especialidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("especialidade");

                    b.Property<string>("Idioma")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("idioma");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("character varying(120)")
                        .HasColumnName("nome");

                    b.Property<int>("Numero")
                        .HasMaxLength(50)
                        .HasColumnType("integer")
                        .HasColumnName("numero");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("pais");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("sigla");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("character varying(120)")
                        .HasColumnName("sobrenome");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("telefone");

                    b.Property<string>("Tratamento")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("tratamento");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("uf");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("update_at");

                    b.HasKey("Id", "Cpf");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Medex.Models.SolicitacaoModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("cpf");

                    b.Property<string>("DetalhesPrdId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("detalhes_prd_id");

                    b.Property<string>("Frequencia")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("frequencia");

                    b.Property<string>("IntervaloAte")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("intervalo_ate");

                    b.Property<string>("IntervaloDesde")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("intervalo_desde");

                    b.Property<int>("Kit")
                        .HasMaxLength(50)
                        .HasColumnType("integer")
                        .HasColumnName("kit");

                    b.HasKey("Id");

                    b.ToTable("Solicitacao");
                });
#pragma warning restore 612, 618
        }
    }
}
