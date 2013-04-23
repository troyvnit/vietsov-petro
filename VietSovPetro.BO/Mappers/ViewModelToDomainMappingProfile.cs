using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using VietSovPetro.Domain.Commands;
using VietSovPetro.BO.ViewModels;


namespace VietSovPetro.BO.Mappers
{
    class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ArticleCategoryViewModel, CreateOrUpdateArticleCategoryCommand>();
            Mapper.CreateMap<ArticleCategoryViewModel, DeleteArticleCategoryCommand>();
            Mapper.CreateMap<ArticleViewModel, CreateOrUpdateArticleCommand>();
            Mapper.CreateMap<RoomViewModel, CreateOrUpdateRoomCommand>();
            Mapper.CreateMap<RoomTypeViewModel, CreateOrUpdateRoomTypeCommand>();
            Mapper.CreateMap<RoomPropertyViewModel, CreateOrUpdateRoomPropertyCommand>();
        }
    }
}