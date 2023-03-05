using BusinessObject;
using DataAccess.Repository;
using DataAccess.Repository.IRepository;

namespace EStoreAPI.API;

public class ProductAPI
{
    private static IProductRepository productRepository = new ProductRepository();

    public static List<Product> GetProducts(string? name, decimal minPrice, decimal maxPrice)
    {
        return productRepository.GetProducts(name, minPrice, maxPrice);
    }
}