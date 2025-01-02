using BigEshop.Application.Generators;
using BigEshop.Application.Security;
using BigEshop.Application.Services.Interfaces;
using BigEshop.Data.Implementations;
using BigEshop.Domain.Enums.User;
using BigEshop.Domain.Interfaces;
using BigEshop.Domain.Models.User;
using BigEshop.Domain.ViewModels.Account;
using Kavenegar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Application.Services.Implementations
{
    public class AccountService 
        (IUserRepository userRepository,
        ISmsSenderService SmsSenderService,
        IEmailSender emailSender) 
        : IAccountService
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
                Email = model.Email,
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

        public async Task<ForgotPasswordResult> ForgotPasswordAsync(ForgotPasswordViewModel model)
        {
            //User? user = await userRepository.GetByMobileAsync(model.Mobile);

            model.Email = model.Email.ToLower().Trim();
            User? user = await userRepository.GetByEmailAsync(model.Email);

            //if (user == null)
            //    return ForgotPasswordResult.MobileNotFound;

            if (user == null)
                return ForgotPasswordResult.EmailNotFound;

                // check if user is active

                string randomCode = CodeGenerator.GenerateCode();

            // send sms

            //var result = SmsSenderService.SendSms(user.Mobile, $"کد تایید شما : {randomCode}");

            //SendResult result = new SendResult();
            //result.Status = 200; 

            //if (result.Status == 200)
            //{
            //    user.ConfirmCode = randomCode;

            //    userRepository.Update(user);
            //    await userRepository.SaveAsync();

            //    return ForgotPasswordResult.Success;
            //}
            //else
            //{
            //    return ForgotPasswordResult.Error;
            //}
            

            string body = $"<h1>کد فراموشی کلمه عبور شما: {randomCode}</h1>";
            emailSender.SendEmail(user.Email, "فراموشی کلمه عبور", body);

            user.ConfirmCode = randomCode;

            userRepository.Update(user);
            await userRepository.SaveAsync();

            return ForgotPasswordResult.Success;
        }

        public async Task<ResetPasswordResult> ResetPasswordAsync(ResetPasswordViewModel model)
        {
            //User? user = await userRepository.GetByMobileAndConfirmCodeAsync(model.Mobile, model.ConfirmCode);
            User? user = await userRepository.GetByEmailAndConfirmCodeAsync(model.Email, model.ConfirmCode);

            if (user == null)
                return ResetPasswordResult.UserNotFound;

            string hashPassword = model.Password.EncodePasswordMd5();
            user.Password = hashPassword;
            user.ConfirmCode = null;

            userRepository.Update(user);
            await userRepository.SaveAsync();


            return ResetPasswordResult.Success;
        }

    }
}
