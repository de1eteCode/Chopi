﻿// <auto-generated />
using System;
using Chopi.Modules.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Chopi.Modules.EFCore.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.CarDealership.Autopart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Article")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ManufacturerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("Autoparts");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.CarDealership.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("BasePrice")
                        .HasColumnType("money");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("varchar(70)");

                    b.Property<Guid>("ModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("VIN")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("Year")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.CarDealership.Complete", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Completes");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.CarDealership.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.CarDealership.Manufacturer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("INN")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.CarDealership.Model", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ManufacturerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.CarDealership.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CodeOrder")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<decimal>("PaidPrice")
                        .HasColumnType("money");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.CarDealership.TO.Maintenance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateOfEnded")
                        .HasColumnType("date");

                    b.Property<DateTime>("DateOfRecording")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DateOfWork")
                        .HasColumnType("date");

                    b.Property<Guid>("StatusId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("StatusId");

                    b.ToTable("Maintenances");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.CarDealership.TO.Status", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.CarDealership.TO.Work", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("Works");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.CarDealership.Transits.CompleteToAutopart", b =>
                {
                    b.Property<Guid>("AutopartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompleteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AutopartId", "CompleteId");

                    b.HasIndex("CompleteId");

                    b.ToTable("CompleteAutopart");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.CarDealership.Transits.CustomCarToAutopart", b =>
                {
                    b.Property<Guid>("AutopartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomCarId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AutopartId", "CustomCarId");

                    b.HasIndex("CustomCarId");

                    b.ToTable("CustomCarAutopart");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.CarDealership.Transits.MaintenanceToWork", b =>
                {
                    b.Property<Guid>("MaintenanceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WorkId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MaintenanceId", "WorkId");

                    b.HasIndex("WorkId");

                    b.ToTable("MaintenanceWork");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.CarDealership.Transits.ModelToAutopart", b =>
                {
                    b.Property<Guid>("AutopartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ModelId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AutopartId", "ModelId");

                    b.HasIndex("ModelId");

                    b.ToTable("ModelAutopart");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.Identity.Passport", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Citizenship")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("ResidenceRegistration")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Series")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Passports");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.Identity.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.Identity.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.Identity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<Guid>("PassportId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("PassportId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.Identity.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.Identity.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.Identity.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.Identity.UserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.CarDealership.CompleteCar", b =>
                {
                    b.HasBaseType("Chopi.Modules.EFCore.Entities.CarDealership.Car");

                    b.Property<Guid>("CompleteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("CompleteId");

                    b.ToTable("CompleteCars");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.CarDealership.CustomCar", b =>
                {
                    b.HasBaseType("Chopi.Modules.EFCore.Entities.CarDealership.Car");

                    b.ToTable("CustomCars");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.CarDealership.Autopart", b =>
                {
                    b.HasOne("Chopi.Modules.EFCore.Entities.CarDealership.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.CarDealership.Car", b =>
                {
                    b.HasOne("Chopi.Modules.EFCore.Entities.CarDealership.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.CarDealership.Manufacturer", b =>
                {
                    b.HasOne("Chopi.Modules.EFCore.Entities.CarDealership.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.CarDealership.Model", b =>
                {
                    b.HasOne("Chopi.Modules.EFCore.Entities.CarDealership.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.CarDealership.Order", b =>
                {
                    b.HasOne("Chopi.Modules.EFCore.Entities.CarDealership.Car", "Car")
                        .WithOne()
                        .HasForeignKey("Chopi.Modules.EFCore.Entities.CarDealership.Order", "CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Chopi.Modules.EFCore.Entities.Identity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.CarDealership.TO.Maintenance", b =>
                {
                    b.HasOne("Chopi.Modules.EFCore.Entities.CarDealership.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Chopi.Modules.EFCore.Entities.CarDealership.TO.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.CarDealership.Transits.CompleteToAutopart", b =>
                {
                    b.HasOne("Chopi.Modules.EFCore.Entities.CarDealership.Autopart", "Autopart")
                        .WithMany("Completes")
                        .HasForeignKey("AutopartId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Chopi.Modules.EFCore.Entities.CarDealership.Complete", "Complete")
                        .WithMany("Autoparts")
                        .HasForeignKey("CompleteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Autopart");

                    b.Navigation("Complete");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.CarDealership.Transits.CustomCarToAutopart", b =>
                {
                    b.HasOne("Chopi.Modules.EFCore.Entities.CarDealership.Autopart", "Autopart")
                        .WithMany("CustomCars")
                        .HasForeignKey("AutopartId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Chopi.Modules.EFCore.Entities.CarDealership.CustomCar", "CustomCar")
                        .WithMany("Autoparts")
                        .HasForeignKey("CustomCarId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Autopart");

                    b.Navigation("CustomCar");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.CarDealership.Transits.MaintenanceToWork", b =>
                {
                    b.HasOne("Chopi.Modules.EFCore.Entities.CarDealership.TO.Maintenance", "Maintenance")
                        .WithMany("Works")
                        .HasForeignKey("MaintenanceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Chopi.Modules.EFCore.Entities.CarDealership.TO.Work", "Work")
                        .WithMany("Maintenances")
                        .HasForeignKey("WorkId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Maintenance");

                    b.Navigation("Work");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.CarDealership.Transits.ModelToAutopart", b =>
                {
                    b.HasOne("Chopi.Modules.EFCore.Entities.CarDealership.Autopart", "Autopart")
                        .WithMany("Models")
                        .HasForeignKey("AutopartId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Chopi.Modules.EFCore.Entities.CarDealership.Model", "Model")
                        .WithMany("SupportedAutoparts")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Autopart");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.Identity.RoleClaim", b =>
                {
                    b.HasOne("Chopi.Modules.EFCore.Entities.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.Identity.User", b =>
                {
                    b.HasOne("Chopi.Modules.EFCore.Entities.Identity.Passport", "Passport")
                        .WithOne()
                        .HasForeignKey("Chopi.Modules.EFCore.Entities.Identity.User", "PassportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Passport");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.Identity.UserClaim", b =>
                {
                    b.HasOne("Chopi.Modules.EFCore.Entities.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.Identity.UserLogin", b =>
                {
                    b.HasOne("Chopi.Modules.EFCore.Entities.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.Identity.UserRole", b =>
                {
                    b.HasOne("Chopi.Modules.EFCore.Entities.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Chopi.Modules.EFCore.Entities.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.Identity.UserToken", b =>
                {
                    b.HasOne("Chopi.Modules.EFCore.Entities.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.CarDealership.CompleteCar", b =>
                {
                    b.HasOne("Chopi.Modules.EFCore.Entities.CarDealership.Complete", "Complete")
                        .WithMany()
                        .HasForeignKey("CompleteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Chopi.Modules.EFCore.Entities.CarDealership.Car", null)
                        .WithOne()
                        .HasForeignKey("Chopi.Modules.EFCore.Entities.CarDealership.CompleteCar", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Complete");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.CarDealership.CustomCar", b =>
                {
                    b.HasOne("Chopi.Modules.EFCore.Entities.CarDealership.Car", null)
                        .WithOne()
                        .HasForeignKey("Chopi.Modules.EFCore.Entities.CarDealership.CustomCar", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.CarDealership.Autopart", b =>
                {
                    b.Navigation("Completes");

                    b.Navigation("CustomCars");

                    b.Navigation("Models");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.CarDealership.Complete", b =>
                {
                    b.Navigation("Autoparts");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.CarDealership.Model", b =>
                {
                    b.Navigation("SupportedAutoparts");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.CarDealership.TO.Maintenance", b =>
                {
                    b.Navigation("Works");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.CarDealership.TO.Work", b =>
                {
                    b.Navigation("Maintenances");
                });

            modelBuilder.Entity("Chopi.Modules.EFCore.Entities.CarDealership.CustomCar", b =>
                {
                    b.Navigation("Autoparts");
                });
#pragma warning restore 612, 618
        }
    }
}
