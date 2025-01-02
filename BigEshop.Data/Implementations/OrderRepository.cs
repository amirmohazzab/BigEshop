using BigEshop.Domain.Interfaces;
using BigEshop.Domain.Models.Order;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Data.Implementations
{
    public class OrderRepository (IDbConnection dbConnection) : IOrderRepository
    {
        public async Task<List<Order>> GetAllByUserIdAsync(int userId)
        {
            string query = $"select * from Orders inner join OrderDetails on OrderDetails.OrderId = Orders.Id where Orders.UserId={userId}";

            var result = await dbConnection.QueryAsync<Order, List<OrderDetail>, Order>(query, (order, orderDetail) =>
            {
                order.OrderDetails = new List<OrderDetail>();
                order.OrderDetails = orderDetail;

                return order;
            }, splitOn: "OrderDetails.OrderId = Orders.Id");

            return result.ToList();
        }
    }
}
