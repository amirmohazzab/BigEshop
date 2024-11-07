using BigEshop.Data.Context;
using BigEshop.Domain.Interfaces;
using BigEshop.Domain.Models.User;
using BigEshop.Domain.ViewModels.Role;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Data.Implementations
{
	public class RoleRepository (BigEshopContext context) : IRoleRepository
	{
        public async Task<List<Role>> GetAllAsync()
			=> await context.Roles.ToListAsync();

		public async Task<Role?> GetByIdAsync(int id)
			=> await context.Roles.FirstOrDefaultAsync(r => r.Id == id);

		public async Task<int> InsertAsync(Role role)
        {
            await context.Roles.AddAsync(role);
            await context.SaveChangesAsync();
            return role.Id;
        }
	
        public async Task SaveAsync()
			=> await context.SaveChangesAsync();

		public void Update(Role role)
			=> context.Roles.Update(role);

        public void Delete(Role role)
        => context.Roles.Remove(role);

        public async Task<FilterRoleViewModel> FilterAsync(FilterRoleViewModel filter)
        {
            var roles = context.Roles.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Title))
                roles = roles.Where(u => EF.Functions.Like(u.RoleTitle, $"%{filter.Title}%"));

            await filter.Paging(roles.Select(role => new RoleViewModel()
            {
                Title = role.RoleTitle,
                CreateDate = role.CreateDate,
                Id = role.Id
            }));

            return filter;
        }

        public async Task InsertRolePermissionAsync(RolePermission rolePermission)
        {
            await context.RolePermissions.AddAsync(rolePermission);
        }

        public async Task<List<Permission>> GetAllPermissionsAsync()
        => await context.Permissions.ToListAsync();

        public int GetPermissionIdByName(string permissionName)
        => context.Permissions.First(r => r.PermissionName == permissionName).PermissionId;

        public List<Role> GetRolesInPermission(string permission)
        {
            int permissionId = GetPermissionIdByName(permission);
            return context.RolePermissions.Include(r => r.Role)
                .Where(r => r.PermissionId == permissionId).Select(r => r.Role).ToList();
        }

        public List<Role> GetRolesUser(int userId)
        {
            return context.UserRoles.Include(r => r.Role).Where(u => u.UserId == userId).Select(r => r.Role).ToList();
        }

        public Task DeleteAllRollPermission(int roleId)
        {
            var rolePermissions = context.RolePermissions.Where(r => r.RoleId == roleId);

            foreach(var role in rolePermissions)
            {
                context.RolePermissions.Remove(role);
            }

            return Task.CompletedTask;
        }

        public async Task<List<RolePermission>> GetPermissionsByRoleIdAsync(int id)
        => await context.RolePermissions.Where(r => r.RoleId == id).ToListAsync();
    }
}
