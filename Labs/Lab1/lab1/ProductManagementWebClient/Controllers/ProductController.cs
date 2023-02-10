using System.Net.Http.Headers;
using System.Text.Json;
using BusinessObjects;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagementWebClient.Controllers;

public class ProductController : Controller
{
    private readonly HttpClient Client = null;
    private string ProductAPIURL;

    public ProductController()
    {
        Client = new HttpClient();
        var contentType = new MediaTypeWithQualityHeaderValue("application/json");
        ProductAPIURL = "https://localhost:7007/api/products";
    }
    
    public async Task<IActionResult> Index()
    {
        HttpResponseMessage response = await Client.GetAsync(ProductAPIURL);
        string strData = await response.Content.ReadAsStringAsync();
        
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        
        List<Product> listProducts = JsonSerializer.Deserialize<List<Product>>(strData, options);
        return View(listProducts);
    }

    public IActionResult Details()
    {
        return View();
    }

    public IActionResult Delete()
    {
        return View();
    }
}