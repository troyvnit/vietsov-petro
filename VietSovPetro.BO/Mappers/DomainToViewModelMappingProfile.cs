using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using VietSovPetro.Model.Entities;
using VietSovPetro.BO.ViewModels;

namespace VietSovPetro.BO.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ArticleCategory, ArticleCategoryViewModel>();
            Mapper.CreateMap<Article, ArticleViewModel>();
        }
    }
}