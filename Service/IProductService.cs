using Entities;

namespace Service
{
    public interface IProductService
    {
  
        Task<IEnumerable<Product>> getAllProduct( string? desc, int? minPrice, int? maxPrice, int?[] categoriesId);

        Task<IEnumerable<Product>> getProductById(int[] id);
    }
}