using DTO;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<OrdersService> _logger;
        private readonly IOrderRepository repository;
        private readonly IProductRepository productRepository;
        public OrdersService(IOrderRepository repository, IProductRepository productRepository, ILogger<OrdersService> logger)
        {
            this.repository = repository;
            this.productRepository = productRepository;
            _logger = logger;
        }

        public async Task<OrdersTbl> addNewOrder(OrdersTbl newOrder)
        {
            int[] ids = new int[newOrder.OrderItemTbls.Count()];
            for (int i = 0; i < newOrder.OrderItemTbls.Count(); i++)
            {
                ids[i] = (int)newOrder.OrderItemTbls.ElementAt(i).ProductId;
            }

            IEnumerable<int> prices = await productRepository.getPricesById(ids);
            int sum = 0;
            for (int i = 0; i < prices.Count(); i++)
            {
                sum += i;
            }
            if(sum==newOrder.OrderSum)
                    return await repository.addNewOrder(newOrder);
           
            _logger.LogInformation("someone try to still");
            _logger.LogError("someone try to still");

            return null;


        }


    }
}
