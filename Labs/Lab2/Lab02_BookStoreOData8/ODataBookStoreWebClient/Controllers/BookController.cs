using System.Net.Http.Headers;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;
using ODataBookStore.Models;

namespace ODataBookStoreWebClient.Controllers;

public class BookController : Controller
{
    private readonly HttpClient client;

    private readonly string ProductApiUrl = "";

    public BookController()
    {
        client = new HttpClient();
        var contentType = new MediaTypeWithQualityHeaderValue("application/json");
        client.DefaultRequestHeaders.Accept.Add(contentType);
        ProductApiUrl = "http://localhost:7061/odata/Books";
    }

    public async Task<IActionResult> Index()
    {
        var response = await client.GetAsync(ProductApiUrl);
        var strData = await response.Content.ReadAsStringAsync();

        dynamic temp = JsonNode.Parse(strData);
        var lstBooks = temp.value;

        var items = ((JsonArray)temp.value).Select(x => new Book
        {
            Id = (int)x["Id"],
            ISBN = (string)x["ISBN"],
            Title = (string)x["Title"],
            Author = (string)x["Author"],
            Price = (decimal)x["Price"]
        }).ToList();

        return View(items);
    }
}