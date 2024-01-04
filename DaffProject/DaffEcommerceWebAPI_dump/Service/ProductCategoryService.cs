using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DaffEcommerceProductService.Domain;
using DaffEcommerceProductService.Repository;
namespace DaffEcommerceProductService.Service
{
    public class ProductCategoryService : IProductCategoryService<ProductCategory>
    {
        IProductCategoryRepository<ProductCategory> _ProductCategoryRepository;
        public ProductCategoryService(IProductCategoryRepository<ProductCategory> ProductCategoryRepository)
        { _ProductCategoryRepository = ProductCategoryRepository; }
        public async Task<List<ProductCategory>> getAllItem()
        {
            List<ProductCategory> ProductCategoryList = new List<ProductCategory>();
            ProductCategoryList = await _ProductCategoryRepository.getAllItem();
            //.ProductCategorys.Include("ProductCategory").ToList<ProductCategory>();
            return ProductCategoryList;
        }
        //T getSingleItem(string a, string b);

        public async Task<ProductCategory> getSingleItem(long id)
        {
            ProductCategory ProductCategory = new ProductCategory();
            ProductCategory = await _ProductCategoryRepository.getSingleItem(id);
            // FindAsync<ProductCategory>(x=> x. );
            return ProductCategory;
        }

        public async Task<long> insertSingleItem(ProductCategory ProductCategory)
        {

            long id = 0;
            id = await _ProductCategoryRepository.insertSingleItem(ProductCategory);
            return id;
        }
        public async Task<ProductCategory> updateSingleItem(ProductCategory ProductCategory)
        {
            ProductCategory updatedProductCategory = await _ProductCategoryRepository.updateSingleItem(ProductCategory);
            try
            {


                updatedProductCategory = await _ProductCategoryRepository.updateSingleItem(ProductCategory);
                return updatedProductCategory;
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return updatedProductCategory;
            }
        }
        public async void deleteSingleItem(long id)
        {

            try
            {

                _ProductCategoryRepository.deleteSingleItem(id);


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
