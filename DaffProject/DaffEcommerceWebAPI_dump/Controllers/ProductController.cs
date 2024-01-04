using Asp.Versioning;
using DaffEcommerceProductService.Consumer;
using DaffEcommerceProductService.Domain;
using DaffEcommerceProductService.Service;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DaffEcommerceProductService.Controllers
{
    [ApiController]
    //[Route("api/v{version:aspVersion}/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiVersion("1.0")]
    public class ProductController : Controller
    {
        IProductService<Product> _productService;
         ProductConsumer _productConsumer; //, ProductConsumer productConsumer)
        public ProductController(IProductService<Product> productService, IProductSubCategoryService<ProductSubCategory> productSubCategoryService, IProductCategoryService<ProductCategory> productCategoryService, ProductConsumer productConsumer)    
            
        {
            _productService = productService;
            _productConsumer = productConsumer;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet()]
        public async Task<IActionResult> getAllProductsGraphQL()
        {
            var prodList = await _productConsumer.GetAllProduct();
            //return prodList;


            return Ok(prodList);
        }



        [HttpGet()]
        public async Task<IEnumerable<Product>> getAllProducts()
        {
            //string userId = User.Identity.Name;
            //Boolean u = User.Identity.IsAuthenticated;
            //ViewData["AuthenticatedUser"] = userId;
            List<Product> prodList = new List<Product>();
            prodList = await _productService.getAllItem();
            return prodList;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getProductDetail(long id)
        {
            Product prod = new Product();
            prod = await _productService.getSingleItem(id);
            return View(prod);
        }





    }


}

namespace DaffEcommerceProductService.Controllers.v2
{
    [ApiController]
    //[Route("api/v{version:aspVersion}/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiVersion("2.0")]
    public class ProductController : Controller
    {
        IProductService<Product> _productService;
        public ProductController(IProductService<Product> productService, IProductSubCategoryService<ProductSubCategory> productSubCategoryService, IProductCategoryService<ProductCategory> productCategoryService)
        {
            _productService = productService;
        }
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View();
        //}




        [HttpGet()]
        public async Task<IEnumerable<Product>> getAllProducts()
        {
            //string userId = User.Identity.Name;
            //Boolean u = User.Identity.IsAuthenticated;
            //ViewData["AuthenticatedUser"] = userId;
            List<Product> prodList = new List<Product>();
            prodList = await _productService.getAllItem();
            return prodList;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getProductDetail(long id)
        {
            Product prod = new Product();
            prod = await _productService.getSingleItem(id);
            return View(prod);
        }





    }


}
