using BigEshop.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> ExistMobile(string Mobile);

        Task InsertAsync(User user);

        Task SaveAsync();

        Task<User?> GetUserByMobileAndPassword(string mobile, string password);

        Task<User?> GetByMobileAsync(string mobile);

        Task<User?> GetByMobileAndConfirmCodeAsync(string mobile, String confirmCode);

        void Update(User user);

        Task<User?> GetByIdAsync(int id);
    }

}
