using AutoMapper;
using SampleAppCore.Data.Entites;
using SampleAppCore.Service.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAppCore.Service.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProductCategory, ProductCategoryViewModel>();
        }
    }
}
