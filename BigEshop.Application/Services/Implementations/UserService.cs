using BigEshop.Application.Services.Interfaces;
using BigEshop.Domain.Interfaces;
using BigEshop.Domain.Models.User;
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
    }
}
