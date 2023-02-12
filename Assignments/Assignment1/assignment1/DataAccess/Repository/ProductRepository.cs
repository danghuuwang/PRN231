using BusinessObject;
using DataAccess.Repository.IRepository;

namespace DataAccess.Repository;

public class ProductRepository : IProductRepository
{
    public List<Product> GetProducts(string? name, decimal minPrice, decimal maxPrice)
    {
        return ProductDAO.GetProducts(name, minPrice, maxPrice);
    }
}