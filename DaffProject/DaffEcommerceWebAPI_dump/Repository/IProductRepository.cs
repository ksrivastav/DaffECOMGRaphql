using DaffEcommerceProductService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaffEcommerceProductService.Repository
{
    public interface IProductRepository<T>
    {
        Task<List<T>> getAllItem();
        //T getSingleItem(string a, string b);

        Task<T> getSingleItem(long id);

        Task<long> insertSingleItem(T t);
        Task<T> updateSingleItem(T t);
        void deleteSingleItem(long id);
        Task<List<T>> getAllProductBySeller(long id);
        List<Product> getAllItemProd();
        Product getSingleItemProd(long id);

        Product insertSingleItemProduct(Product t);
        Product updateSingleItemProduct(Product t);
    }
}
