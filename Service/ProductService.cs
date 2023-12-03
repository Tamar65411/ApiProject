using DTO;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService : IProductService
    {
        private IProductRepository repository;
        public ProductService(IProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Product>> getAllProduct( string? desc, int? minPrice, int? maxPrice, int?[] categoriesId)
        {
            return await repository.getAllProduct(   desc,  minPrice,  maxPrice,categoriesId);
        }
        public async Task<IEnumerable<Product>> getProductById(int[] ids)
        {
            IEnumerable<Product> products = await repository.getProductById(ids);
            return products;

        }



    }
}
