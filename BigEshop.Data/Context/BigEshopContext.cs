using BigEshop.Domain.Models.Feature;
using BigEshop.Domain.Models.Product;
using BigEshop.Domain.Models.ProductCategory;
using BigEshop.Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Data.Context
{
    public class BigEshopContext : DbContext
    {
        #region Constructor

        public BigEshopContext(DbContextOptions<BigEshopContext> options) : base(options) { }

        #endregion

        #region DbSet

        public DbSet<User> Users { get; set; }

		public DbSet<Role> Roles { get; set; }

		public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set;  }

        public DbSet<ProductGallery> ProductGalleries { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Feature> Features { get; set; }

        public DbSet<ProductFeature> ProductFeatures { get; set; }

        public DbSet<ProductColor> ProductColors { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<RolePermission> RolePermissions { get; set; }

        #endregion

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDelete);
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
