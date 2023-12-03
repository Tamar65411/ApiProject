using Entities;

namespace Repository
{
    public interface IRatingRepository
    {
        Task addRating(Rating rating);
    }
}