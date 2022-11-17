using AutoMapper;
using DomainLayer.Entities;
using ServicesLayer.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductCreateDto, Product>();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();
            CreateMap<Product, ProductListDto>();
        }
    }
}
