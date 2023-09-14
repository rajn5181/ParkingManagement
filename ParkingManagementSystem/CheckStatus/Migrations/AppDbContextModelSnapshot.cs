﻿// <auto-generated />
using System;
using CheckStatus.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CheckStatus.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.HasKey("Pid");

                    b.ToTable("MasterAvailability");
                });

            modelBuilder.Entity("CheckStatus.Model.SlotModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CPAPid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Day")
                        .HasColumnType("bit");

                    b.Property<bool>("Six")
                        .HasColumnType("bit");

                    b.Property<bool>("Three")
                        .HasColumnType("bit");

                    b.Property<bool>("Twelve")
                        .HasColumnType("bit");

                    b.Property<bool>("Two")
                        .HasColumnType("bit");

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
