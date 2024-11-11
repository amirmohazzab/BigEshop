using BigEshop.Application.Services.Interfaces;
using BigEshop.Domain.Interfaces;
using BigEshop.Domain.Models.Contact;
using BigEshop.Domain.ViewModels.ContactUs;
using BigEshop.Application.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BigEshop.Application.Services.Implementations
{
    public class ContactService (IContactRepository contactRepository) : IContactService
    {
        public async Task<ContactResult> CreateAsync(CreateContactViewModel model)
        {
            Contact? contact = new()
            {
                Answer = null,
                AnswerUserId = null,
                FullName = model.FullName,
                Mobile = model.Mobile,
                Email = model.Email,
                Title = model.Title,
                Description = model.Description,
                CreateDate = DateTime.Now,
                AnswerUser = null
            };

            await contactRepository.InsertAsync(contact);
            await contactRepository.SaveAsync();

            return ContactResult.Success;
        }
    }
}
