using BigEshop.Data.Context;
using BigEshop.Domain.Interfaces;
using BigEshop.Domain.Models.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Data.Implementations
{
    public class ContactRepository (BigEshopContext context) : IContactRepository
    {
        public async Task InsertAsync(Contact contact)
        => await context.Contacts.AddAsync(contact);

        public async Task SaveAsync()
        => await context.SaveChangesAsync();
    }
}
