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
	public class RoleService (IRoleRepository roleRepository) : IRoleService
	{
		public async Task<List<Role>> GetAllAsync()
			=> await roleRepository.GetAllAsync();
	}
}
