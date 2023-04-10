using ApiTestProject.Dtos.RequestDto;
using ApiTestProject.Models;
using AutoMapper;

namespace ApiTestProject.Helper
{
    public class MappeingProfiles : Profile
    {
        public MappeingProfiles() 
        {
            CreateMap<Category,CategoryCreateDto>();   
            CreateMap<CategoryUpdateDto, Category>();   
            CreateMap<CategoryCreateDto,Category>();
            CreateMap<BlogPost, CreateBlogPostDto>();
            CreateMap<CreateBlogPostDto ,BlogPost>();
            CreateMap<BlogPost,BlogPostDto>()
                .ForMember(destinaton => destinaton.CategoryName,opreation=>opreation.MapFrom(source=>source.Category.Name));
        }
    }
}
