using EStoreAPI.API;
using Microsoft.AspNetCore.Mvc;

namespace EStoreAPI.Controllers;

public class ProductController : Controller
{
    [HttpGet]
    [Route("api/product/list")]
    public IActionResult GetProducts(string? name, decimal minPrice, decimal maxPrice)
    {
        return Ok(ProductAPI.GetProducts(name, minPrice, maxPrice));
    }
}