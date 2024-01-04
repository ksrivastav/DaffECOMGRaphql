using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaffEcommerceProductService.Service
{
    public interface IProductSubCategoryService<T>
    {
        Task<List<T>> getAllItem();
        //T getSingleItem(string a, string b);

        Task<T> getSingleItem(long id);

        Task<long> insertSingleItem(T t);
        Task<T> updateSingleItem(T t);
        void deleteSingleItem(long id);
    }
}
