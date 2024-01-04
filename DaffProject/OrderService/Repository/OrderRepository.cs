using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderService.DAL;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using OrderService.Domain;
namespace OrderService.Repository
{
    public class OrderRepository : IOrderRepository<Order>
    {
        DaffECommerceDbContext _dbContext;
        public OrderRepository(DaffECommerceDbContext dbContext)
        { _dbContext = dbContext; }
        public async Task<List<Order>> getAllItem()
        {
            List<Order> OrderList = new List<Order>();
            OrderList = await _dbContext.Order.ToListAsync<Order>();
            //.Orders.Include("Order").ToList<Order>();
            return OrderList;
        }
        //T getSingleItem(string a, string b);

        public async Task<Order> getSingleItem(long id)
        {
            Order Order = new Order();
            Order = await _dbContext.Order
            //.Include(x => x.OrderStatus)
            //.Include(y => y.Payment)
            //.Include(x => x.Payment.PaymentStatus)
            //.Include(x => x.User)
            //.Include(x => x.Product)
            .FirstAsync<Order>(x => x.OrderId == id);
            // FindAsync<Order>(x=> x. );
            return Order;
        }

      


    }
}
