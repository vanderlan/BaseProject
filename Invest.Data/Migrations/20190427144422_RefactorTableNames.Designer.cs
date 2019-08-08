﻿// <auto-generated />
using System;
using Invest.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Invest.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190427144422_RefactorTableNames")]
    partial class RefactorTableNames
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Invest.Entities.Domain.Asset", b =>
                {
                    b.Property<int>("AssetId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<string>("Details");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Logo");

                    b.Property<decimal>("Price");

                    b.Property<int>("SectorId");

                    b.Property<string>("Site");

                    b.Property<int>("StockExchangeId");

                    b.HasKey("AssetId");

                    b.HasIndex("SectorId");

                    b.HasIndex("StockExchangeId");

                    b.ToTable("Asset");
                });

            modelBuilder.Entity("Invest.Entities.Domain.FundamentalistDetail", b =>
                {
                    b.Property<decimal>("FundamentalistDetailId");

                    b.Property<int>("AssetId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<decimal>("PL");

                    b.Property<decimal>("ROE");

                    b.HasKey("FundamentalistDetailId");

                    b.HasIndex("AssetId");

                    b.ToTable("FundamentalistDetail");
                });

            modelBuilder.Entity("Invest.Entities.Domain.Sector", b =>
                {
                    b.Property<int>("SectorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Name");

                    b.HasKey("SectorId");

                    b.ToTable("Sector");
                });

            modelBuilder.Entity("Invest.Entities.Domain.StockExchange", b =>
                {
                    b.Property<int>("StockExchangeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Name");

                    b.HasKey("StockExchangeId");

                    b.ToTable("StockExchange");
                });

            modelBuilder.Entity("Invest.Entities.Domain.StockQuotesHistory", b =>
                {
                    b.Property<int>("StockQuotesHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssetId");

                    b.Property<decimal>("Close");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("Date");

                    b.Property<decimal>("High");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<decimal>("Low");

                    b.Property<decimal>("Open");

                    b.Property<decimal>("Volume");

                    b.HasKey("StockQuotesHistoryId");

                    b.HasIndex("AssetId");

                    b.ToTable("StockQuotesHistory");
                });

            modelBuilder.Entity("Invest.Entities.Domain.Asset", b =>
                {
                    b.HasOne("Invest.Entities.Domain.Sector", "Sector")
                        .WithMany()
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Invest.Entities.Domain.StockExchange", "StockExchange")
                        .WithMany()
                        .HasForeignKey("StockExchangeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Invest.Entities.Domain.FundamentalistDetail", b =>
                {
                    b.HasOne("Invest.Entities.Domain.Asset", "Asset")
                        .WithMany()
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Invest.Entities.Domain.StockQuotesHistory", b =>
                {
                    b.HasOne("Invest.Entities.Domain.Asset", "Asset")
                        .WithMany()
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
