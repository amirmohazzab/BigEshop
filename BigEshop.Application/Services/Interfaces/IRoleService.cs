using BigEshop.Domain.Models.User;
using BigEshop.Domain.ViewModels.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Application.Services.Interfaces
{
	public interface IRoleService
	{
		Task<List<Role>> GetAllAsync();

		Task<FilterRoleViewModel> FilterAsync(FilterRoleViewModel filter);

		Task<CreateRoleResult> CreateAsync(CreateRoleViewModel model);

		Task<UpdateRoleViewModel> GetRoleForEditAsync(int id);

		Task<UpdateRoleResult> UpdateAsync(UpdateRoleViewModel model);

		Task<DeleteRoleResult> DeleteAsync(int id);

		Task<List<Permission>> GetAllPermissionsAsync();
	}
}
