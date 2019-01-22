using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
namespace Open.Infra
{
    public abstract class BaseDbContext<T>: DbContext where T: DbContext
    {
        protected BaseDbContext(DbContextOptions<T> o) : base(o) { }
        internal static void createPrimaryKey<TEntity>(ModelBuilder b, string tableName,
            Expression<Func<TEntity, object>> primaryKey) where TEntity : class
        {
            b.Entity<TEntity>()
                .ToTable(tableName)
                .HasKey(primaryKey);
        }
        internal static void createForeignKey<TEntity, TRelatedEntity>(ModelBuilder b,
            string tableName, Expression<Func<TEntity, object>> foreignKey,
            Expression<Func<TEntity, TRelatedEntity>> entity, bool isOptional = false)
            where TEntity : class where TRelatedEntity : class
        {
            b.Entity<TEntity>()
                .ToTable(tableName)
                .HasOne(entity)
                .WithMany()
                .HasForeignKey(foreignKey)
                .OnDelete(isOptional? DeleteBehavior.SetNull: DeleteBehavior.Restrict);
        }

    }
}
