﻿// <auto-generated />
using EmailSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmailSystem.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20250213223704_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("EmailSystem.Models.Attachment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("MailDefinitionID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MailDefinitionID");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("EmailSystem.Models.MailDefinition", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("EmailTemplateName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("SendBox")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("TenantName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ViewModel")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("MailDefinitions");
                });

            modelBuilder.Entity("EmailSystem.Models.Attachment", b =>
                {
                    b.HasOne("EmailSystem.Models.MailDefinition", "MailDefinition")
                        .WithMany("Attachments")
                        .HasForeignKey("MailDefinitionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MailDefinition");
                });

            modelBuilder.Entity("EmailSystem.Models.MailDefinition", b =>
                {
                    b.OwnsOne("EmailSystem.Models.MailDefinitionCore", "MailDefinitionCore", b1 =>
                        {
                            b1.Property<int>("MailDefinitionID")
                                .HasColumnType("int");

                            b1.Property<string>("BCC")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("CC")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("ContentHTML")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("ContentText")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("From")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("ReplyTo")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("Subject")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("To")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("MailDefinitionID");

                            b1.ToTable("MailDefinitions");

                            b1.WithOwner()
                                .HasForeignKey("MailDefinitionID");
                        });

                    b.Navigation("MailDefinitionCore")
                        .IsRequired();
                });

            modelBuilder.Entity("EmailSystem.Models.MailDefinition", b =>
                {
                    b.Navigation("Attachments");
                });
#pragma warning restore 612, 618
        }
    }
}
