using App.Domain.Core.Dtos;
using App.Domain.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Data.Repositories.AutoMapper
{
    public class AutoMapperProfileDto : Profile
    {
        public AutoMapperProfileDto()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
        }

    }
}
