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
        #endregion
    }
}
