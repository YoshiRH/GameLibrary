using GameLibrary.Api.Entities;
using GameLibrary.Api.Dtos;

namespace GameLibrary.Api.Repositories
{
    public interface IReviewRepository
    {
        Task<Review> GetReviewByIdAsync(int id);
        Task AddReviewAsync(ReviewCreateDto review);
        Task DeleteReviewAsync(int reviewId);

    }
}
