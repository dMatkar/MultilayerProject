using Microsoft.EntityFrameworkCore;
using Project.Core;
using Project.Data.Mapping;
using System;
using System.Linq;
using System.Reflection;

namespace Project.Data
{
    public class ProjectDataContext : DbContext
    {
        #region Constructor

        public ProjectDataContext(DbContextOptions options) : base(options)
        {
        }

        #endregion

        #region Utilities        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var typeConfigurations = Assembly.GetExecutingAssembly().GetTypes().Where(type =>
                (type.BaseType?.IsGenericType ?? false)
                    && (type.BaseType.GetGenericTypeDefinition() == typeof(ProjectEntityTypeConfiguration<>)
                        || type.BaseType.GetGenericTypeDefinition() == typeof(ProjectEntityTypeConfiguration<>)));

            foreach (var typeConfiguration in typeConfigurations)
            {
                var configuration = (IMappingConfiguration)Activator.CreateInstance(typeConfiguration);
                configuration.ApplyConfiguration(modelBuilder);
            }

            base.OnModelCreating(modelBuilder);
        }

        #endregion

        #region Methods

        public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        #endregion
    }
}
