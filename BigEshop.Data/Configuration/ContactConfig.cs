using BigEshop.Domain.Models.Contact;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Data.Configuration
{
    public class ContactConfig : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(p => p.Title).IsRequired().HasMaxLength(150);
            builder.Property(p => p.FullName).IsRequired().HasMaxLength(250);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(300);
            builder.Property(p => p.Mobile).IsRequired().HasMaxLength(15);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(800);
        }
    }
}
