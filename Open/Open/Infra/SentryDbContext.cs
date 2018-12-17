using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Open.Data.Customers;
using Open.Data.Goods;

namespace Open.Infra {
    public class SentryDbContext : DbContext {
        public SentryDbContext(DbContextOptions o) : base(o) { }
        public DbSet<GoodsData> Goods { get; set; }
        public DbSet<CustomersData> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder b) {
            base.OnModelCreating(b);
            b.Entity<GoodsData>().ToTable("Goods");
            createGoodTable(b);
            b.Entity<CustomersData>().ToTable("Customers");
            createCustomersTable(b);
        }
        internal static void createGoodTable(ModelBuilder b) {
            const string table = "Goods";
            createPrimaryKey<GoodsData>(b, table, a => a.ID);
        }
        internal static void createCustomersTable(ModelBuilder b) {
            const string table = "Customers";
            createPrimaryKey<CustomersData>(b, table, a => a.ID);
        }
        internal static void createPrimaryKey<TEntity>(ModelBuilder b, string tableName,
            Expression<Func<TEntity, object>> primaryKey) where TEntity : class {
            b.Entity<TEntity>()
                .ToTable(tableName)
                .HasKey(primaryKey);
        }
    }
}

























