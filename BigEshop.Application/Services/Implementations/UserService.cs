using BigEshop.Application.Services.Interfaces;
using BigEshop.Domain.Interfaces;
using BigEshop.Domain.Models.User;
using BigEshop.Domain.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Application.Services.Implementations
{
    public class UserService (IUserRepository userRepository) : IUserService
    {
        public async Task<User?> GetByMobileAsync(string mobile)
        {
            return await userRepository.GetByMobileAsync(mobile);
        }

        public async Task<EditUserProfileViewModel> GetProfileForEditAsync(int userId)
        {
            User? user = await userRepository.GetByIdAsync(userId);

            if (user == null)
                return null;

            return new()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        public async Task<EditUserProfileResult> UpdateUserProfileAsync(EditUserProfileViewModel model)
        {

            if (!model.UserId.HasValue)
                return EditUserProfileResult.UserNotFound;


            User? user = await userRepository.GetByIdAsync(model.UserId.Value);

            if (user == null)
                return EditUserProfileResult.UserNotFound;

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;

            userRepository.Update(user);
            await userRepository.SaveAsync();

            return EditUserProfileResult.Success;
        }
    }
}