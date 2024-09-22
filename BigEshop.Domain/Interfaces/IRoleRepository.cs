using BigEshop.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Interfaces
{
	public interface IRoleRepository
	{
		Task InsertAsync(Role role);

		Task SaveAsync();

		void Update(Role role);

		Task<Role?> GetByIdAsync(int id);

		Task<List<Role>> GetAllAsync();
	}
}
