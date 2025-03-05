﻿// <auto-generated />
using System;
using EasyCash.Report.Command.Store.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EasyCash.Report.Command.Store.Migrations
{
    [DbContext(typeof(ReportDbContext))]
    [Migration("20250305201329_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EasyCash.Report.Domain.Consolidations.Entity.ConsolidationTransactionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric")
                        .HasColumnName("amount")
                        .HasComment("Amount of the transaction");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasComment("Date when the transaction was created");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date")
                        .HasComment("Date of the transaction");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("description")
                        .HasComment("Description of the transaction");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("type")
                        .HasComment("Type of the transaction");

                    b.HasKey("Id")
                        .HasName("pk_transactions");

                    b.ToTable("transactions", (string)null);
                });

            modelBuilder.Entity("EasyCash.Report.Domain.Consolidations.Entity.DailyConsolidationEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasComment("Date when the transaction was created");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date")
                        .HasComment("Date of the transaction");

                    b.Property<decimal>("FinalBalance")
                        .HasColumnType("numeric")
                        .HasColumnName("final_balance")
                        .HasComment("Final balance of the date");

                    b.Property<decimal>("TotalCredit")
                        .HasColumnType("numeric")
                        .HasColumnName("total_credit")
                        .HasComment("Total sum of Credits em the date");

                    b.Property<decimal>("TotalDebit")
                        .HasColumnType("numeric")
                        .HasColumnName("total_debit")
                        .HasComment("Total sum of Debits em the date");

                    b.HasKey("Id")
                        .HasName("pk_daily_consolidations");

                    b.ToTable("daily_consolidations", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
