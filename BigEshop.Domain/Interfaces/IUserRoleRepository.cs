﻿using BigEshop.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Interfaces
{
	public interface IUserRoleRepository
	{
		Task InsertAsync(UserRole userRole);

		void Update(UserRole userRole);

		Task SaveAsync();

        Task<List<int>> GetRoleIdsAsync(int userId);

        Task<List<int>> GetUserRoleIdsAsync(int userId);

        void Remove(UserRole userRole);
    }
}
