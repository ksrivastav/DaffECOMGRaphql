using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using DaffEcommerceProductService.Domain;
using DaffEcommerceProductService.DAL;

namespace DaffEcommerceProductService.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository<ProductCategory>
    {
        DaffECommerceDbContext _dbContext;
        public ProductCategoryRepository(DaffECommerceDbContext dbContext)
        { _dbContext = dbContext; }
        public async Task<List<ProductCategory>> getAllItem()
        {
            List<ProductCategory> ProductCategoryList = new List<ProductCategory>();
            ProductCategoryList = await _dbContext.ProductCategory.ToListAsync();
            //.Products.Include("ProductCategory").ToList<Product>();
            return ProductCategoryList;
        }
        //T getSingleItem(string a, string b);

        public async Task<ProductCategory> getSingleItem(long id)
        {
            ProductCategory productCategory = new ProductCategory();
            productCategory = await _dbContext.ProductCategory.FirstAsync(x => x.ProductCategoryId == id);
            // FindAsync<ProductCategory>(x=> x. );
            return productCategory;
        }

        public async Task<long> insertSingleItem(ProductCategory productCategory)
        {
            await _dbContext.AddAsync(productCategory);
            long id = 0;
            id = await _dbContext.SaveChangesAsync();
            return id;
        }
        public async Task<ProductCategory> updateSingleItem(ProductCategory productCategory)
        {
            ProductCategory updatedProductCategory = null;
            try
            {


                updatedProductCategory = await _dbContext.ProductCategory.FirstAsync(x => x.ProductCategoryId == productCategory.ProductCategoryId);

                if (updatedProductCategory != null)
                {
                    updatedProductCategory.Name = productCategory.Name;
                    updatedProductCategory.Description = productCategory.Description;
                    updatedProductCategory.UpdateDateTime = DateTime.Now;
                    updatedProductCategory.tags = productCategory.tags;
                    updatedProductCategory.CreateDateTime = productCategory.CreateDateTime;
                    await _dbContext.SaveChangesAsync();
                    updatedProductCategory = await _dbContext.ProductCategory.FirstAsync(x => x.ProductCategoryId == productCategory.ProductCategoryId);
                    return updatedProductCategory;
                }
                else
                {
                    return updatedProductCategory;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return updatedProductCategory;
            }
        }
        public async void deleteSingleItem(long id)
        {
            ProductCategory productCategory = null;
            try
            {

                productCategory = await _dbContext.ProductCategory.FirstAsync(x => x.ProductCategoryId == productCategory.ProductCategoryId);
                if (productCategory != null)
                {

                    _dbContext.ProductCategory.Remove(productCategory);
                    _dbContext.SaveChanges();


                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
