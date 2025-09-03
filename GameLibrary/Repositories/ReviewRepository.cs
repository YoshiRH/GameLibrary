using GameLibrary.Api.Entities;
using GameLibrary.Api.Data;
using GameLibrary.Api.Dtos;
using Microsoft.EntityFrameworkCore;

namespace GameLibrary.Api.Repositories
{
    public class ReviewRepository(GameDbContext context) : IReviewRepository
    {
        private readonly GameDbContext _context = context;

        public async Task AddReviewAsync(ReviewCreateDto review)
        {
            if(review == null)
            {
                throw new ArgumentNullException(nameof(review));
            }

            var game = await _context.Games.FindAsync(review.GameId);

            if(game == null) {
                throw new KeyNotFoundException($"Game not found.");
            }

            var newReview = new Review
            {
                UserName = review.UserName,
                Content = review.Content,
                Rating = review.Rating,
                GameId = review.GameId,
                Game = game
            };

            await _context.Reviews.AddAsync(newReview);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReviewAsync(int reviewId)
        {
            var review = await _context.Reviews.FindAsync(reviewId);

            if (review == null) {
                throw new KeyNotFoundException($"Review not found.");
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
        }

        public async Task<Review> GetReviewByIdAsync(int id)
        {
            var review = await _context.Reviews.FindAsync(id);

            if(review == null) {
                throw new KeyNotFoundException($"Review not found.");
            }

            return review;
        }

    }
}
