﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication20.Data;

namespace WebApplication20.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210312073238_AddOneToManyRelationShipProjectAndTicket")]
    partial class AddOneToManyRelationShipProjectAndTicket
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication20.Models.Project", b =>
                {
                    b.Property<int>("Project_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Project_Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("WebApplication20.Models.Ticket", b =>
                {
                    b.Property<int>("Ticket_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Project_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("TicketCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("TicketDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TicketName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TicketPriority")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TicketType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Ticket_Id");

                    b.HasIndex("Project_Id");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("WebApplication20.Models.Ticket", b =>
                {
                    b.HasOne("WebApplication20.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("Project_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });
#pragma warning restore 612, 618
        }
    }
}
