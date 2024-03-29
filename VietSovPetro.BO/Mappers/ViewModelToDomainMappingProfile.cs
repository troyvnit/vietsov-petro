﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using VietSovPetro.Domain.Commands;
using VietSovPetro.BO.ViewModels;


namespace VietSovPetro.BO.Mappers
{
    using VietSovPetro.BO.Controllers;

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
            Mapper.CreateMap<DeleteArticle, DeleteArticleCommand>();
            Mapper.CreateMap<RoomViewModel, CreateOrUpdateRoomCommand>();
            Mapper.CreateMap<DeleteRoom, DeleteRoomCommand>();
            Mapper.CreateMap<RoomTypeViewModel, CreateOrUpdateRoomTypeCommand>();
            Mapper.CreateMap<RoomTypeViewModel, DeleteRoomTypeCommand>();
            Mapper.CreateMap<RoomPropertyViewModel, CreateOrUpdateRoomPropertyCommand>();
            Mapper.CreateMap<RoomPropertyViewModel, DeleteRoomPropertyCommand>();
        }
    }
}