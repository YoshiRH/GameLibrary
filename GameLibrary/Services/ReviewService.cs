using GameLibrary.Api.Entities;
using GameLibrary.Api.Repositories;
using GameLibrary.Api.Dtos;

namespace GameLibrary.Api.Services
{
    public class ReviewService(IReviewRepository reviewRepository, IGameRepository gameRepository) : IReviewService
    {
        private readonly IReviewRepository _reviewRepository = reviewRepository;
        private readonly IGameRepository _gameRepository = gameRepository;

        public async Task AddReviewAsync(ReviewCreateDto review)
        {
            if(review == null)
            {
                throw new ArgumentNullException(nameof(review));
            }

            var game = _gameRepository.GetGameByIdAsync(review.GameId);

            if (game == null) {
                throw new KeyNotFoundException($"Game not found.");
            }

            await _reviewRepository.AddReviewAsync(review);
        }

        public async Task DeleteReviewAsync(int reviewId)
        {
            var review = _reviewRepository.GetReviewByIdAsync(reviewId);

            if(review == null) {
                throw new KeyNotFoundException($"Review not found.");
            }

            await _reviewRepository.DeleteReviewAsync(reviewId);
        }

        public async Task<ReviewDto> GetReviewByIdAsync(int id)
        {
            var review = await _reviewRepository.GetReviewByIdAsync(id);

            if(review == null) {
                throw new KeyNotFoundException($"Review not found.");
            }

            var reviewDto = new ReviewDto
            {
                Id = review.Id,
                UserName = review.UserName,
                Content = review.Content,
                Rating = review.Rating,
                GameId = review.GameId,
                Game = review.Game
            };

            return reviewDto;
        }
    }
}
