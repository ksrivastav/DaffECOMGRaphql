///using Asp.Versioning;
using OrderService.Domain;
using OrderService.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers
{
    //[ApiController]
    ////[Route("api/v{version:aspVersion}/[controller]")]
    [Route("[controller]/[action]")]
    //[ApiVersion("1.0")]
    public class OrderController : Controller
    {
        IOrderService<Order> _OrderService;
        public OrderController(IOrderService<Order> OrderService)
        {
            _OrderService = OrderService;
        }
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View();
        //}




        [HttpGet()]
        public async Task<IEnumerable<Order>> getAllOrders()
        {
            //string userId = User.Identity.Name;
            //Boolean u = User.Identity.IsAuthenticated;
            //ViewData["AuthenticatedUser"] = userId;
            List<Order> prodList = new List<Order>();
            prodList = await _OrderService.getAllItem();
            return prodList;
        }
        [HttpGet("{id}")]
        public async Task<Order> getOrderDetail(long id)
        {
            Order prod = new Order();
            prod = await _OrderService.getSingleItem(id);
            return prod;
        }





    }


}

