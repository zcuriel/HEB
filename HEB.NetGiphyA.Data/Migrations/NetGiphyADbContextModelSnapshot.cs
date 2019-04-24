﻿// <auto-generated />
using HEB.NetGiphyA.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace HEB.NetGiphyA.Data.Migrations
{
    [DbContext(typeof(NetGiphyADbContext))]
    partial class NetGiphyADbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HEB.NetGiphyA.Data.Objects.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("UserEmail")
                        .IsRequired();

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("HEB.NetGiphyA.Data.Objects.Picture", b =>
                {
                    b.Property<int>("PictureId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<string>("Description")
                        .HasMaxLength(250);

                    b.Property<string>("FileName")
                        .HasMaxLength(250);

                    b.Property<int>("Height");

                    b.Property<byte[]>("Image");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("SourceUrl")
                        .HasMaxLength(500);

                    b.Property<string>("UserEmail")
                        .IsRequired();

                    b.Property<int>("Width");

                    b.HasKey("PictureId");

                    b.ToTable("Pictures");
                });
#pragma warning restore 612, 618
        }
    }
}
