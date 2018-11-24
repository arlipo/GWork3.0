using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Open.Data.Goods;
using Open.Data.Users;

namespace Open.Infra {
    public class SentryDbContext : DbContext {
        public SentryDbContext(DbContextOptions<SentryDbContext> o) : base(o) { }

        public SentryDbContext()
        {
        }
        public DbSet<GoodsData> Goods { get; set; }
        public DbSet<ChemistryData> Chemistry { get; set; }
        public DbSet<AccessoriesData> Accessories { get; set; }
        public DbSet<SparePartsData> SpareParts { get; set; }

        //public object Users { get; set; }
        public DbSet<UsersData> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder b) {
            base.OnModelCreating(b);
            b.Entity<GoodsData>().ToTable("Good");
            b.Entity<ChemistryData>().ToTable("Good");
            b.Entity<AccessoriesData>().ToTable("Good");
            b.Entity<SparePartsData>().ToTable("Good");
            b.Entity<UsersData>().ToTable("Users");
            createGoodTable(b);
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

























