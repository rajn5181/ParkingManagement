﻿// <auto-generated />
using System;
using CheckStatus.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CheckStatus.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230928101137_inti")]
    partial class inti
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CheckStatus.Model.CPA", b =>
                {
                    b.Property<string>("Pid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Available")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Pid");

                    b.ToTable("MasterAvailability");
                });

            modelBuilder.Entity("CheckStatus.Model.SlotModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CPAPid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<int>("Limit_Block1")
                        .HasColumnType("int");

                    b.Property<int>("Limit_Block2")
                        .HasColumnType("int");

                    b.Property<int>("Limit_Block3")
                        .HasColumnType("int");

                    b.Property<int>("Limit_Block4")
                        .HasColumnType("int");

                    b.Property<int>("Limit_Block5")
                        .HasColumnType("int");

                    b.Property<decimal>("PricePerHour")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Six")
                        .HasColumnType("int");

                    b.Property<int>("Three")
                        .HasColumnType("int");

                    b.Property<int>("Twelve")
                        .HasColumnType("int");

                    b.Property<int>("Two")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CPAPid");

                    b.ToTable("MasterSlot");
                });

            modelBuilder.Entity("CheckStatus.Model.SlotModel", b =>
                {
                    b.HasOne("CheckStatus.Model.CPA", null)
                        .WithMany("Slots")
                        .HasForeignKey("CPAPid");
                });

            modelBuilder.Entity("CheckStatus.Model.CPA", b =>
                {
                    b.Navigation("Slots");
                });
#pragma warning restore 612, 618
        }
    }
}
