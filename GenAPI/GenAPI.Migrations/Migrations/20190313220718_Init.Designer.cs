﻿// <auto-generated />
using System;
using GenAPI.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GenAPI.Migrations.Migrations
{
    [DbContext(typeof(GenContextMigration))]
    [Migration("20190313220718_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GenAPI.Domain.Entities.Debtor", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)))
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(255);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("DATETIME");

                    b.Property<decimal>("DebtToDue")
                        .HasColumnType("DECIMAL(10,2)");

                    b.Property<decimal>("DueDebt")
                        .HasColumnType("DECIMAL(10,2)");

                    b.Property<string>("Frontnames")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(85);

                    b.Property<string>("IDCard")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(255);

                    b.Property<decimal>("PositiveBalance")
                        .HasColumnType("DECIMAL(10,2)");

                    b.Property<string>("Surnames")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(85);

                    b.HasKey("ID");

                    b.ToTable("Debtor","dbo");
                });

            modelBuilder.Entity("GenAPI.Domain.Entities.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(255);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(50);

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(255);

                    b.HasKey("ID");

                    b.ToTable("User","dbo");
                });
#pragma warning restore 612, 618
        }
    }
}
