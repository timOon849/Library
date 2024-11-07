﻿// <auto-generated />
using System;
using Library.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Library.Migrations
{
    [DbContext(typeof(DBCon))]
    partial class DBConModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Library.Tables.Book", b =>
                {
                    b.Property<int>("ID_Book")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Book"));

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ID_Zhanr")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("YearOfIzd")
                        .HasColumnType("datetime2");

                    b.HasKey("ID_Book");

                    b.HasIndex("ID_Zhanr");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("Library.Tables.Readers", b =>
                {
                    b.Property<int>("Id_Reader")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Reader"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Reader");

                    b.ToTable("Readers");
                });

            modelBuilder.Entity("Library.Tables.RentHistory", b =>
                {
                    b.Property<int>("ID_History")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_History"));

                    b.Property<DateTime?>("Date_End")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date_Start")
                        .HasColumnType("datetime2");

                    b.Property<int>("ID_Book")
                        .HasColumnType("int");

                    b.Property<int>("ID_Reader")
                        .HasColumnType("int");

                    b.Property<int>("Srok")
                        .HasColumnType("int");

                    b.HasKey("ID_History");

                    b.HasIndex("ID_Book");

                    b.HasIndex("ID_Reader");

                    b.ToTable("RentHistory");
                });

            modelBuilder.Entity("Library.Tables.Zhanr", b =>
                {
                    b.Property<int>("ID_Zhanr")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Zhanr"));

                    b.Property<string>("Name_Zhanr")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Zhanr");

                    b.ToTable("Zhanrs");
                });

            modelBuilder.Entity("Library.Tables.Book", b =>
                {
                    b.HasOne("Library.Tables.Zhanr", "Zhanr")
                        .WithMany()
                        .HasForeignKey("ID_Zhanr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Zhanr");
                });

            modelBuilder.Entity("Library.Tables.RentHistory", b =>
                {
                    b.HasOne("Library.Tables.Book", "Book")
                        .WithMany()
                        .HasForeignKey("ID_Book")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Tables.Readers", "Readers")
                        .WithMany()
                        .HasForeignKey("ID_Reader")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Readers");
                });
#pragma warning restore 612, 618
        }
    }
}
