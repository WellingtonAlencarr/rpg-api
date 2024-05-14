﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RpgApi.Data;

#nullable disable

namespace RpgApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240416233814_MigracaoUsuario")]
    partial class MigracaoUsuario
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RpgApi.Models.Arma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Dano")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("TB_ARMAS", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Dano = 10,
                            Nome = "Adaga"
                        },
                        new
                        {
                            Id = 2,
                            Dano = 18,
                            Nome = "Arco"
                        },
                        new
                        {
                            Id = 3,
                            Dano = 10,
                            Nome = "Cajado"
                        },
                        new
                        {
                            Id = 4,
                            Dano = 15,
                            Nome = "Espada"
                        },
                        new
                        {
                            Id = 5,
                            Dano = 12,
                            Nome = "Lança"
                        },
                        new
                        {
                            Id = 6,
                            Dano = 12,
                            Nome = "Mangal"
                        },
                        new
                        {
                            Id = 7,
                            Dano = 8,
                            Nome = "Mao"
                        });
                });

            modelBuilder.Entity("RpgApi.Models.Personagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Classe")
                        .HasColumnType("int");

                    b.Property<int>("Defesa")
                        .HasColumnType("int");

                    b.Property<int>("Forca")
                        .HasColumnType("int");

                    b.Property<byte[]>("FotoPersonagem")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Inteligencia")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar");

                    b.Property<int>("PontosVida")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("TB_PERSONAGENS", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Classe = 1,
                            Defesa = 23,
                            Forca = 17,
                            Inteligencia = 33,
                            Nome = "Frodo",
                            PontosVida = 100,
                            UsuarioId = 1
                        },
                        new
                        {
                            Id = 2,
                            Classe = 1,
                            Defesa = 25,
                            Forca = 15,
                            Inteligencia = 30,
                            Nome = "Sam",
                            PontosVida = 100,
                            UsuarioId = 1
                        },
                        new
                        {
                            Id = 3,
                            Classe = 3,
                            Defesa = 21,
                            Forca = 18,
                            Inteligencia = 35,
                            Nome = "Galadriel",
                            PontosVida = 100,
                            UsuarioId = 1
                        },
                        new
                        {
                            Id = 4,
                            Classe = 2,
                            Defesa = 18,
                            Forca = 18,
                            Inteligencia = 37,
                            Nome = "Gandalf",
                            PontosVida = 100,
                            UsuarioId = 1
                        },
                        new
                        {
                            Id = 5,
                            Classe = 1,
                            Defesa = 17,
                            Forca = 20,
                            Inteligencia = 31,
                            Nome = "Hobbit",
                            PontosVida = 100,
                            UsuarioId = 1
                        },
                        new
                        {
                            Id = 6,
                            Classe = 3,
                            Defesa = 13,
                            Forca = 21,
                            Inteligencia = 34,
                            Nome = "Celeborn",
                            PontosVida = 100,
                            UsuarioId = 1
                        },
                        new
                        {
                            Id = 7,
                            Classe = 2,
                            Defesa = 11,
                            Forca = 25,
                            Inteligencia = 35,
                            Nome = "Radagast",
                            PontosVida = 100,
                            UsuarioId = 1
                        });
                });

            modelBuilder.Entity("RpgApi.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataAcesso")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("varbinary(max)");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Perfil")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(200)
                        .HasColumnType("varchar")
                        .HasDefaultValue("Jogador");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("TB_USUARIOS", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "seuEmail@gmail.com",
                            Latitude = 23.520022409999999,
                            Longitude = 46.594498000000002,
                            PasswordHash = new byte[] { 115, 30, 231, 33, 74, 10, 17, 190, 207, 118, 180, 174, 65, 98, 199, 200, 249, 232, 24, 217, 165, 88, 53, 163, 128, 2, 175, 193, 196, 143, 63, 111, 111, 100, 11, 191, 181, 39, 163, 161, 154, 160, 60, 33, 161, 33, 124, 109, 46, 104, 130, 104, 108, 167, 59, 191, 103, 148, 40, 224, 29, 181, 172, 183 },
                            PasswordSalt = new byte[] { 51, 70, 82, 158, 239, 72, 26, 85, 225, 219, 138, 206, 72, 181, 192, 202, 39, 111, 180, 76, 107, 150, 184, 136, 155, 255, 165, 170, 78, 0, 47, 199, 174, 198, 17, 194, 104, 44, 83, 211, 209, 118, 44, 247, 243, 237, 34, 80, 138, 66, 148, 183, 62, 20, 137, 111, 203, 211, 80, 100, 158, 199, 201, 173, 130, 229, 234, 92, 102, 7, 57, 53, 185, 249, 68, 53, 187, 20, 251, 223, 47, 180, 138, 20, 238, 191, 225, 67, 187, 98, 32, 164, 217, 227, 72, 81, 24, 136, 106, 178, 37, 34, 165, 155, 224, 156, 91, 220, 90, 59, 56, 59, 71, 202, 123, 85, 75, 13, 32, 11, 28, 9, 83, 230, 137, 47, 147, 253 },
                            Perfil = "Admin",
                            UserName = "UsuarioAdmin"
                        });
                });

            modelBuilder.Entity("RpgApi.Models.Personagem", b =>
                {
                    b.HasOne("RpgApi.Models.Usuario", "Usuario")
                        .WithMany("Personagens")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("RpgApi.Models.Usuario", b =>
                {
                    b.Navigation("Personagens");
                });
#pragma warning restore 612, 618
        }
    }
}