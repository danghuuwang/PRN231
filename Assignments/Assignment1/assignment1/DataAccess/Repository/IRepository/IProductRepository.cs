using BusinessObject;

namespace DataAccess.Repository.IRepository;

public interface IProductRepository
{
    List<Product> GetProducts(string? name, decimal minPrice, decimal maxPrice);
}