using BigEshop.Domain.Models.User;
using BigEshop.Domain.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetByMobileAsync(string mobile);

        Task<EditUserProfileViewModel> GetProfileForEditAsync(int userId);

        Task<EditUserProfileResult> UpdateUserProfileAsync(EditUserProfileViewModel model);

        Task<AdminSideCreateUserResult> CreateAsync(AdminSideCreateUserViewModel model);

        Task<AdminSideEditUserViewModel> AdminSideGetForEditAsync(int id);

        Task<AdminSideEditUserResult> AdminSideUpdateAaync(AdminSideEditUserViewModel model);
    }
}
