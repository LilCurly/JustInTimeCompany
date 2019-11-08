﻿// <auto-generated />
using System;
using JustInTimeCompany_MuzikantovRoman.Infrastructure.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JustInTimeCompany_MuzikantovRoman.Infrastructure.Migrations
{
    [DbContext(typeof(JustInTimeCompanyDbContext))]
    partial class JustInTimeCompanyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JustInTimeCompany_MuzikantovRoman.Domain.Entities.Airport", b =>
                {
                    b.Property<int>("AirportId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("AirportId");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("JustInTimeCompany_MuzikantovRoman.Domain.Entities.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("FlightId");

                    b.Property<int?>("UserId");

                    b.HasKey("BookingId");

                    b.HasIndex("FlightId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("JustInTimeCompany_MuzikantovRoman.Domain.Entities.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArrivalAirportAirportId");

                    b.Property<DateTime>("ArrivalTime");

                    b.Property<int?>("DepartureAirportAirportId");

                    b.Property<DateTime>("DepartureTime");

                    b.Property<bool>("IsConfirmed");

                    b.Property<string>("LateReason");

                    b.Property<int?>("PilotUserId");

                    b.Property<int?>("PlaneId");

                    b.Property<DateTime>("RealArrivalTime");

                    b.Property<DateTime>("RealDepartureTime");

                    b.Property<int>("Seats");

                    b.HasKey("FlightId");

                    b.HasIndex("ArrivalAirportAirportId");

                    b.HasIndex("DepartureAirportAirportId");

                    b.HasIndex("PilotUserId");

                    b.HasIndex("PlaneId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("JustInTimeCompany_MuzikantovRoman.Domain.Entities.Log", b =>
                {
                    b.Property<int>("LogId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ConcernedFlightFlightId");

                    b.Property<DateTime>("Date");

                    b.Property<bool>("DateModified");

                    b.Property<string>("LogMessage")
                        .IsRequired();

                    b.Property<string>("UserMessage");

                    b.HasKey("LogId");

                    b.HasIndex("ConcernedFlightFlightId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("JustInTimeCompany_MuzikantovRoman.Domain.Entities.LogUser", b =>
                {
                    b.Property<int>("LogId");

                    b.Property<int>("UserId");

                    b.HasKey("LogId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("LogsUsers");
                });

            modelBuilder.Entity("JustInTimeCompany_MuzikantovRoman.Domain.Entities.Plane", b =>
                {
                    b.Property<int>("PlaneId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity");

                    b.Property<string>("Motor")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Speed");

                    b.Property<int>("State");

                    b.Property<int>("TimesUsed");

                    b.HasKey("PlaneId");

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("JustInTimeCompany_MuzikantovRoman.Domain.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsPilot");

                    b.Property<string>("LastName");

                    b.Property<string>("Mail");

                    b.Property<string>("Password");

                    b.HasKey("UserId");

                    b.ToTable("MyUsers");
                });

            modelBuilder.Entity("JustInTimeCompany_MuzikantovRoman.Infrastructure.Data.Entities.AppUser", b =>
                {
                    b.Property<string>("Id")
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

                    b.Property<int?>("UserId");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("JustInTimeCompany_MuzikantovRoman.Domain.Entities.Booking", b =>
                {
                    b.HasOne("JustInTimeCompany_MuzikantovRoman.Domain.Entities.Flight", "Flight")
                        .WithMany("Bookings")
                        .HasForeignKey("FlightId");

                    b.HasOne("JustInTimeCompany_MuzikantovRoman.Domain.Entities.User", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("JustInTimeCompany_MuzikantovRoman.Domain.Entities.Flight", b =>
                {
                    b.HasOne("JustInTimeCompany_MuzikantovRoman.Domain.Entities.Airport", "ArrivalAirport")
                        .WithMany()
                        .HasForeignKey("ArrivalAirportAirportId");

                    b.HasOne("JustInTimeCompany_MuzikantovRoman.Domain.Entities.Airport", "DepartureAirport")
                        .WithMany()
                        .HasForeignKey("DepartureAirportAirportId");

                    b.HasOne("JustInTimeCompany_MuzikantovRoman.Domain.Entities.User", "Pilot")
                        .WithMany("PilotFlights")
                        .HasForeignKey("PilotUserId");

                    b.HasOne("JustInTimeCompany_MuzikantovRoman.Domain.Entities.Plane", "Plane")
                        .WithMany()
                        .HasForeignKey("PlaneId");
                });

            modelBuilder.Entity("JustInTimeCompany_MuzikantovRoman.Domain.Entities.Log", b =>
                {
                    b.HasOne("JustInTimeCompany_MuzikantovRoman.Domain.Entities.Flight", "ConcernedFlight")
                        .WithMany("Logs")
                        .HasForeignKey("ConcernedFlightFlightId");
                });

            modelBuilder.Entity("JustInTimeCompany_MuzikantovRoman.Domain.Entities.LogUser", b =>
                {
                    b.HasOne("JustInTimeCompany_MuzikantovRoman.Domain.Entities.Log", "Log")
                        .WithMany("ConcernedUsers")
                        .HasForeignKey("LogId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JustInTimeCompany_MuzikantovRoman.Domain.Entities.User", "User")
                        .WithMany("Logs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JustInTimeCompany_MuzikantovRoman.Infrastructure.Data.Entities.AppUser", b =>
                {
                    b.HasOne("JustInTimeCompany_MuzikantovRoman.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("JustInTimeCompany_MuzikantovRoman.Infrastructure.Data.Entities.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("JustInTimeCompany_MuzikantovRoman.Infrastructure.Data.Entities.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JustInTimeCompany_MuzikantovRoman.Infrastructure.Data.Entities.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("JustInTimeCompany_MuzikantovRoman.Infrastructure.Data.Entities.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
