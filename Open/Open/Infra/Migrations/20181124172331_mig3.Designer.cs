﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Open.Infra;

namespace Open.Infra.Migrations
{
    [DbContext(typeof(SentryDbContext))]
    [Migration("20181124172331_mig3")]
    partial class mig3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Open.Data.Goods.GoodsData", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Description");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<byte[]>("Image");

                    b.Property<string>("Name");

                    b.Property<string>("Price");

                    b.Property<int>("Type");

                    b.Property<DateTime>("ValidFrom");

                    b.Property<DateTime>("ValidTo");

                    b.HasKey("ID");

                    b.ToTable("Good");

                    b.HasDiscriminator<string>("Discriminator").HasValue("GoodsData");
                });

            modelBuilder.Entity("Open.Data.Users.UsersData", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Code");

                    b.Property<string>("Login");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Phone");

                    b.Property<DateTime>("ValidFrom");

                    b.Property<DateTime>("ValidTo");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Open.Data.Goods.AccessoriesData", b =>
                {
                    b.HasBaseType("Open.Data.Goods.GoodsData");


                    b.ToTable("Good");

                    b.HasDiscriminator().HasValue("AccessoriesData");
                });

            modelBuilder.Entity("Open.Data.Goods.ChemistryData", b =>
                {
                    b.HasBaseType("Open.Data.Goods.GoodsData");

                    b.Property<string>("Volume");

                    b.ToTable("Good");

                    b.HasDiscriminator().HasValue("ChemistryData");
                });

            modelBuilder.Entity("Open.Data.Goods.SparePartsData", b =>
                {
                    b.HasBaseType("Open.Data.Goods.GoodsData");


                    b.ToTable("Good");

                    b.HasDiscriminator().HasValue("SparePartsData");
                });
#pragma warning restore 612, 618
        }
    }
}
