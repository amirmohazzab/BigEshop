using BigEshop.Domain.Models.User;
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
	}
}
