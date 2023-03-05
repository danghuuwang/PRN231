using System.Net.Http.Headers;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;
using ODataBookStore.Models;

namespace ODataBookStoreWebClient.Controllers;

public class PressController : Controller
{
    private readonly HttpClient client;
    private readonly string ProductApiUrl = "";

    public PressController()
    {
        client = new HttpClient();
        var contentType = new MediaTypeWithQualityHeaderValue("application/json");
        client.DefaultRequestHeaders.Accept.Add(contentType);
        ProductApiUrl = "http://localhost:7010/odata/Presses";
    }

    public async Task<IActionResult> Index()
    {
        var response = await client.GetAsync(ProductApiUrl);
        var strData = await response.Content.ReadAsStringAsync();
        dynamic temp = JsonNode.Parse(strData);

        var lst = temp.value;
        var items = ((JsonArray)temp.value).Select(x => new Press
        {
            Id = (int)x["Id"],
            Name = (string)x["Name"]
        }).ToList();
        return View(items);
    }
}