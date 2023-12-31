﻿// <auto-generated />
using System;
using Keychain.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Keychain.Infrastructure.Migrations
{
    [DbContext(typeof(KeychainDbContext))]
    [Migration("20230807231356_AddIvShareableSecrets")]
    partial class AddIvShareableSecrets
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Keychain.Domain.ShareableSecret.ShareableSecret", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("BurnedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CurrentViewCount")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("HasPassword")
                        .HasColumnType("boolean");

                    b.Property<byte[]>("Iv")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<int>("MaxViewCount")
                        .HasColumnType("integer");

                    b.Property<string>("Secret")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("ShareableSecrets", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
