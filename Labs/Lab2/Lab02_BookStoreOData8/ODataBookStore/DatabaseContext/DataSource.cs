using ODataBookStore.Models;

namespace ODataBookStore.DatabaseContext;

public static class DataSource
{
    private static IList<Book> listBooks { get; set; }

    public static IList<Book> GetBooks()
    {
        if (listBooks != null) return listBooks;

        listBooks = new List<Book>();
        var book1 = new Book
        {
            Id = 1,
            ISBN = "978-1-4842-4242-1",
            Title = "Professional C# 7 and .NET Core 2.0",
            Author = "Wrox Press",
            Price = 59.99m,
            Location = new Address
            {
                City = "Redmond",
                Street = "WA"
            },
            Press = new Press
            {
                Id = 1,
                Name = "Wrox Press",
                Category = Category.Book
            }
        };
        var book2 = new Book
        {
            Id = 2,
            ISBN = "978-0137081073",
            Title = "Clean Code: A Handbook of Agile Software Craftsmanship",
            Author = "Robert C. Martin",
            Price = 39.99m,
            Location = new Address
            {
                City = "New York",
                Street = "NY"
            },
            Press = new Press
            {
                Id = 2,
                Name = "Prentice Hall",
                Category = Category.Book
            }
        };

        var book3 = new Book
        {
            Id = 3,
            ISBN = "9772679204005",
            Title = "National Geographic",
            Author = "National Geographic Partners",
            Price = 10.99m,
            Location = new Address
            {
                City = "Washington",
                Street = "DC"
            },
            Press = new Press
            {
                Id = 3,
                Name = "Prentice Hall",
                Category = Category.Magazine
            }
        };

        listBooks.Add(book1);
        listBooks.Add(book2);
        listBooks.Add(book3);

        return listBooks;
    }
}