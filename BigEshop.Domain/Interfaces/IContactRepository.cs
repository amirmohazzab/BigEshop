using BigEshop.Domain.Models.Contact;
using BigEshop.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Interfaces
{
    public interface IContactRepository
    {
        Task InsertAsync(Contact contact);

        Task SaveAsync();
    }
}
