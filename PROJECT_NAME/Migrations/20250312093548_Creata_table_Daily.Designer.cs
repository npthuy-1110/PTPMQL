﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PROJECT_NAME.Data;

#nullable disable

namespace PROJECT_NAME.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250312093548_Creata_table_Daily")]
    partial class Creata_table_Daily
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("PROJECT_NAME.Models.HeThongPhanPhoi", b =>
                {
                    b.Property<string>("MaHTPP")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenHTTP")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaHTPP");

                    b.ToTable("HeThongPhanPhoi");
                });

            modelBuilder.Entity("PROJECT_NAME.Models.Models.Daily", b =>
                {
                    b.Property<string>("MaDaiLy")
                        .HasColumnType("TEXT");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DienThoai")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HeThongPhanPhoiMaHTPP")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MaHTPP")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NguoiDaiDien")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenDaiLy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaDaiLy");

                    b.HasIndex("HeThongPhanPhoiMaHTPP");

                    b.ToTable("Daily");
                });

            modelBuilder.Entity("PROJECT_NAME.Models.Person", b =>
                {
                    b.Property<string>("PersonId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("PROJECT_NAME.Models.Models.Daily", b =>
                {
                    b.HasOne("PROJECT_NAME.Models.HeThongPhanPhoi", "HeThongPhanPhoi")
                        .WithMany()
                        .HasForeignKey("HeThongPhanPhoiMaHTPP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HeThongPhanPhoi");
                });
#pragma warning restore 612, 618
        }
    }
}
