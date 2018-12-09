using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Open.Data.Goods;

namespace Open.Infra {
    public class SentryDbContext : DbContext {
        public SentryDbContext(DbContextOptions<SentryDbContext> o) : base(o) { }
        
        public DbSet<GoodsData> Goods { get; set; }

        protected override void OnModelCreating(ModelBuilder b) {
            base.OnModelCreating(b);
            b.Entity<GoodsData>().ToTable("Goods");
            createGoodTable(b);
        }
      
        internal static void createGoodTable(ModelBuilder b) {
            const string table = "Goods";
            createPrimaryKey<GoodsData>(b, table, a => a.ID);
        }

        internal static void createPrimaryKey<TEntity>(ModelBuilder b, string tableName,
            Expression<Func<TEntity, object>> primaryKey) where TEntity : class {
            b.Entity<TEntity>()
                .ToTable(tableName)
                .HasKey(primaryKey);
        }
    }
}

























