using BigEshop.Domain.ViewModels.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Application.Services.Interfaces
{
    public interface IContactService
    {
        Task<ContactResult> CreateAsync(ContactViewModel model);
    }
}
