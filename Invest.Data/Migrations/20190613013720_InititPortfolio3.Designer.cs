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
    [Migration("20190613013720_InititPortfolio3")]
    partial class InititPortfolio3
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

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("CompanyId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("LastUpdated");

                    b.Property<decimal>("Price");

                    b.Property<string>("PublicId")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("StockExchangeId");

                    b.HasKey("AssetId");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("CompanyId");

                    b.HasIndex("StockExchangeId");

                    b.ToTable("Asset");
                });

            modelBuilder.Entity("Invest.Entities.Domain.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("B3Id");

                    b.Property<string>("Cnpj");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Details");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Logo");

                    b.Property<string>("Name");

                    b.Property<string>("PublicId")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("SectorId");

                    b.Property<int?>("SegmentId");

                    b.Property<string>("Site");

                    b.Property<int?>("SubSectorId");

                    b.HasKey("CompanyId");

                    b.HasIndex("Cnpj")
                        .IsUnique()
                        .HasFilter("[Cnpj] IS NOT NULL");

                    b.HasIndex("SectorId");

                    b.HasIndex("SegmentId");

                    b.HasIndex("SubSectorId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("Invest.Entities.Domain.Fundamentalist", b =>
                {
                    b.Property<int>("FundamentalistId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssetId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<decimal?>("PL");

                    b.Property<string>("PublicId")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<decimal?>("ROE");

                    b.HasKey("FundamentalistId");

                    b.HasIndex("AssetId");

                    b.ToTable("Fundamentalist");
                });

            modelBuilder.Entity("Invest.Entities.Domain.Investment", b =>
                {
                    b.Property<int>("InvestmentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssetId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<int>("PortfolioId");

                    b.Property<decimal>("Price");

                    b.Property<string>("PublicId");

                    b.Property<int>("Unities");

                    b.HasKey("InvestmentId");

                    b.HasIndex("AssetId");

                    b.HasIndex("PortfolioId");

                    b.ToTable("Investment");
                });

            modelBuilder.Entity("Invest.Entities.Domain.Portfolio", b =>
                {
                    b.Property<int>("PortfolioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Name");

                    b.Property<string>("PublicId");

                    b.Property<int>("UserId");

                    b.HasKey("PortfolioId");

                    b.HasIndex("UserId");

                    b.ToTable("Portfolio");
                });

            modelBuilder.Entity("Invest.Entities.Domain.Sector", b =>
                {
                    b.Property<int>("SectorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("PublicId")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("StockExchangeId");

                    b.HasKey("SectorId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("StockExchangeId");

                    b.ToTable("Sector");
                });

            modelBuilder.Entity("Invest.Entities.Domain.Segment", b =>
                {
                    b.Property<int>("SegmentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Name");

                    b.Property<string>("PublicId");

                    b.Property<int>("SubSectorId");

                    b.HasKey("SegmentId");

                    b.HasIndex("SubSectorId");

                    b.ToTable("Segment");
                });

            modelBuilder.Entity("Invest.Entities.Domain.StockExchange", b =>
                {
                    b.Property<int>("StockExchangeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("PublicId")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("StockExchangeId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("StockExchange");
                });

            modelBuilder.Entity("Invest.Entities.Domain.StockQuotesHistory", b =>
                {
                    b.Property<int>("StockQuotesHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AdjustedClose");

                    b.Property<int>("AssetId");

                    b.Property<decimal>("Close");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("Date");

                    b.Property<decimal>("Dividend");

                    b.Property<decimal>("High");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<decimal>("Low");

                    b.Property<decimal>("Open");

                    b.Property<string>("PublicId")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<decimal>("Split");

                    b.Property<decimal>("Volume");

                    b.HasKey("StockQuotesHistoryId");

                    b.HasIndex("AssetId");

                    b.HasIndex("Date", "AssetId")
                        .IsUnique();

                    b.ToTable("StockQuotesHistory");
                });

            modelBuilder.Entity("Invest.Entities.Domain.SubSector", b =>
                {
                    b.Property<int>("SubSectorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Name");

                    b.Property<string>("PublicId");

                    b.Property<int>("SectorId");

                    b.HasKey("SubSectorId");

                    b.HasIndex("SectorId");

                    b.ToTable("SubSector");
                });

            modelBuilder.Entity("Invest.Entities.Domain.Subscription", b =>
                {
                    b.Property<int>("SubscriptionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("ExpirationTime");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("PublicId")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("SubscriptionStatus");

                    b.Property<int>("SubscriptionType");

                    b.HasKey("SubscriptionId");

                    b.ToTable("Subscription");
                });

            modelBuilder.Entity("Invest.Entities.Domain.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("Profile");

                    b.Property<string>("PublicId")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("SubscriptionId");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("SubscriptionId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Invest.Entities.Domain.Asset", b =>
                {
                    b.HasOne("Invest.Entities.Domain.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Invest.Entities.Domain.StockExchange", "StockExchange")
                        .WithMany()
                        .HasForeignKey("StockExchangeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Invest.Entities.Domain.Company", b =>
                {
                    b.HasOne("Invest.Entities.Domain.Sector", "Sector")
                        .WithMany()
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Invest.Entities.Domain.Segment", "Segment")
                        .WithMany()
                        .HasForeignKey("SegmentId");

                    b.HasOne("Invest.Entities.Domain.SubSector", "SubSector")
                        .WithMany()
                        .HasForeignKey("SubSectorId");
                });

            modelBuilder.Entity("Invest.Entities.Domain.Fundamentalist", b =>
                {
                    b.HasOne("Invest.Entities.Domain.Asset", "Asset")
                        .WithMany()
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Invest.Entities.Domain.Investment", b =>
                {
                    b.HasOne("Invest.Entities.Domain.Asset", "Asset")
                        .WithMany()
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Invest.Entities.Domain.Portfolio", "Portfolio")
                        .WithMany()
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Invest.Entities.Domain.Portfolio", b =>
                {
                    b.HasOne("Invest.Entities.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Invest.Entities.Domain.Sector", b =>
                {
                    b.HasOne("Invest.Entities.Domain.StockExchange", "StockExchange")
                        .WithMany()
                        .HasForeignKey("StockExchangeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Invest.Entities.Domain.Segment", b =>
                {
                    b.HasOne("Invest.Entities.Domain.SubSector", "SubSector")
                        .WithMany()
                        .HasForeignKey("SubSectorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Invest.Entities.Domain.StockQuotesHistory", b =>
                {
                    b.HasOne("Invest.Entities.Domain.Asset", "Asset")
                        .WithMany()
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Invest.Entities.Domain.SubSector", b =>
                {
                    b.HasOne("Invest.Entities.Domain.Sector", "Sector")
                        .WithMany()
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Invest.Entities.Domain.User", b =>
                {
                    b.HasOne("Invest.Entities.Domain.Subscription", "Subscription")
                        .WithMany()
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
