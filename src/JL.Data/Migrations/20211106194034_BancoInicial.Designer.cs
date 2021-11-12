﻿// <auto-generated />
using JL.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JL.Data.Migrations
{
    [DbContext(typeof(CadastroFuncionarioContext))]
    [Migration("20211106194034_BancoInicial")]
    partial class BancoInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JL.Business.Models.Funcionarios.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("NumeroChapa")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Senha")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.HasKey("Id");

                    b.HasIndex("NumeroChapa")
                        .IsUnique();

                    b.ToTable("Funcionarios");
                });
#pragma warning restore 612, 618
        }
    }
}