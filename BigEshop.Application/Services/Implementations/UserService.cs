using BigEshop.Application.Security;
using BigEshop.Application.Services.Interfaces;
using BigEshop.Data.Implementations;
using BigEshop.Domain.Interfaces;
using BigEshop.Domain.Models.User;
using BigEshop.Domain.ViewModels.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Application.Services.Implementations
{
    public class UserService 
        (IUserRepository userRepository,
		IUserRoleRepository userRoleRepository) 
        : IUserService
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

		public async Task<AdminSideCreateUserResult> CreateAsync(AdminSideCreateUserViewModel model)
		{
            if (await userRepository.ExistMobile(model.Mobile))
                return AdminSideCreateUserResult.MobileDuplicated;

            if (model.RoleIds.Count < 1)
                return AdminSideCreateUserResult.NotSelectedRole;

			User? user = new()
            {
                CreateDate = DateTime.Now,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Mobile = model.Mobile,
                Password = model.Password.EncodePasswordMd5(),
                Email = model.Email,
                Status = model.Status,
                IsDelete = false
            };

			if (model.Avatar != null)
			{
				string imageName = Guid.NewGuid().ToString() + Path.GetExtension(model.Avatar.FileName);
				string savedPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Avatars", imageName);

				using (var stream = System.IO.File.Create(savedPath))
				{
					model.Avatar.CopyTo(stream);
				}
				user.Avatar = imageName;
			}

			await userRepository.InsertAsync(user);
            await userRepository.SaveAsync();

			foreach (var item in model.RoleIds)
			{
                await userRoleRepository.InsertAsync(new UserRole
                {
                    CreateDate = DateTime.Now,
                    RoleId = item,
                    UserId = user.Id
                });
			}

            await userRoleRepository.SaveAsync();

			return AdminSideCreateUserResult.Success;
		}

        public async Task<AdminSideEditUserViewModel> AdminSideGetForEditAsync(int userId)
        {
            User? user = await userRepository.GetByIdAsync(userId);

            if (user == null)
                return null;

            List<int> roleIds = await userRoleRepository.GetUserRoleIdsAsync(userId);

            return new AdminSideEditUserViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Mobile = user.Mobile,
                Email = user.Email,
                Status = user.Status,
                RoleIds = roleIds,
                Avatar = user.Avatar
            };  
        }

        public async Task<AdminSideEditUserResult> AdminSideUpdateAaync(AdminSideEditUserViewModel model)
        {
            User? user = await userRepository.GetByIdAsync(model.Id);

            if (user == null)
                return AdminSideEditUserResult.UserNotFound;

            if (model.RoleIds.Count < 1)
                return AdminSideEditUserResult.NotSelectedRole;

            if (await userRepository.DuplicatedMobileAsync(model.Mobile, user.Id))
                return AdminSideEditUserResult.UserNotFound;

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Mobile = model.Mobile;
            user.Email = model.Email;
            user.Status = model.Status;

            if (model.NewAvatar != null)
            {
                if (user.Avatar != null)
                {
                    string deletedPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Avatars", user.Avatar);
                    if (System.IO.File.Exists(deletedPath))
                        System.IO.File.Delete(deletedPath);
                }
                string imageName = Guid.NewGuid().ToString() + Path.GetExtension(model.NewAvatar.FileName);
                string savedPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Avatars", imageName);

                using (var stream = System.IO.File.Create(savedPath))
                {
                    model.NewAvatar.CopyTo(stream);
                }
                user.Avatar = imageName;
            }

            userRepository.Update(user);
            await userRepository.SaveAsync();


            var userRoleIds = await userRoleRepository.GetUserRoleIdsAsync(user.Id);

            foreach (var userRoleId in userRoleIds)
                userRoleRepository.Remove(new UserRole
                {
                    Id = userRoleId
                });

            await userRoleRepository.SaveAsync();

            foreach (var item in model.RoleIds)
            {
                await userRoleRepository.InsertAsync(new UserRole
                {
                    CreateDate = DateTime.Now,
                    RoleId = item,
                    UserId = user.Id
                });
               
            }

            await userRoleRepository.SaveAsync();

            return AdminSideEditUserResult.Success;
        }
    }
}