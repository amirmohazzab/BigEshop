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
	public class RoleRepository (BigEshopContext context) : IRoleRepository
	{
		public async Task<List<Role>> GetAllAsync()
			=> await context.Roles.ToListAsync();

		public async Task<Role?> GetByIdAsync(int id)
			=> await context.Roles.FirstOrDefaultAsync(r => r.Id == id);

		public async Task InsertAsync(Role role)
		=> await context.Roles.AddAsync(role);

		public async Task SaveAsync()
			=> await context.SaveChangesAsync();

		public void Update(Role role)
			=> context.Roles.Update(role);
	}
}
