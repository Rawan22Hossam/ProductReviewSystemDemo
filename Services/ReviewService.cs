using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductReviewSystemDemo.DTO;
using ProductReviewSystemDemo.GenericRepository;
using ProductReviewSystemDemo.Models;
using ProductReviewSystemDemo.Services.Interfaces;

namespace ProductReviewSystemDemo.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Review> _reviewRepo;
        public ReviewService(IGenericRepository<Review> reviewRepo, IMapper mapper)
        {
            _mapper = mapper;
            _reviewRepo = reviewRepo;
        }

        public async Task<IQueryable<ReviewDTO>> GetAllReviewsAsync()
        {
            var reviews = _reviewRepo.GetAll();
            var reviewDTOs = reviews.Select(r => _mapper.Map<ReviewDTO>(r));
            return reviewDTOs;
            // var AllReviews = _mapper.Map<Review>(reviewDTO);
            // var reviews = _reviewRepo.GetAll(r => r.ReviewId).FirstOrDefault();//.Include(r => r.User).Include(r => r.Product);
            // return reviews;
        }

        public async Task<Review> GetReviewById(ReviewDTO reviewDTO)
        {
            return await _reviewRepo.GetById(reviewDTO);
        }
        public async Task AddReviewAsync(Review reviewDTO)
        {
            await _reviewRepo.Add(reviewDTO);
        }
        public async Task UpdateReviewAsync(ReviewDTO reviewDTO)
        {
            await _reviewRepo.Update(reviewDTO);
        }
        public async Task DeleteReviewAsync(ReviewDTO reviewDTO)
        {
            await _reviewRepo.Delete(reviewDTO);
        }
    }
}

