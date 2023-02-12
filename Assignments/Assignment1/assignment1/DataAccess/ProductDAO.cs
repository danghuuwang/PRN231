using BusinessObject;
using BusinessObject.DBContext;

namespace DataAccess;

public class ProductDAO
{
    public static List<Product> GetProducts(string? name, decimal minPrice, decimal maxPrice)
    {
        try
        {
            using var context = new DatabaseContext();
            List<Product> products;
            
            if (name == null && minPrice == 0 && maxPrice == 0)
            {
                products = context.Products.ToList();
            }
            else
            {
                products = context.Products
                    .Where(product => product.ProductName.Contains(name))
                    .Where(product => product.UnitPrice >= minPrice)
                    .Where(product => product.UnitPrice <= maxPrice)
                    .ToList();
            }

            return products;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}