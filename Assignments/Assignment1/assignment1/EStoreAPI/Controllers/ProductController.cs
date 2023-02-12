using DataAccess.Repository;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace EStoreAPI.Controllers;

public class ProductController : Controller
{
    private IProductRepository productRepository = new ProductRepository();
    
    [HttpGet]
    [Route("api/product/list")]
    public IActionResult GetProducts(string? name, decimal minPrice, decimal maxPrice)
    {
        return Ok(productRepository.GetProducts(name, minPrice, maxPrice));
    }
}