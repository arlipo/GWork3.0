using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Open.Data.Goods;
using Open.Data.Party;
using Open.Data.Quantity;
using Open.Data.Users;

namespace Open.Infra {
    public class SentryDbContext : DbContext {
        public SentryDbContext(DbContextOptions<SentryDbContext> o) : base(o) { }

        public SentryDbContext()
        {
        }

        public DbSet<CountryData> Countries { get; set; }

        public DbSet<CurrencyData> Currencies { get; set; }

        public DbSet<NationalCurrencyData> CountryCurrencies { get; set; }

        public DbSet<AddressData> Addresses { get; set; }

        public DbSet<GoodsData> Goods { get; set; }
        public DbSet<ChemistryData> Chemistry { get; set; }
        public DbSet<AccessoriesData> Accessories { get; set; }
        public DbSet<SparePartsData> SpareParts { get; set; }

        public DbSet<TelecomDeviceRegistrationData> TelecomDeviceRegistrations { get; set; }

        public DbSet<RateData> Rates { get; set; }
        public DbSet<RateTypeData> RateTypes { get; set; }
        public DbSet<PaymentMethodData> PaymentMethods { get; set; }
        public DbSet<PaymentData> Payments { get; set; }
        //public object Users { get; set; }
        public DbSet<UsersData> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder b) {
            base.OnModelCreating(b);
            b.Entity<CurrencyData>().ToTable("Currency");
            b.Entity<CountryData>().ToTable("Country");
            b.Entity<GoodsData>().ToTable("Good");
            b.Entity<ChemistryData>().ToTable("Good");

            b.Entity<UsersData>().ToTable("Users");
            b.Entity<RateTypeData>().ToTable("RateType");
            createGoodTable(b);
            createAddressTable(b);
            createTelecomAddressRegistrationTable(b);
            createNationalCurrencyTable(b);
            createPaymentMethodTable(b);
            createRateTable(b);
            createPaymentTable(b);
        }
        private static void createPaymentMethodTable(ModelBuilder b) {
            const string table = "PaymentMethod";
            b.Entity<CheckData>().ToTable(table);
            b.Entity<CreditCardData>().ToTable(table);
            b.Entity<DebitCardData>().ToTable(table);
            createForeignKey<PaymentMethodData, CurrencyData>(b, table, x => x.CurrencyID,
                x => x.Currency);
        }

        private static void createPaymentTable(ModelBuilder b) {
            const string table = "Payment";
            createForeignKey<PaymentData, CurrencyData>(b, table, x => x.CurrencyID,
                x => x.Currency);
            createForeignKey<PaymentData, PaymentMethodData>(b, table, x => x.PaymentMethodID,
                x => x.PaymentMethod);
        }

        private static void createRateTable(ModelBuilder b) {
            const string table = "Rate";
            createForeignKey<RateData, CurrencyData>(b, table, x => x.CurrencyID, x => x.Currency);
            createForeignKey<RateData, RateTypeData>(b, table, x => x.RateTypeID, x => x.RateType);
        }
        internal static void createAddressTable(ModelBuilder b) {
            const string table = "Address";
            b.Entity<AddressData>().ToTable(table);
            b.Entity<WebPageAddressData>().ToTable(table);
            b.Entity<EmailAddressData>().ToTable(table);
            b.Entity<TelecomAddressData>().ToTable(table);
            createForeignKey<GeographicAddressData, CountryData>(b, table, x => x.CountryID,
                x => x.Country);
        }
        internal static void createTelecomAddressRegistrationTable(ModelBuilder b) {
            const string table = "TelecomDeviceRegistration";
            createPrimaryKey<TelecomDeviceRegistrationData>(b, table,
                a => new {a.AddressID, a.DeviceID});
            createForeignKey<TelecomDeviceRegistrationData, GeographicAddressData>(b, table,
                x => x.AddressID, x => x.Address);
            createForeignKey<TelecomDeviceRegistrationData, TelecomAddressData>(b, table,
                x => x.DeviceID, x => x.Device);
        }
        internal static void createNationalCurrencyTable(ModelBuilder b) {
            const string table = "NationalCurrency";
            createPrimaryKey<NationalCurrencyData>(b, table, a => new {a.CountryID, a.CurrencyID});
            createForeignKey<NationalCurrencyData, CountryData>(b, table, x => x.CountryID,
                x => x.Country);
            createForeignKey<NationalCurrencyData, CurrencyData>(b, table, x => x.CurrencyID,
                x => x.Currency);
        }
        internal static void createGoodTable(ModelBuilder b) {
            const string table = "Good";
            createPrimaryKey<GoodsData>(b, table, a => a.ID);
        }

        internal static void createPrimaryKey<TEntity>(ModelBuilder b, string tableName,
            Expression<Func<TEntity, object>> primaryKey) where TEntity : class {
            b.Entity<TEntity>()
                .ToTable(tableName)
                .HasKey(primaryKey);
        }
        internal static void createForeignKey<TEntity, TRelatedEntity>(ModelBuilder b,
            string tableName, Expression<Func<TEntity, object>> foreignKey,
            Expression<Func<TEntity, TRelatedEntity>> getRelatedEntity)
            where TEntity : class where TRelatedEntity : class {
            b.Entity<TEntity>()
                .ToTable(tableName)
                .HasOne(getRelatedEntity)
                .WithMany()
                .HasForeignKey(foreignKey)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

























