using BigEshop.Application.Services.Interfaces;
using BigEshop.Domain.Interfaces;
using BigEshop.Domain.Models.User;
using BigEshop.Domain.ViewModels.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Application.Services.Implementations
{
	public class RoleService (IRoleRepository roleRepository) : IRoleService
	{

        public async Task<List<Role>> GetAllAsync()
          => await roleRepository.GetAllAsync();

        public async Task<CreateRoleResult> CreateAsync(CreateRoleViewModel model)
        {
            Role role = new()
            {
                RoleTitle = model.Title,
                CreateDate = DateTime.Now
            };

            int roleId = await roleRepository.InsertAsync(role);

            foreach(var item in model.SelectedPermission)
            {
                RolePermission rolePermission = new RolePermission
                {
                    PermissionId = item,
                    RoleId = roleId
                };
                await roleRepository.InsertRolePermissionAsync(rolePermission);
            }

            await roleRepository.SaveAsync();
            return CreateRoleResult.Success;
        }

        public async Task<DeleteRoleResult> DeleteAsync(int id)
        {
            var role = await roleRepository.GetByIdAsync(id);

            if (role == null)
                return DeleteRoleResult.RoleNotFound;

            roleRepository.Delete(role);
            await roleRepository.SaveAsync();

            return DeleteRoleResult.Success;
        }

        public async Task<FilterRoleViewModel> FilterAsync(FilterRoleViewModel filter)
        {
            return await roleRepository.FilterAsync(filter);
        }

        public async Task<UpdateRoleViewModel> GetRoleForEditAsync(int id)
        {
            var role = await roleRepository.GetByIdAsync(id);

            if (role == null)
                return null;

            return new UpdateRoleViewModel()
            {
                Id = role.Id,
                Title = role.RoleTitle
            };
        }

        public async Task<UpdateRoleResult> UpdateAsync(UpdateRoleViewModel model)
        {
            var role = await roleRepository.GetByIdAsync(model.Id);

            if (role == null)
                return UpdateRoleResult.RoleNotFound;

            role.RoleTitle = model.Title;

            roleRepository.Update(role);
            await roleRepository.SaveAsync();

            return UpdateRoleResult.Success;
        }

        public async Task<List<Permission>> GetAllPermissionsAsync()
        {
            return await roleRepository.GetAllPermissionsAsync();
        }
    }
}
