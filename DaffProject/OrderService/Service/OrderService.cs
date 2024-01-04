using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderService.Domain;
using Microsoft.EntityFrameworkCore;
using OrderService.Repository;
namespace OrderService.Service
{
    public class OrderService : IOrderService<Order>
    {
        IOrderRepository<Order> _orderRepository;
        public OrderService(IOrderRepository<Order> orderRepository)
        { _orderRepository = orderRepository; }
        public async Task<List<Order>> getAllItem()
        {
            List<Order> OrderList = new List<Order>();
            OrderList = await _orderRepository.getAllItem();
            //.Orders.Include("Order").ToList<Order>();
            return OrderList;
        }
        //T getSingleItem(string a, string b);

        public async Task<Order> getSingleItem(long id)
        {
            Order Order = new Order();
            Order = await _orderRepository.getSingleItem(id);
            // FindAsync<Order>(x=> x. );
            return Order;
        }

    
    }
}
