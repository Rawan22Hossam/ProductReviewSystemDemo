using AutoMapper;
using ProductReviewSystemDemo.DTO;
using ProductReviewSystemDemo.DTO.Product;
using ProductReviewSystemDemo.Models;

namespace ProductReviewSystemDemo.EntityConfiguration
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration() 
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();  
        }
        
    }
}
