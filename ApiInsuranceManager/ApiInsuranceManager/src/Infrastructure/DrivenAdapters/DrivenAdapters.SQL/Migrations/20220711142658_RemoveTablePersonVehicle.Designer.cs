﻿// <auto-generated />
using System;
using DrivenAdapters.SQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DrivenAdapters.SQL.Migrations
{
    [DbContext(typeof(InsuranceContext))]
    [Migration("20220711142658_RemoveTablePersonVehicle")]
    partial class RemoveTablePersonVehicle
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Model.Entities.SQL.TBL_INSURANCE_TYPE", b =>
                {
                    b.Property<int>("Id_Insurance_Type")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id_Insurance_Type");

                    b.ToTable("InsuranceType");
                });

            modelBuilder.Entity("Domain.Model.Entities.SQL.TBL_INSURANCE_VALUES", b =>
                {
                    b.Property<int>("Id_Insurance_Values")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("BaseValue")
                        .HasColumnType("numeric(20,0)");

                    b.Property<int>("Id_Insurance_Type")
                        .HasColumnType("int");

                    b.HasKey("Id_Insurance_Values");

                    b.HasIndex("Id_Insurance_Type");

                    b.ToTable("InsuranceValues");
                });

            modelBuilder.Entity("Domain.Model.Entities.SQL.TBL_LINE", b =>
                {
                    b.Property<int>("Id_Line")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id_Line");

                    b.ToTable("Line");
                });

            modelBuilder.Entity("Domain.Model.Entities.SQL.TBL_PERSON", b =>
                {
                    b.Property<int>("IdPerson")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("Id_Eps")
                        .HasColumnType("int");

                    b.Property<string>("Identification")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdPerson");

                    b.HasIndex("Id_Eps");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("Domain.Model.Entities.SQL.TBL_REQUEST", b =>
                {
                    b.Property<int>("Id_Request")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("FinalCost")
                        .HasColumnType("numeric(20,0)");

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_Insurance_Type")
                        .HasColumnType("int");

                    b.Property<int>("Id_Person")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id_Request");

                    b.HasIndex("Id_Insurance_Type");

                    b.HasIndex("Id_Person");

                    b.ToTable("Request");
                });

            modelBuilder.Entity("Domain.Model.Entities.SQL.TBL_VEHICLE", b =>
                {
                    b.Property<int>("Id_Vehicle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Id_Brand")
                        .HasColumnType("int");

                    b.Property<int>("Id_Line")
                        .HasColumnType("int");

                    b.Property<int>("Id_Person")
                        .HasColumnType("int");

                    b.Property<int>("Model")
                        .HasColumnType("int");

                    b.HasKey("Id_Vehicle");

                    b.HasIndex("Id_Brand");

                    b.HasIndex("Id_Line");

                    b.HasIndex("Id_Person");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("Domain.Model.SQL.TBL_BRAND", b =>
                {
                    b.Property<int>("Id_Brand")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id_Brand");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("Domain.Model.SQL.TBL_EPS", b =>
                {
                    b.Property<int>("Id_Eps")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id_Eps");

                    b.ToTable("Eps");
                });

            modelBuilder.Entity("Domain.Model.Entities.SQL.TBL_INSURANCE_VALUES", b =>
                {
                    b.HasOne("Domain.Model.Entities.SQL.TBL_INSURANCE_TYPE", "InsuranceType")
                        .WithMany()
                        .HasForeignKey("Id_Insurance_Type")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InsuranceType");
                });

            modelBuilder.Entity("Domain.Model.Entities.SQL.TBL_PERSON", b =>
                {
                    b.HasOne("Domain.Model.SQL.TBL_EPS", "Eps")
                        .WithMany()
                        .HasForeignKey("Id_Eps")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Eps");
                });

            modelBuilder.Entity("Domain.Model.Entities.SQL.TBL_REQUEST", b =>
                {
                    b.HasOne("Domain.Model.Entities.SQL.TBL_INSURANCE_TYPE", "InsuranceType")
                        .WithMany()
                        .HasForeignKey("Id_Insurance_Type")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Model.Entities.SQL.TBL_PERSON", "Person")
                        .WithMany()
                        .HasForeignKey("Id_Person")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InsuranceType");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Domain.Model.Entities.SQL.TBL_VEHICLE", b =>
                {
                    b.HasOne("Domain.Model.SQL.TBL_BRAND", "Brand")
                        .WithMany()
                        .HasForeignKey("Id_Brand")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Model.Entities.SQL.TBL_LINE", "Line")
                        .WithMany()
                        .HasForeignKey("Id_Line")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Model.Entities.SQL.TBL_PERSON", "Person")
                        .WithMany()
                        .HasForeignKey("Id_Person")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Line");

                    b.Navigation("Person");
                });
#pragma warning restore 612, 618
        }
    }
}
