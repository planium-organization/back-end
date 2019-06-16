﻿// <auto-generated />
using System;
using KP.BackEnd.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace KP.BackEnd.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190615190550_addCommentConfiguration")]
    partial class addCommentConfiguration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("KP.BackEnd.Core.Models.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("KP.BackEnd.Core.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bbbb1111-1111-1111-1111-111111111111"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "711e2a27-dd2e-48b8-b7b4-5cb77a0ea28b",
                            Email = "supervisor@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "SUPERVISOR@GMAIL.COM",
                            NormalizedUserName = "SUPERVISOR@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEI/pxMrWTcIV3FGzvjQFlAFtsW2HUH2wbvb536uufyDFskflnRLk+PbSRC0kRfXRSw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "supervisor@gmail.com"
                        },
                        new
                        {
                            Id = new Guid("bbbb2222-1111-1111-1111-111111111111"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7a6360f2-da1b-439f-b80e-b00e07758e1a",
                            Email = "student@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "STUDENT@GMAIL.COM",
                            NormalizedUserName = "STUDENT@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEBPoAnffbGMW4rJjYOM9cpylxJJEFRIJMagum9Kx+Q4U3OjpOuCuUHyaNux2tMukzw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "student@gmail.com"
                        });
                });

            modelBuilder.Entity("KP.BackEnd.Core.Models.Card", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CourseId");

                    b.Property<string>("Description");

                    b.Property<DateTime>("DueDate");

                    b.Property<TimeSpan>("Duration");

                    b.Property<DateTime?>("StartTime");

                    b.Property<int>("Status");

                    b.Property<Guid>("StudentId");

                    b.Property<Guid?>("SupervisorId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Cards");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cccc1111-1111-1111-1111-111111111111"),
                            CourseId = new Guid("eeee1111-1111-1111-1111-111111111112"),
                            Description = "supervisor 1",
                            DueDate = new DateTime(2018, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Duration = new TimeSpan(0, 1, 11, 11, 0),
                            Status = 0,
                            StudentId = new Guid("bbbb2222-1111-1111-1111-111111111111"),
                            SupervisorId = new Guid("bbbb1111-1111-1111-1111-111111111111")
                        },
                        new
                        {
                            Id = new Guid("cccc1111-1111-1111-1111-111111111112"),
                            CourseId = new Guid("eeee1111-1111-1111-1111-111111111111"),
                            Description = "supervisor 2",
                            DueDate = new DateTime(2019, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Duration = new TimeSpan(0, 2, 11, 11, 0),
                            Status = 1,
                            StudentId = new Guid("bbbb2222-1111-1111-1111-111111111111"),
                            SupervisorId = new Guid("bbbb1111-1111-1111-1111-111111111111")
                        },
                        new
                        {
                            Id = new Guid("cccc1111-1111-1111-1111-111111111113"),
                            CourseId = new Guid("eeee1111-1111-1111-1111-111111111112"),
                            Description = "student 1",
                            DueDate = new DateTime(2018, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Duration = new TimeSpan(0, 1, 11, 11, 0),
                            Status = 0,
                            StudentId = new Guid("bbbb2222-1111-1111-1111-111111111111")
                        },
                        new
                        {
                            Id = new Guid("cccc1111-1111-1111-1111-111111111114"),
                            CourseId = new Guid("eeee1111-1111-1111-1111-111111111111"),
                            Description = "student 2",
                            DueDate = new DateTime(2019, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Duration = new TimeSpan(0, 1, 11, 11, 0),
                            Status = 0,
                            StudentId = new Guid("bbbb2222-1111-1111-1111-111111111111")
                        });
                });

            modelBuilder.Entity("KP.BackEnd.Core.Models.ChannelPost", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationTime");

                    b.Property<Guid>("CreatorId");

                    b.Property<byte[]>("Image");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("ChannelPosts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("aaaa1111-1111-1111-1111-111111111111"),
                            CreationTime = new DateTime(2018, 11, 11, 11, 11, 11, 0, DateTimeKind.Unspecified),
                            CreatorId = new Guid("bbbb1111-1111-1111-1111-111111111111"),
                            Text = "example text"
                        },
                        new
                        {
                            Id = new Guid("aaaa1111-1111-1111-1111-111111111112"),
                            CreationTime = new DateTime(2018, 11, 11, 11, 11, 12, 0, DateTimeKind.Unspecified),
                            CreatorId = new Guid("bbbb1111-1111-1111-1111-111111111111"),
                            Text = "example text 2"
                        });
                });

            modelBuilder.Entity("KP.BackEnd.Core.Models.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationTime");

                    b.Property<DateTime>("Date");

                    b.Property<Guid>("StudentId");

                    b.Property<Guid>("SupervisorId");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("SupervisorId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dddd1111-1111-1111-1111-111111111111"),
                            CreationTime = new DateTime(2019, 11, 10, 11, 11, 11, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2019, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = new Guid("bbbb2222-1111-1111-1111-111111111111"),
                            SupervisorId = new Guid("bbbb1111-1111-1111-1111-111111111111"),
                            Text = "comment text 1"
                        },
                        new
                        {
                            Id = new Guid("dddd1111-1111-1111-1111-111111111112"),
                            CreationTime = new DateTime(2019, 11, 12, 11, 11, 11, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2019, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = new Guid("bbbb2222-1111-1111-1111-111111111111"),
                            SupervisorId = new Guid("bbbb1111-1111-1111-1111-111111111111"),
                            Text = "comment text 2"
                        });
                });

            modelBuilder.Entity("KP.BackEnd.Core.Models.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Color");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("eeee1111-1111-1111-1111-111111111111"),
                            Color = "#f4ee42",
                            Title = "Math"
                        },
                        new
                        {
                            Id = new Guid("eeee1111-1111-1111-1111-111111111112"),
                            Color = "#f44141",
                            Title = "Theology"
                        });
                });

            modelBuilder.Entity("KP.BackEnd.Core.Models.Student", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("Major");

                    b.Property<string>("SchoolName");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bbbb2222-1111-1111-1111-111111111111")
                        });
                });

            modelBuilder.Entity("KP.BackEnd.Core.Models.Supervisor", b =>
                {
                    b.Property<Guid>("Id");

                    b.HasKey("Id");

                    b.ToTable("Supervisors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bbbb1111-1111-1111-1111-111111111111")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<Guid>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("KP.BackEnd.Core.Models.Card", b =>
                {
                    b.HasOne("KP.BackEnd.Core.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KP.BackEnd.Core.Models.ChannelPost", b =>
                {
                    b.HasOne("KP.BackEnd.Core.Models.Supervisor", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KP.BackEnd.Core.Models.Comment", b =>
                {
                    b.HasOne("KP.BackEnd.Core.Models.Supervisor", "Supervisor")
                        .WithMany()
                        .HasForeignKey("SupervisorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KP.BackEnd.Core.Models.Student", b =>
                {
                    b.HasOne("KP.BackEnd.Core.Models.ApplicationUser", "Identity")
                        .WithOne()
                        .HasForeignKey("KP.BackEnd.Core.Models.Student", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KP.BackEnd.Core.Models.Supervisor", b =>
                {
                    b.HasOne("KP.BackEnd.Core.Models.ApplicationUser", "Identity")
                        .WithOne()
                        .HasForeignKey("KP.BackEnd.Core.Models.Supervisor", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("KP.BackEnd.Core.Models.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("KP.BackEnd.Core.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("KP.BackEnd.Core.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("KP.BackEnd.Core.Models.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KP.BackEnd.Core.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("KP.BackEnd.Core.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
