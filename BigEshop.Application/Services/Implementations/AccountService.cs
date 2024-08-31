using BigEshop.Application.Security;
using BigEshop.Application.Services.Interfaces;
using BigEshop.Domain.Enums.User;
using BigEshop.Domain.Interfaces;
using BigEshop.Domain.Models.User;
using BigEshop.Domain.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Application.Services.Implementations
{
    public class AccountService (IUserRepository userRepository) : IAccountService
    {
        
        public async Task<RegisterResult> RegisterAsync(RegisterViewModel model)
        {
            if (await userRepository.ExistMobile(model.Mobile))
                return RegisterResult.MobileDuplicated;

            string hashPassword = model.Password.EncodePasswordMd5();

            User user = new()
            {
                CreateDate = DateTime.Now,
                FirstName = null,
                LastName = null,
                Mobile = model.Mobile,
                Password = hashPassword,
                Email = null,
                Status = UserStatus.Active
            };

            await userRepository.InsertAsync(user);
            await userRepository.SaveAsync();

            return RegisterResult.Success;
        }

        public async Task<LoginResult> LoginAsync(LoginViewModel model)
        {
            string hashPassword = model.Password.EncodePasswordMd5();
            User? user = await userRepository.GetUserByMobileAndPassword(model.Mobile, hashPassword);

            if (user == null)
                return LoginResult.UserNotFound;

            if (user.Status == UserStatus.Ban)
                return LoginResult.UserIsBan;


            return LoginResult.Success;
        }
    }
}
