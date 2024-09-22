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
	public class UserRoleRepository(BigEshopContext context) : IUserRoleRepository
	{
		public async Task InsertAsync(UserRole userRole)
			=> await context.UserRoles.AddAsync(userRole);

		public async Task SaveAsync()
			=> await context.SaveChangesAsync();

		public void Update(UserRole userRole)
			=> context.UserRoles.Update(userRole);

		public async Task<List<int>> GetRoleIdsAsync(int userId)
			=> await context.UserRoles.Where(u => u.UserId == userId).Select(r => r.RoleId).ToListAsync();

		public void Remove(UserRole userRole)
			=> context.Remove(userRole);

		public async Task<List<int>> GetUserRoleIdsAsync(int userId)
			=> await context.UserRoles.Where(u => u.UserId == userId).Select(r => r.Id).ToListAsync();
	}	
}
