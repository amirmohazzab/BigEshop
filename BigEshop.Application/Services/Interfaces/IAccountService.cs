﻿using BigEshop.Domain.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Application.Services.Interfaces
{
    public interface IAccountService
    {
        Task<RegisterResult> RegisterAsync(RegisterViewModel model);

        Task<LoginResult> LoginAsync(LoginViewModel model);

        Task<ForgotPasswordResult> ForgotPasswordAsync(ForgotPasswordViewModel model);

        Task<ResetPasswordResult> ResetPasswordAsync(ResetPasswordViewModel model);
    }
}
