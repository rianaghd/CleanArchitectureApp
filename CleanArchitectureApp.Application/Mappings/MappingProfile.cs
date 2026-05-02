using AutoMapper;
using CleanArchitectureApp.Application.DTOs;
using CleanArchitectureApp.Domain.Entities;

namespace CleanArchitectureApp.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<ProductDto, Product>();
    }
}