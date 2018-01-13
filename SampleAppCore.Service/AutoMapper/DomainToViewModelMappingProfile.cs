﻿using AutoMapper;
using SampleAppCore.Data.Entites;
using SampleAppCore.Service.ViewModel.Product;
using SampleAppCore.Service.ViewModel.System;
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
            CreateMap<Product, ProductViewModel>();

            CreateMap<Function, FunctionViewModel>();
            CreateMap<AppUser, AppUserViewModel>();
            CreateMap<AppRole, AppRoleViewModel>();
        }
    }
}
