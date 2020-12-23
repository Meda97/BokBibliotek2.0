﻿// <auto-generated />
using System;
using BokBibliotek.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BokBibliotek.Migrations
{
    [DbContext(typeof(BokbibliotekContext))]
    [Migration("20201221161223_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BokBibliotek.Models.Bok", b =>
                {
                    b.Property<int>("BokId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Betyg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Boktitel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Isbn")
                        .HasColumnType("int");

                    b.Property<int>("Utgivningsår")
                        .HasColumnType("int");

                    b.HasKey("BokId");

                    b.ToTable("Bok");
                });

            modelBuilder.Entity("BokBibliotek.Models.BokFörfattare", b =>
                {
                    b.Property<int>("BokId")
                        .HasColumnType("int");

                    b.Property<int>("FörfattareId")
                        .HasColumnType("int");

                    b.HasKey("BokId", "FörfattareId");

                    b.HasIndex("FörfattareId");

                    b.ToTable("BokFörfattare");
                });

            modelBuilder.Entity("BokBibliotek.Models.Boklån", b =>
                {
                    b.Property<int>("BoklånId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BokId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Lånedatum")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("LåntagareId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Returdatum")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("DATEADD(MONTH, 1, GETDATE())");

                    b.Property<bool>("Utlånad")
                        .HasColumnType("bit");

                    b.HasKey("BoklånId");

                    b.HasIndex("BokId");

                    b.HasIndex("LåntagareId");

                    b.ToTable("Boklån");
                });

            modelBuilder.Entity("BokBibliotek.Models.Författare", b =>
                {
                    b.Property<int>("FörfattareId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Författarenamn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FörfattareId");

                    b.ToTable("Författare");
                });

            modelBuilder.Entity("BokBibliotek.Models.Låntagare", b =>
                {
                    b.Property<int>("LåntagareId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Efternamn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Förnamn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LåntagareId");

                    b.ToTable("Låntagare");
                });

            modelBuilder.Entity("BokBibliotek.Models.BokFörfattare", b =>
                {
                    b.HasOne("BokBibliotek.Models.Bok", "Bok")
                        .WithMany("BokFörfattare")
                        .HasForeignKey("BokId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BokBibliotek.Models.Författare", "Författare")
                        .WithMany("BokFörfattare")
                        .HasForeignKey("FörfattareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BokBibliotek.Models.Boklån", b =>
                {
                    b.HasOne("BokBibliotek.Models.Bok", "Bok")
                        .WithMany("Boklån")
                        .HasForeignKey("BokId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BokBibliotek.Models.Låntagare", "Låntagare")
                        .WithMany("Boklån")
                        .HasForeignKey("LåntagareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
