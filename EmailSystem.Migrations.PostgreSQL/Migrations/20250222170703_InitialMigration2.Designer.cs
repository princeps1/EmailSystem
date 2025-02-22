﻿// <auto-generated />
using System;
using EmailSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EmailSystem.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20250222170703_InitialMigration2")]
    partial class InitialMigration2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EmailSystem.Domain.Entities.Attachment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("MailDefinitionID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("MailDefinitionID");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("EmailSystem.Domain.Entities.MailDefinition", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("EmailTemplateName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool?>("SendBox")
                        .HasColumnType("boolean");

                    b.Property<string>("TenantName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ViewModel")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("MailDefinitions");
                });

            modelBuilder.Entity("EmailSystem.Domain.Entities.Attachment", b =>
                {
                    b.HasOne("EmailSystem.Domain.Entities.MailDefinition", "MailDefinition")
                        .WithMany("Attachments")
                        .HasForeignKey("MailDefinitionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MailDefinition");
                });

            modelBuilder.Entity("EmailSystem.Domain.Entities.MailDefinition", b =>
                {
                    b.OwnsOne("EmailSystem.Domain.Entities.MailDefinitionCore", "MailDefinitionCore", b1 =>
                        {
                            b1.Property<int>("MailDefinitionID")
                                .HasColumnType("integer");

                            b1.Property<string>("BCC")
                                .HasColumnType("text");

                            b1.Property<string>("CC")
                                .HasColumnType("text");

                            b1.Property<string>("ContentHTML")
                                .HasColumnType("text");

                            b1.Property<string>("ContentText")
                                .HasColumnType("text");

                            b1.Property<string>("From")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("ReplyTo")
                                .HasColumnType("text");

                            b1.Property<string>("Subject")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("To")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("MailDefinitionID");

                            b1.ToTable("MailDefinitions");

                            b1.WithOwner()
                                .HasForeignKey("MailDefinitionID");
                        });

                    b.Navigation("MailDefinitionCore")
                        .IsRequired();
                });

            modelBuilder.Entity("EmailSystem.Domain.Entities.MailDefinition", b =>
                {
                    b.Navigation("Attachments");
                });
#pragma warning restore 612, 618
        }
    }
}
