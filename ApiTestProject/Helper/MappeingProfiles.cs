using ApiTestProject.Dtos.RequestDto;
using ApiTestProject.Models;
using AutoMapper;

namespace ApiTestProject.Helper
{
    public class MappeingProfiles : Profile
    {
        public MappeingProfiles() 
        {
            CreateMap<CategoryCreateDto,Category>();   
        }
    }
}
