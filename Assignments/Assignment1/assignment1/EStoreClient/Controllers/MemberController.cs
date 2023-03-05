using System.Net.Http.Headers;
using System.Text.Json;
using BusinessObject;
using Microsoft.AspNetCore.Mvc;

namespace EStoreClient.Controllers;

public class MemberController : Controller
{
    private readonly HttpClient client;
    private string URL = String.Empty;
    
    public MemberController()
    {
        client = new HttpClient();
        var contentType = new MediaTypeWithQualityHeaderValue("application/json");
        client.DefaultRequestHeaders.Accept.Add(contentType);
    }
    
    public async Task<IActionResult> Login(string email, string password)
    {
        URL = "https://localhost:5001/api/login";
        var response = await client.PostAsJsonAsync(URL, new { email, password });
        if (response.IsSuccessStatusCode)
        {
            var member = await response.Content.ReadAsStringAsync();
            return RedirectToAction("index", "home");
        }
        return BadRequest();
    }
    
    public async Task<IActionResult> Index()
    {
        URL = "https://localhost:7104/api/members";
        var response = await client.GetAsync(URL);
        if (response.IsSuccessStatusCode)
        {
            var strData = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var members = JsonSerializer.Deserialize<List<Member>>(strData, options);
            return View(members);
        }
        return BadRequest();
    }
}