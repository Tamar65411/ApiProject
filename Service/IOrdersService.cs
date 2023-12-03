using Entities;

namespace Service
{
    public interface IOrdersService
    {
        Task<OrdersTbl> addNewOrder(OrdersTbl newOrder);
        
    }
}