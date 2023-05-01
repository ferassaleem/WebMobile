﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebMobile.Data;

namespace WebMobile.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("WebMobile.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyPictureURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("WebMobile.Models.Mobile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Battery")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Camera")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("MobileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobilePictureURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OperatingSystemId")
                        .HasColumnType("int");

                    b.Property<string>("Processor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RAM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Screen")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("OperatingSystemId");

                    b.ToTable("Mobiles");
                });

            modelBuilder.Entity("WebMobile.Models.Operating_System", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("OperatingName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OperatingPictureURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Operatings");
                });

            modelBuilder.Entity("WebMobile.Models.Mobile", b =>
                {
                    b.HasOne("WebMobile.Models.Company", "Company")
                        .WithMany("Mobiles")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebMobile.Models.Operating_System", "OperatingSystem")
                        .WithMany("Mobiles")
                        .HasForeignKey("OperatingSystemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("OperatingSystem");
                });

            modelBuilder.Entity("WebMobile.Models.Company", b =>
                {
                    b.Navigation("Mobiles");
                });

            modelBuilder.Entity("WebMobile.Models.Operating_System", b =>
                {
                    b.Navigation("Mobiles");
                });
#pragma warning restore 612, 618
        }
    }
}