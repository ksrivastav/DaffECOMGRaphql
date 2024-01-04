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
    public class ProductSubCategoryService : IProductSubCategoryService<ProductSubCategory>
    {
        IProductSubCategoryRepository<ProductSubCategory> _ProductSubCategoryRepository;
        public ProductSubCategoryService(IProductSubCategoryRepository<ProductSubCategory> ProductSubCategoryRepository)
        { _ProductSubCategoryRepository = ProductSubCategoryRepository; }
        public async Task<List<ProductSubCategory>> getAllItem()
        {
            List<ProductSubCategory> ProductSubCategoryList = new List<ProductSubCategory>();
            ProductSubCategoryList = await _ProductSubCategoryRepository.getAllItem();
            //.ProductSubCategorys.Include("ProductSubCategory").ToList<ProductSubCategory>();
            return ProductSubCategoryList;
        }
        //T getSingleItem(string a, string b);

        public async Task<ProductSubCategory> getSingleItem(long id)
        {
            ProductSubCategory ProductSubCategory = new ProductSubCategory();
            ProductSubCategory = await _ProductSubCategoryRepository.getSingleItem(id);
            // FindAsync<ProductSubCategory>(x=> x. );
            return ProductSubCategory;
        }

        public async Task<long> insertSingleItem(ProductSubCategory ProductSubCategory)
        {

            long id = 0;
            id = await _ProductSubCategoryRepository.insertSingleItem(ProductSubCategory);
            return id;
        }
        public async Task<ProductSubCategory> updateSingleItem(ProductSubCategory ProductSubCategory)
        {
            ProductSubCategory updatedProductSubCategory = await _ProductSubCategoryRepository.updateSingleItem(ProductSubCategory);
            try
            {


                updatedProductSubCategory = await _ProductSubCategoryRepository.updateSingleItem(ProductSubCategory);
                return updatedProductSubCategory;
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return updatedProductSubCategory;
            }
        }
        public async void deleteSingleItem(long id)
        {

            try
            {

                _ProductSubCategoryRepository.deleteSingleItem(id);


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
