using BigEshop.Domain.Models.User;
using BigEshop.Domain.ViewModels.Role;
using BigEshop.Domain.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Interfaces
{
	public interface IRoleRepository
	{
		Task<int> InsertAsync(Role role);

		Task SaveAsync();

		void Update(Role role);

		Task<Role?> GetByIdAsync(int id);

		Task<List<Role>> GetAllAsync();

		void Delete(Role role);

		Task<FilterRoleViewModel> FilterAsync(FilterRoleViewModel filter);

		Task InsertRolePermissionAsync(RolePermission rolePermission);

		Task<List<Permission>> GetAllPermissionsAsync();
	}
}
