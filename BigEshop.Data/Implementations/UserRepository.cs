using BigEshop.Data.Context;
using BigEshop.Domain.Interfaces;
using BigEshop.Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Data.Implementations
{
    public class UserRepository (BigEshopContext context) : IUserRepository
    {
        public async Task<bool> ExistMobile(string mobile)
        {
            return await context.Users.AnyAsync(u => u.Mobile == mobile);
        }

        public async Task InsertAsync(User user)
        {
            await context.Users.AddAsync(user);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task<User?> GetUserByMobileAndPassword(string mobile, string password)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Mobile == mobile && u.Password == password);
        }

        public async Task<User?> GetByMobileAsync(string mobile)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Mobile == mobile);
        }

        public async Task<User?> GetByMobileAndConfirmCodeAsync(string mobile, string confirmCode)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Mobile == mobile && u.ConfirmCode == confirmCode);
        }

        public void Update(User user)
        {
            context.Users.Update(user);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> DuplicatedMobileAsync(string mobile, int userId)
            => await context.Users.AnyAsync(u => u.Mobile == mobile && u.Id != userId);
    }
}
