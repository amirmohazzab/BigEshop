using BigEshop.Data.Context;
using BigEshop.Domain.Interfaces;
using BigEshop.Domain.Models.User;
using BigEshop.Domain.ViewModels.ProductCategory;
using BigEshop.Domain.ViewModels.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

		public async Task<FilterUserViewModel> FilterAsync(FilterUserViewModel model)
		{
			var query = context.Users.AsQueryable();

			if (!string.IsNullOrEmpty(model.FirstName))
			{
				query = query.Where(u => u.FirstName.Contains(model.FirstName));
			}

			query = query.OrderByDescending(u => u.CreateDate);

            await model.Paging(query.Select(u => new UserViewModel()
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Mobile = u.Mobile,
                Email = u.Email,
                Avatar = u.Avatar, 
                Status = u.Status,
                CreateDate = u.CreateDate
            }));

			return model;
		}

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetByEmailAndConfirmCodeAsync(string email, string confirmCode)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Email == email && u.ConfirmCode == confirmCode);
        }
    }
}
