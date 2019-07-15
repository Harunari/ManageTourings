﻿// <auto-generated />
using System;
using Manage_Tourings.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Manage_Tourings.Migrations
{
    [DbContext(typeof(ManageTouringsContext))]
    [Migration("20190715151725_FixTouring2")]
    partial class FixTouring2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Manage_Tourings.Models.Touring.Plan.Plan", b =>
                {
                    b.Property<int>("PlanId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title");

                    b.HasKey("PlanId");

                    b.ToTable("Plans");
                });

            modelBuilder.Entity("Manage_Tourings.Models.Touring.Touring", b =>
                {
                    b.Property<int>("TouringId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Note");

                    b.Property<int?>("PlanId");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("TouringId");

                    b.HasIndex("PlanId");

                    b.ToTable("Tourings");
                });

            modelBuilder.Entity("Manage_Tourings.Models.Touring.Touring", b =>
                {
                    b.HasOne("Manage_Tourings.Models.Touring.Plan.Plan", "Plan")
                        .WithMany()
                        .HasForeignKey("PlanId");
                });
#pragma warning restore 612, 618
        }
    }
}