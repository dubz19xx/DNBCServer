﻿// <auto-generated />
using DBServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DBServer.Migrations
{
    [DbContext(typeof(LoginDataContext))]
    [Migration("20250317172225_InitialCommitLoginInfo")]
    partial class InitialCommitLoginInfo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("DBServer.Models.LoginInfo", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.Property<string>("DNAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Username");

                    b.ToTable("LoginInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
