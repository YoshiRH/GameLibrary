using GameLibrary.Api.Entities;
using GameLibrary.Api.Repositories;
using GameLibrary.Api.Dtos;

namespace GameLibrary.Api.Services
{
    public interface IReviewService
    {
        Task<ReviewDto> GetReviewByIdAsync(int id);
        Task AddReviewAsync(ReviewCreateDto review);
        Task DeleteReviewAsync(int reviewId);
    }
}
