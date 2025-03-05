﻿// <auto-generated />
using System;
using EasyCash.Command.Store.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EasyCash.Command.Store.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250305155704_Initial")]
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

            modelBuilder.Entity("EasyCash.Command.Store.Repositories.OutboxMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("jsonb")
                        .HasColumnName("content")
                        .HasComment("Content of the message");

                    b.Property<string>("Error")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("error")
                        .HasComment("Error message if the message processing failed");

                    b.Property<DateTime>("OccurredOnUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("occurred_on_utc");

                    b.Property<DateTime?>("ProcessedOnUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("processed_on_utc")
                        .HasComment("Date when the message was processed");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("type")
                        .HasComment("Type of class for desserializing");

                    b.HasKey("Id")
                        .HasName("pk_outbox_messages");

                    b.HasIndex("OccurredOnUtc", "ProcessedOnUtc")
                        .HasDatabaseName("ix_outbox_messages_occurred_on_utc_processed_on_utc");

                    NpgsqlIndexBuilderExtensions.IncludeProperties(b.HasIndex("OccurredOnUtc", "ProcessedOnUtc"), new[] { "Id", "Type", "Content" });

                    b.ToTable("outbox_messages", (string)null);
                });

            modelBuilder.Entity("EasyCash.Domain.Abstractions.Idempotency.Entity.IdempotencyEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("Request")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)")
                        .HasColumnName("request")
                        .HasComment("Request of the message");

                    b.Property<string>("Response")
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)")
                        .HasColumnName("response")
                        .HasComment("Response of the message");

                    b.HasKey("Id")
                        .HasName("pk_idempotent_messages");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("ix_idempotent_messages_id");

                    b.ToTable("idempotent_messages", (string)null);
                });

            modelBuilder.Entity("EasyCash.Domain.Transactions.Entities.TransactionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric")
                        .HasColumnName("amount")
                        .HasComment("Amount of the transaction");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("category")
                        .HasComment("Category of the transaction");

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

                    b.Property<long>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("row_version")
                        .HasDefaultValueSql("1")
                        .HasComment("Concurrency Token");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("type")
                        .HasComment("Type of the transaction");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at")
                        .HasComment("Date when the transaction was updated");

                    b.HasKey("Id")
                        .HasName("pk_transactions");

                    b.HasIndex("Date")
                        .HasDatabaseName("ix_transactions_date");

                    b.ToTable("transactions", (string)null);
                });

            modelBuilder.Entity("EasyCash.Domain.Users.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("email")
                        .HasComment("user e-mail");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("first_name")
                        .HasComment("The real first name of the user");

                    b.Property<string>("IdentityId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("identity_id");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("last_name")
                        .HasComment("The real last name of the user");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_users_email");

                    b.HasIndex("IdentityId")
                        .IsUnique()
                        .HasDatabaseName("ix_users_identity_id");

                    b.ToTable("users", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
