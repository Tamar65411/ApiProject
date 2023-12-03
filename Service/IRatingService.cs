using Entities;

namespace Service
{
    public interface IRatingService
    {
        Task addRating(Rating rating);
    }
}