using BigEshop.Domain.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllByUserIdAsync(int userId);
    }
}
