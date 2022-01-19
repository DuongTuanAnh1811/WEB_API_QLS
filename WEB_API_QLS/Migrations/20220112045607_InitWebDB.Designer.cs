﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WEB_API_QLS.Infrastructure.Context;

namespace WEB_API_QLS.Migrations
{
    [DbContext(typeof(quanlysachContext))]
    [Migration("20220112045607_InitWebDB")]
    partial class InitWebDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WEB_API_QLS.Domain.Entities.Bandoc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Gioitinh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ho")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaSv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Namsinh")
                        .HasColumnType("int");

                    b.Property<int?>("Ngaysinh")
                        .HasColumnType("int");

                    b.Property<int?>("QuequanId")
                        .HasColumnType("int");

                    b.Property<int?>("Sodienthoai")
                        .HasColumnType("int");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Thangsinh")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuequanId");

                    b.ToTable("Bandocs");
                });

            modelBuilder.Entity("WEB_API_QLS.Domain.Entities.Ngaymuon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BandocId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayMuon")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SachId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BandocId");

                    b.HasIndex("SachId");

                    b.ToTable("Ngaymuons");
                });

            modelBuilder.Entity("WEB_API_QLS.Domain.Entities.Nhanvien", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Chucvu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gioitinh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ho")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Namsinh")
                        .HasColumnType("int");

                    b.Property<int?>("Ngaysinh")
                        .HasColumnType("int");

                    b.Property<int?>("QuequanId")
                        .HasColumnType("int");

                    b.Property<int?>("Sodienthoai")
                        .HasColumnType("int");

                    b.Property<int?>("TaikhoanId")
                        .HasColumnType("int");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Thangsinh")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuequanId");

                    b.HasIndex("TaikhoanId");

                    b.ToTable("Nhanviens");
                });

            modelBuilder.Entity("WEB_API_QLS.Domain.Entities.Quequan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Huyen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Thanhpho")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Quequans");
                });

            modelBuilder.Entity("WEB_API_QLS.Domain.Entities.Sach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Ngaynhap")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Soluong")
                        .HasColumnType("int");

                    b.Property<string>("Tacgia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tensach")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TheloaiId")
                        .HasColumnType("int");

                    b.Property<string>("Tinhtrang")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TheloaiId");

                    b.ToTable("Saches");
                });

            modelBuilder.Entity("WEB_API_QLS.Domain.Entities.Taikhoan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Taikhoans");
                });

            modelBuilder.Entity("WEB_API_QLS.Domain.Entities.Theloai", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TheLoai")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Theloais");
                });

            modelBuilder.Entity("WEB_API_QLS.Domain.Entities.Bandoc", b =>
                {
                    b.HasOne("WEB_API_QLS.Domain.Entities.Quequan", "Quequan")
                        .WithMany("Bandocs")
                        .HasForeignKey("QuequanId");

                    b.Navigation("Quequan");
                });

            modelBuilder.Entity("WEB_API_QLS.Domain.Entities.Ngaymuon", b =>
                {
                    b.HasOne("WEB_API_QLS.Domain.Entities.Bandoc", "Bandoc")
                        .WithMany("Ngaymuons")
                        .HasForeignKey("BandocId");

                    b.HasOne("WEB_API_QLS.Domain.Entities.Sach", "Sach")
                        .WithMany("Ngaymuons")
                        .HasForeignKey("SachId");

                    b.Navigation("Bandoc");

                    b.Navigation("Sach");
                });

            modelBuilder.Entity("WEB_API_QLS.Domain.Entities.Nhanvien", b =>
                {
                    b.HasOne("WEB_API_QLS.Domain.Entities.Quequan", "Quequan")
                        .WithMany("Nhanviens")
                        .HasForeignKey("QuequanId");

                    b.HasOne("WEB_API_QLS.Domain.Entities.Taikhoan", "Taikhoan")
                        .WithMany("Nhanviens")
                        .HasForeignKey("TaikhoanId");

                    b.Navigation("Quequan");

                    b.Navigation("Taikhoan");
                });

            modelBuilder.Entity("WEB_API_QLS.Domain.Entities.Sach", b =>
                {
                    b.HasOne("WEB_API_QLS.Domain.Entities.Theloai", "Theloai")
                        .WithMany("Saches")
                        .HasForeignKey("TheloaiId");

                    b.Navigation("Theloai");
                });

            modelBuilder.Entity("WEB_API_QLS.Domain.Entities.Bandoc", b =>
                {
                    b.Navigation("Ngaymuons");
                });

            modelBuilder.Entity("WEB_API_QLS.Domain.Entities.Quequan", b =>
                {
                    b.Navigation("Bandocs");

                    b.Navigation("Nhanviens");
                });

            modelBuilder.Entity("WEB_API_QLS.Domain.Entities.Sach", b =>
                {
                    b.Navigation("Ngaymuons");
                });

            modelBuilder.Entity("WEB_API_QLS.Domain.Entities.Taikhoan", b =>
                {
                    b.Navigation("Nhanviens");
                });

            modelBuilder.Entity("WEB_API_QLS.Domain.Entities.Theloai", b =>
                {
                    b.Navigation("Saches");
                });
#pragma warning restore 612, 618
        }
    }
}
