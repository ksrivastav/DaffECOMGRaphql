using OrderService.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Service
{
    public interface IOrderService<T>
    {
        Task<List<T>> getAllItem();
        //T getSingleItem(string a, string b);

        Task<T> getSingleItem(long id);





    }
}
