using BigEshop.Domain.Models.Chat;
using BigEshop.Domain.Models.Contact;
using BigEshop.Domain.Models.Feature;
using BigEshop.Domain.Models.Order;
using BigEshop.Domain.Models.Product;
using BigEshop.Domain.Models.ProductCategory;
using BigEshop.Domain.Models.Ticket;
using BigEshop.Domain.Models.User;
using BigEshop.Domain.Models.Wallet;
using BigEshop.Domain.Models.Weblog;
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

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<ProductComment> ProductComments { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Wallet> Wallets { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<TicketMessage> TicketMessages { get; set; }

        public DbSet<ProductCommentReaction> ProductCommentReactions { get; set; }

        public DbSet<Weblog> Weblogs { get; set; }

        public DbSet<WeblogCategory> WeblogCategories { get; set; }

        public DbSet<WeblogComment> WeblogComments { get; set; }

        public DbSet<ProductQuestion> ProductQuestions { get; set; }

        public DbSet<ProductAnswer> ProductAnswers { get; set; }

        public DbSet<ProductReaction> ProductReactions { get; set; }

        public DbSet<WeblogCommentAnswer> WeblogCommentAnswers { get; set; }

        public DbSet<ProductVisit> ProductVisits { get; set; }

        public DbSet<WeblogVisit> WeblogVisits { get; set; }

        //public DbSet<Chat> Chats { get; set; }

        //public DbSet<ChatMessages> ChatMessages { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDelete);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

			foreach (var entityType in modelBuilder.Model.GetEntityTypes())
			{
				entityType.GetForeignKeys()
					.Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
					.ToList()
					.ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
			}

			base.OnModelCreating(modelBuilder);
        }
    }
}
