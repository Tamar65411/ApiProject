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
    public class OrdersService : IOrdersService
    {
        private readonly IOrderRepository repository;
        private readonly IProductRepository productRepository;
        public OrdersService(IOrderRepository repository, IProductRepository productRepository)
        {
            this.repository = repository;
            this.productRepository = productRepository;
        }

        public async Task<OrdersTbl> addNewOrder(OrdersTbl newOrder)
        {
       

                ProductDTO product = await productRepository.getProductById(ids);
          

            if (sum == newOrder.OrderSum)
            {

                return await repository.addNewOrder(newOrder);
            }
            return null;
            return await repository.addNewOrder(newOrder);


        }


    }
}
