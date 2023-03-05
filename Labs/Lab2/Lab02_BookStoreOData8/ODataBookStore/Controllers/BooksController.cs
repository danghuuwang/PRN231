using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using ODataBookStore.DatabaseContext;

namespace ODataBookStore.Controllers;

public class BooksController : ODataController
{
    private readonly BookStoreContext context;

    public BooksController(BookStoreContext context)
    {
        this.context = context;
        this.context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        if (context.Books.Count() == 0)
        {
            foreach (var book in DataSource.GetBooks())
            {
                this.context.Books.Add(book);
                this.context.Presses.Add(book.Press);
            }

            context.SaveChanges();
        }
    }

    [EnableQuery(PageSize = 1)]
    public IActionResult Get()
    {
        return Ok(context.Books);
    }

    [EnableQuery]
    public IActionResult Delete([FromBody] int key)
    {
        var book = context.Books.FirstOrDefault(b => b.Id == key);
        if (book == null) return NotFound();

        context.Books.Remove(book);
        context.SaveChanges();
        return Ok();
    }
}