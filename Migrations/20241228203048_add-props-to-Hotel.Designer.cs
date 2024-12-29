﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using iranAttractions.data;

#nullable disable

namespace iranAttractions.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20241228203048_add-props-to-Hotel")]
    partial class addpropstoHotel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("iranAttractions.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("iranAttractions.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SightseeingId")
                        .HasColumnType("int");

                    b.Property<int?>("State")
                        .HasColumnType("int");

                    b.Property<string>("UserPhonenumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("picurl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SightseeingId");

                    b.HasIndex("UserPhonenumber");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("iranAttractions.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CommunicationRel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("cityId")
                        .HasColumnType("int");

                    b.Property<double>("lat")
                        .HasColumnType("float");

                    b.Property<double>("lon")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("cityId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("iranAttractions.Models.Parts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PicUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SightseeingId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SightseeingId");

                    b.ToTable("Part");
                });

            modelBuilder.Entity("iranAttractions.Models.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SightseeingId")
                        .HasColumnType("int");

                    b.Property<string>("UserPhonenumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("dateImported")
                        .HasColumnType("datetime2");

                    b.Property<int>("likecounts")
                        .HasColumnType("int");

                    b.Property<int>("state")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SightseeingId");

                    b.HasIndex("UserPhonenumber");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("iranAttractions.Models.Sightseeing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("lat")
                        .HasColumnType("float");

                    b.Property<double>("lon")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("sightseeing");
                });

            modelBuilder.Entity("iranAttractions.Models.User", b =>
                {
                    b.Property<string>("Phonenumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Phonenumber");

                    b.ToTable("User");
                });

            modelBuilder.Entity("iranAttractions.Models.Comment", b =>
                {
                    b.HasOne("iranAttractions.Models.Sightseeing", "Sightseeings")
                        .WithMany("Comments")
                        .HasForeignKey("SightseeingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("iranAttractions.Models.User", "Users")
                        .WithMany("Comments")
                        .HasForeignKey("UserPhonenumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sightseeings");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("iranAttractions.Models.Hotel", b =>
                {
                    b.HasOne("iranAttractions.Models.City", "City")
                        .WithMany("hotels")
                        .HasForeignKey("cityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("iranAttractions.Models.Parts", b =>
                {
                    b.HasOne("iranAttractions.Models.Sightseeing", "Sightseeings")
                        .WithMany("parts")
                        .HasForeignKey("SightseeingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sightseeings");
                });

            modelBuilder.Entity("iranAttractions.Models.Picture", b =>
                {
                    b.HasOne("iranAttractions.Models.Sightseeing", "sightseeing")
                        .WithMany()
                        .HasForeignKey("SightseeingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("iranAttractions.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("UserPhonenumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("sightseeing");

                    b.Navigation("user");
                });

            modelBuilder.Entity("iranAttractions.Models.Sightseeing", b =>
                {
                    b.HasOne("iranAttractions.Models.City", "City")
                        .WithMany("sightseeings")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("iranAttractions.Models.City", b =>
                {
                    b.Navigation("hotels");

                    b.Navigation("sightseeings");
                });

            modelBuilder.Entity("iranAttractions.Models.Sightseeing", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("parts");
                });

            modelBuilder.Entity("iranAttractions.Models.User", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
