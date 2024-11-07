using BigEshop.Application.Services.Interfaces;
using BigEshop.Domain.Interfaces;
using BigEshop.Domain.Models.Contact;
using BigEshop.Domain.ViewModels.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Application.Services.Implementations
{
    public class ContactService (IContactRepository contactRepository) : IContactService
    {
        public async Task<ContactResult> CreateAsync(ContactViewModel model)
        {
            Contact? contact = new()
            {
                FullName = model.FullName,
                ContactNumber = model.ContactNumber,
                Email = model.Email,
                Subject = model.Subject,
                Description = model.Description,
                CreateDate = DateTime.Now
            };

            await contactRepository.InsertAsync(contact);
            await contactRepository.SaveAsync();

            return ContactResult.Success;
        }
    }
}
