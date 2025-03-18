﻿// <auto-generated />
using DBServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DBServer.Migrations.OnlineNodes
{
    [DbContext(typeof(OnlineNodesContext))]
    [Migration("20250318145309_added port")]
    partial class addedport
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("DBServer.Models.OnlineNodes", b =>
                {
                    b.Property<string>("DNAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("IPAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Port")
                        .HasColumnType("INTEGER");

                    b.HasKey("DNAddress");

                    b.ToTable("OnlineNodes");
                });
#pragma warning restore 612, 618
        }
    }
}
