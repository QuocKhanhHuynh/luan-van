﻿// <auto-generated />
using System;
using FreelancerPlatform.Infratructure.Entityframework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FreelancerPlatform.Infratructure.Entityframework.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241002161026_UpdateDataModel")]
    partial class UpdateDataModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.Apply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ma_ung_tuyen");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDay")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_tao");

                    b.Property<DateTime?>("CreateUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_cap_nhat");

                    b.Property<int>("Deal")
                        .HasColumnType("int")
                        .HasColumnName("luong_de_xuat");

                    b.Property<int>("ExecutionTime")
                        .HasColumnType("int")
                        .HasColumnName("so_ngay_hoan_thanh");

                    b.Property<int>("FreelancerId")
                        .HasColumnType("int");

                    b.Property<string>("Introduction")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("gioi_thieu");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FreelancerId");

                    b.HasIndex("JobId");

                    b.ToTable("ung_tuyen_viec");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("linh_vuc_hoat_dong");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDay")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_tao");

                    b.Property<DateTime?>("CreateUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_cap_nhat");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("duong_dan");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ten_linh_vuc");

                    b.HasKey("Id");

                    b.ToTable("linh_vuc_hoat_dong");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.FavoriteJob", b =>
                {
                    b.Property<int>("FreelancerId")
                        .HasColumnType("int");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDay")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_tao");

                    b.Property<DateTime?>("CreateUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_cap_nhat");

                    b.HasKey("FreelancerId", "JobId");

                    b.HasIndex("JobId");

                    b.ToTable("FavoriteJobs");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.Freelancer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("gioi_thieu");

                    b.Property<string>("BankName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ten_tai_khoan_ngan_hang");

                    b.Property<string>("BankNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("so_tai_khoan_ngan_hang");

                    b.Property<DateTime>("CreateDay")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_tao");

                    b.Property<DateTime?>("CreateUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_cap_nhat");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ten");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("duong_dan_anh");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ho_ten_dem");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("mat_khau");

                    b.Property<bool>("PaymentVerification")
                        .HasColumnType("bit")
                        .HasColumnName("xac_thuc_thong_tin_ca_nhan");

                    b.Property<int>("Priority")
                        .HasColumnType("int")
                        .HasColumnName("do_uu_tien");

                    b.Property<int?>("RateHour")
                        .HasColumnType("int")
                        .HasColumnName("luong_mot_gio");

                    b.Property<int?>("SystemManagementId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SystemManagementId");

                    b.ToTable("ung_vien");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.FreelancerCategory", b =>
                {
                    b.Property<int>("FreelancerId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDay")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_tao");

                    b.Property<DateTime?>("CreateUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_cap_nhat");

                    b.HasKey("FreelancerId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ung_vien_linh_vuc");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.FreelancerSkill", b =>
                {
                    b.Property<int>("FreelancerId")
                        .HasColumnType("int");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("FreelancerId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("FreelancerSkill");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ma_cong_viec");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDay")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_tao");

                    b.Property<DateTime?>("CreateUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_cap_nhat");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("mo_ta");

                    b.Property<int>("FreelancerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsHiden")
                        .HasColumnType("bit")
                        .HasColumnName("an_cong_viec");

                    b.Property<int>("JobType")
                        .HasColumnType("int")
                        .HasColumnName("loai_cong_viec");

                    b.Property<int>("MaxDeal")
                        .HasColumnType("int")
                        .HasColumnName("luong_cuoi");

                    b.Property<int>("MinDeal")
                        .HasColumnType("int")
                        .HasColumnName("luong_dau");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ten_viec");

                    b.Property<int>("Priority")
                        .HasColumnType("int")
                        .HasColumnName("do_uu_tien");

                    b.Property<int>("SalaryType")
                        .HasColumnType("int")
                        .HasColumnName("loai_luong");

                    b.Property<int?>("SystemManagementId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("FreelancerId");

                    b.HasIndex("SystemManagementId");

                    b.ToTable("cong_viec");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.JobSkill", b =>
                {
                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("JobId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("JobSkill");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.Offer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ma_loi_moi");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDay")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_tao");

                    b.Property<DateTime?>("CreateUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_cap_nhat");

                    b.Property<int>("FreelancerId")
                        .HasColumnType("int")
                        .HasColumnName("ma_ung_vien");

                    b.Property<int>("FreelancerOfferId")
                        .HasColumnType("int")
                        .HasColumnName("ma_nha_tuyen_dung");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FreelancerId");

                    b.HasIndex("JobId");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ma_quyen");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDay")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_tao");

                    b.Property<DateTime?>("CreateUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_cap_nhat");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ten_quyen");

                    b.HasKey("Id");

                    b.ToTable("quyen");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.PotentialFreelancer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ma_ung_vien_tim_nang");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDay")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_tao");

                    b.Property<DateTime?>("CreateUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_cap_nhat");

                    b.Property<int>("FreelancerId")
                        .HasColumnType("int");

                    b.Property<int>("FreelancerPotientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FreelancerId");

                    b.ToTable("ung_vien_tim_nang");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ma_bao_cao");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("noi_dung");

                    b.Property<DateTime>("CreateDay")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_tao");

                    b.Property<DateTime?>("CreateUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_cap_nhat");

                    b.Property<int>("FreelancerId")
                        .HasColumnType("int");

                    b.Property<int>("ReportType")
                        .HasColumnType("int")
                        .HasColumnName("loai_bao_cao");

                    b.HasKey("Id");

                    b.HasIndex("FreelancerId");

                    b.ToTable("bao_cao");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.RequirementServiceByFreelancer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ma_ung_vien_yeu_cau");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDay")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_tao");

                    b.Property<DateTime?>("CreateUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_cap_nhat");

                    b.Property<int>("FreelancerId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceForFreelancerId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("trang_thai");

                    b.HasKey("Id");

                    b.HasIndex("FreelancerId");

                    b.HasIndex("ServiceForFreelancerId");

                    b.ToTable("dich_vu_ung_vien_yeu_cau");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ma_vai_tro");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDay")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_tao");

                    b.Property<DateTime?>("CreateUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_cap_nhat");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ten_vai_tro");

                    b.HasKey("Id");

                    b.ToTable("vai_tro_quan_tri");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.RolePermission", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDay")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_tao");

                    b.Property<DateTime?>("CreateUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_cap_nhat");

                    b.HasKey("RoleId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("quyen_vai_tro");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.SKill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ma_ky_nang");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDay")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_tao");

                    b.Property<DateTime?>("CreateUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_cap_nhat");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ten_ky_nang");

                    b.HasKey("Id");

                    b.ToTable("ky_nang");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.ServiceForFreelancer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ma_dich_vu_cho_ung_vien");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDay")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_tao");

                    b.Property<DateTime?>("CreateUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_cap_nhat");

                    b.Property<int>("Fee")
                        .HasColumnType("int")
                        .HasColumnName("phi_dich_vu");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ten_dich_vu");

                    b.HasKey("Id");

                    b.ToTable("dich_vu_cho-ung_vien");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.SystemManagement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ma_quan_tri_vien");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDay")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_tao");

                    b.Property<DateTime?>("CreateUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_cap_nhat");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ho_ten");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("mat_khau");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("so_dien_thoai");

                    b.Property<bool>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("trang_thai_hoat_dong");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ten_tai_khoan");

                    b.HasKey("Id");

                    b.ToTable("quan_tri_vien");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.SystemManagementRole", b =>
                {
                    b.Property<int>("SystemManagementId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDay")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_tao");

                    b.Property<DateTime?>("CreateUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_cap_nhat");

                    b.HasKey("SystemManagementId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("SystemManagementRole");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ma_giao_dich");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int")
                        .HasColumnName("so_tien");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("noi_dung");

                    b.Property<DateTime>("CreateDay")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_tao");

                    b.Property<DateTime?>("CreateUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngay_cap_nhat");

                    b.HasKey("Id");

                    b.ToTable("ma_giao_dich");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.Apply", b =>
                {
                    b.HasOne("FreelancerPlatform.Domain.Entity.Freelancer", "Freelancer")
                        .WithMany("Applies")
                        .HasForeignKey("FreelancerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FreelancerPlatform.Domain.Entity.Job", "Job")
                        .WithMany("Applies")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Freelancer");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.FavoriteJob", b =>
                {
                    b.HasOne("FreelancerPlatform.Domain.Entity.Freelancer", "Freelancer")
                        .WithMany("FavoriteJobs")
                        .HasForeignKey("FreelancerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FreelancerPlatform.Domain.Entity.Job", "Job")
                        .WithMany("FavoriteJobs")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Freelancer");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.Freelancer", b =>
                {
                    b.HasOne("FreelancerPlatform.Domain.Entity.SystemManagement", null)
                        .WithMany("Freelancers")
                        .HasForeignKey("SystemManagementId");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.FreelancerCategory", b =>
                {
                    b.HasOne("FreelancerPlatform.Domain.Entity.Category", "Category")
                        .WithMany("FreelancerCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FreelancerPlatform.Domain.Entity.Freelancer", "Freelancer")
                        .WithMany("FreelancerCategories")
                        .HasForeignKey("FreelancerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Freelancer");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.FreelancerSkill", b =>
                {
                    b.HasOne("FreelancerPlatform.Domain.Entity.Freelancer", "Freelancer")
                        .WithMany("FreelancerSkills")
                        .HasForeignKey("FreelancerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FreelancerPlatform.Domain.Entity.SKill", "SKill")
                        .WithMany("FreelancerSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Freelancer");

                    b.Navigation("SKill");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.Job", b =>
                {
                    b.HasOne("FreelancerPlatform.Domain.Entity.Category", "Category")
                        .WithMany("Jobs")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FreelancerPlatform.Domain.Entity.Freelancer", "Freelancer")
                        .WithMany()
                        .HasForeignKey("FreelancerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FreelancerPlatform.Domain.Entity.SystemManagement", null)
                        .WithMany("Jobs")
                        .HasForeignKey("SystemManagementId");

                    b.Navigation("Category");

                    b.Navigation("Freelancer");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.JobSkill", b =>
                {
                    b.HasOne("FreelancerPlatform.Domain.Entity.Job", "Job")
                        .WithMany("JobSkills")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FreelancerPlatform.Domain.Entity.SKill", "SKill")
                        .WithMany("JobSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Job");

                    b.Navigation("SKill");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.Offer", b =>
                {
                    b.HasOne("FreelancerPlatform.Domain.Entity.Freelancer", "Freelancer")
                        .WithMany("Offers")
                        .HasForeignKey("FreelancerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FreelancerPlatform.Domain.Entity.Job", "Job")
                        .WithMany("Offers")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Freelancer");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.PotentialFreelancer", b =>
                {
                    b.HasOne("FreelancerPlatform.Domain.Entity.Freelancer", "Freelancer")
                        .WithMany("PotentialFreelancers")
                        .HasForeignKey("FreelancerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Freelancer");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.Report", b =>
                {
                    b.HasOne("FreelancerPlatform.Domain.Entity.Freelancer", "Freelancer")
                        .WithMany("Reports")
                        .HasForeignKey("FreelancerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Freelancer");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.RequirementServiceByFreelancer", b =>
                {
                    b.HasOne("FreelancerPlatform.Domain.Entity.Freelancer", "Freelancer")
                        .WithMany("RequirementServiceByFreelancers")
                        .HasForeignKey("FreelancerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FreelancerPlatform.Domain.Entity.ServiceForFreelancer", "ServiceForFreelancer")
                        .WithMany("RequirementServiceByFreelancers")
                        .HasForeignKey("ServiceForFreelancerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Freelancer");

                    b.Navigation("ServiceForFreelancer");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.RolePermission", b =>
                {
                    b.HasOne("FreelancerPlatform.Domain.Entity.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FreelancerPlatform.Domain.Entity.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.SystemManagementRole", b =>
                {
                    b.HasOne("FreelancerPlatform.Domain.Entity.Role", "Role")
                        .WithMany("SystemManagementRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FreelancerPlatform.Domain.Entity.SystemManagement", "SystemManagement")
                        .WithMany("SystemManagementRoles")
                        .HasForeignKey("SystemManagementId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("SystemManagement");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.Category", b =>
                {
                    b.Navigation("FreelancerCategories");

                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.Freelancer", b =>
                {
                    b.Navigation("Applies");

                    b.Navigation("FavoriteJobs");

                    b.Navigation("FreelancerCategories");

                    b.Navigation("FreelancerSkills");

                    b.Navigation("Offers");

                    b.Navigation("PotentialFreelancers");

                    b.Navigation("Reports");

                    b.Navigation("RequirementServiceByFreelancers");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.Job", b =>
                {
                    b.Navigation("Applies");

                    b.Navigation("FavoriteJobs");

                    b.Navigation("JobSkills");

                    b.Navigation("Offers");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.Permission", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.Role", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("SystemManagementRoles");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.SKill", b =>
                {
                    b.Navigation("FreelancerSkills");

                    b.Navigation("JobSkills");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.ServiceForFreelancer", b =>
                {
                    b.Navigation("RequirementServiceByFreelancers");
                });

            modelBuilder.Entity("FreelancerPlatform.Domain.Entity.SystemManagement", b =>
                {
                    b.Navigation("Freelancers");

                    b.Navigation("Jobs");

                    b.Navigation("SystemManagementRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
