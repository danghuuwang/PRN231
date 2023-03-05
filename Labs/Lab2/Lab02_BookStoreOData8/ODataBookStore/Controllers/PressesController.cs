using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataBookStore.DatabaseContext;

namespace ODataBookStore.Controllers;

public class PressesController : ODataController
{
    private readonly BookStoreContext context;

    public PressesController(BookStoreContext context)
    {
        this.context = context;

        if (this.context.Books.Count() == 0)
        {
            foreach (var book in this.context.Books)
            {
                this.context.Books.Add(book);
                this.context.Presses.Add(book.Press);
            }

            this.context.SaveChanges();
        }
    }

    [EnableQuery]
    public IActionResult Get()
    {
        return Ok(context.Presses);
    }
}