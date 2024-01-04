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
    public class ProductService : IProductService<Product>
    {
        IProductRepository<Product> _ProductRepository;
        public ProductService(IProductRepository<Product> ProductRepository)
        { _ProductRepository = ProductRepository; }
        public async Task<List<Product>> getAllItem()
        {
            List<Product> ProductList = new List<Product>();
            ProductList = await _ProductRepository.getAllItem();
            //.Products.Include("Product").ToList<Product>();
            return ProductList;
        }
        //T getSingleItem(string a, string b);

        public async Task<Product> getSingleItem(long id)
        {
            Product Product = new Product();
            Product = await _ProductRepository.getSingleItem(id);
            // FindAsync<Product>(x=> x. );
            return Product;
        }

        public async Task<long> insertSingleItem(Product Product)
        {

            long id = 0;
            id = await _ProductRepository.insertSingleItem(Product);
            return id;
        }
        public async Task<Product> updateSingleItem(Product Product)
        {
            Product updatedProduct = await _ProductRepository.updateSingleItem(Product);
            try
            {


                updatedProduct = await _ProductRepository.updateSingleItem(Product);
                return updatedProduct;
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return updatedProduct;
            }
        }
        public async void deleteSingleItem(long id)
        {

            try
            {

                _ProductRepository.deleteSingleItem(id);


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public async Task<List<Product>> getAllProductBySeller(long id)
        {
            return await _ProductRepository.getAllProductBySeller(id);
        }
    }
}
