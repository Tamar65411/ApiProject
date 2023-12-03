using Entities;

namespace Repository
{
    public interface IOrderRepository
    {
        Task<OrdersTbl> addNewOrder(OrdersTbl newOrder);
    }
}