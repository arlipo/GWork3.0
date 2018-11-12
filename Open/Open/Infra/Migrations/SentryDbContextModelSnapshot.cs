﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Open.Infra;

namespace Open.Infra.Migrations
{
    [DbContext(typeof(SentryDbContext))]
    partial class SentryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
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

                    b.Property<string>("ImageType");

                    b.Property<string>("Name");

                    b.Property<string>("PicFileLocation");

                    b.Property<string>("Price");

                    b.Property<string>("Type");

                    b.Property<DateTime>("ValidFrom");

                    b.Property<DateTime>("ValidTo");

                    b.HasKey("ID");

                    b.ToTable("Good");

                    b.HasDiscriminator<string>("Discriminator").HasValue("GoodsData");
                });

            modelBuilder.Entity("Open.Data.Party.AddressData", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("CityOrAreaCode");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("RegionOrStateOrCountryCode");

                    b.Property<DateTime>("ValidFrom");

                    b.Property<DateTime>("ValidTo");

                    b.Property<string>("ZipOrPostCodeOrExtension");

                    b.HasKey("ID");

                    b.ToTable("Address");

                    b.HasDiscriminator<string>("Discriminator").HasValue("AddressData");
                });

            modelBuilder.Entity("Open.Data.Party.CountryData", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.Property<DateTime>("ValidFrom");

                    b.Property<DateTime>("ValidTo");

                    b.HasKey("ID");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("Open.Data.Party.TelecomDeviceRegistrationData", b =>
                {
                    b.Property<string>("AddressID");

                    b.Property<string>("DeviceID");

                    b.Property<DateTime>("ValidFrom");

                    b.Property<DateTime>("ValidTo");

                    b.HasKey("AddressID", "DeviceID");

                    b.HasIndex("DeviceID");

                    b.ToTable("TelecomDeviceRegistration");
                });

            modelBuilder.Entity("Open.Data.Quantity.CurrencyData", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Definition");

                    b.Property<string>("Name");

                    b.Property<DateTime>("ValidFrom");

                    b.Property<DateTime>("ValidTo");

                    b.HasKey("ID");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("Open.Data.Quantity.NationalCurrencyData", b =>
                {
                    b.Property<string>("CountryID");

                    b.Property<string>("CurrencyID");

                    b.Property<DateTime>("ValidFrom");

                    b.Property<DateTime>("ValidTo");

                    b.HasKey("CountryID", "CurrencyID");

                    b.HasIndex("CurrencyID");

                    b.ToTable("NationalCurrency");
                });

            modelBuilder.Entity("Open.Data.Quantity.PaymentData", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<string>("CurrencyID");

                    b.Property<DateTime>("DateDue");

                    b.Property<DateTime>("DateMade");

                    b.Property<string>("PaymentMethodID");

                    b.Property<DateTime>("ValidFrom");

                    b.Property<DateTime>("ValidTo");

                    b.HasKey("ID");

                    b.HasIndex("CurrencyID");

                    b.HasIndex("PaymentMethodID");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("Open.Data.Quantity.PaymentMethodData", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Code");

                    b.Property<string>("CurrencyID");

                    b.Property<decimal>("DailyLimit");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Issue");

                    b.Property<string>("Name");

                    b.Property<string>("Number");

                    b.Property<string>("Organization");

                    b.Property<DateTime>("ValidFrom");

                    b.Property<DateTime>("ValidTo");

                    b.HasKey("ID");

                    b.HasIndex("CurrencyID");

                    b.ToTable("PaymentMethod");

                    b.HasDiscriminator<string>("Discriminator").HasValue("PaymentMethodData");
                });

            modelBuilder.Entity("Open.Data.Quantity.RateData", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CurrencyID");

                    b.Property<decimal>("Rate");

                    b.Property<string>("RateTypeID");

                    b.Property<DateTime>("ValidFrom");

                    b.Property<DateTime>("ValidTo");

                    b.HasKey("ID");

                    b.HasIndex("CurrencyID");

                    b.HasIndex("RateTypeID");

                    b.ToTable("Rate");
                });

            modelBuilder.Entity("Open.Data.Quantity.RateTypeData", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<DateTime>("ValidFrom");

                    b.Property<DateTime>("ValidTo");

                    b.HasKey("ID");

                    b.ToTable("RateType");
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

            modelBuilder.Entity("Open.Data.Goods.ChemistryData", b =>
                {
                    b.HasBaseType("Open.Data.Goods.GoodsData");

                    b.Property<string>("Volume");

                    b.ToTable("Good");

                    b.HasDiscriminator().HasValue("ChemistryData");
                });

            modelBuilder.Entity("Open.Data.Party.EmailAddressData", b =>
                {
                    b.HasBaseType("Open.Data.Party.AddressData");


                    b.ToTable("Address");

                    b.HasDiscriminator().HasValue("EmailAddressData");
                });

            modelBuilder.Entity("Open.Data.Party.GeographicAddressData", b =>
                {
                    b.HasBaseType("Open.Data.Party.AddressData");

                    b.Property<string>("CountryID");

                    b.HasIndex("CountryID");

                    b.ToTable("Address");

                    b.HasDiscriminator().HasValue("GeographicAddressData");
                });

            modelBuilder.Entity("Open.Data.Party.TelecomAddressData", b =>
                {
                    b.HasBaseType("Open.Data.Party.AddressData");

                    b.Property<int>("Device");

                    b.Property<string>("NationalDirectDialingPrefix");

                    b.ToTable("Address");

                    b.HasDiscriminator().HasValue("TelecomAddressData");
                });

            modelBuilder.Entity("Open.Data.Party.WebPageAddressData", b =>
                {
                    b.HasBaseType("Open.Data.Party.AddressData");


                    b.ToTable("Address");

                    b.HasDiscriminator().HasValue("WebPageAddressData");
                });

            modelBuilder.Entity("Open.Data.Quantity.CheckData", b =>
                {
                    b.HasBaseType("Open.Data.Quantity.PaymentMethodData");

                    b.Property<string>("Payee");

                    b.ToTable("PaymentMethod");

                    b.HasDiscriminator().HasValue("CheckData");
                });

            modelBuilder.Entity("Open.Data.Quantity.CreditCardData", b =>
                {
                    b.HasBaseType("Open.Data.Quantity.PaymentMethodData");

                    b.Property<decimal>("CreditLimit");

                    b.ToTable("PaymentMethod");

                    b.HasDiscriminator().HasValue("CreditCardData");
                });

            modelBuilder.Entity("Open.Data.Quantity.DebitCardData", b =>
                {
                    b.HasBaseType("Open.Data.Quantity.PaymentMethodData");


                    b.ToTable("PaymentMethod");

                    b.HasDiscriminator().HasValue("DebitCardData");
                });

            modelBuilder.Entity("Open.Data.Party.TelecomDeviceRegistrationData", b =>
                {
                    b.HasOne("Open.Data.Party.GeographicAddressData", "Address")
                        .WithMany()
                        .HasForeignKey("AddressID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Open.Data.Party.TelecomAddressData", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Open.Data.Quantity.NationalCurrencyData", b =>
                {
                    b.HasOne("Open.Data.Party.CountryData", "Country")
                        .WithMany()
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Open.Data.Quantity.CurrencyData", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Open.Data.Quantity.PaymentData", b =>
                {
                    b.HasOne("Open.Data.Quantity.CurrencyData", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Open.Data.Quantity.PaymentMethodData", "PaymentMethod")
                        .WithMany()
                        .HasForeignKey("PaymentMethodID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Open.Data.Quantity.PaymentMethodData", b =>
                {
                    b.HasOne("Open.Data.Quantity.CurrencyData", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Open.Data.Quantity.RateData", b =>
                {
                    b.HasOne("Open.Data.Quantity.CurrencyData", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Open.Data.Quantity.RateTypeData", "RateType")
                        .WithMany()
                        .HasForeignKey("RateTypeID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Open.Data.Party.GeographicAddressData", b =>
                {
                    b.HasOne("Open.Data.Party.CountryData", "Country")
                        .WithMany()
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
