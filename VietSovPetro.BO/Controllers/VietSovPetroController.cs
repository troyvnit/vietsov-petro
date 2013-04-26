using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using VietSovPetro.BO.ViewModels;
using VietSovPetro.CommandProcessor.Dispatcher;
using VietSovPetro.Data.Repositories.IRepositories;
using VietSovPetro.Model.Entities;

namespace VietSovPetro.BO.Controllers
{
    public class VietSovPetroController : BaseController
    {
        //
        // GET: /VietSovPetro/
        private readonly IArticleCategoryRepository articleCategoryRepository;
        private readonly IArticleRepository articleRepository;
        private readonly IRoomRepository roomRepository;
        private readonly ICommandBus commandBus;
        public VietSovPetroController(IArticleCategoryRepository articleCategoryRepository, ICommandBus commandBus, IArticleRepository articleRepository, IRoomRepository roomRepository)
        {
            this.articleCategoryRepository = articleCategoryRepository;
            this.commandBus = commandBus;
            this.articleRepository = articleRepository;
            this.roomRepository = roomRepository;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Introduction()
        {
            var articles = new List<ArticleViewModel>();
            foreach (Article article in articleRepository.GetAll().Where(a => a.IsDeleted != true && a.IsPublished == true && a.ArticleCategories.FirstOrDefault().ArticleCategoryType == "Introduction"))
            {
                var articlevm = Mapper.Map<Article, ArticleViewModel>(article);
                articlevm.ArticleCategoryIDs = article.ArticleCategories.Select(a => a.ArticleCategoryID).ToList();
                articles.Add(articlevm);
            }
            ViewBag.IntroductionArticles = articles;
            return View();
        }
        public ActionResult MeetingAndEvent()
        {
            ViewBag.MeetingAndEventRooms = roomRepository.GetAll().Where(a => a.IsDeleted != true && a.IsPublished == true && a.RoomTypes.FirstOrDefault().RoomGroup == "Meeting Room").ToList();
            return View();
        }
        public ActionResult RoomAndPrice()
        {
            ViewBag.RoomAndPrices = roomRepository.GetAll().Where(a => a.IsDeleted != true && a.IsPublished == true && a.RoomTypes.FirstOrDefault().RoomGroup == "Room").ToList();
            return View();
        }
    }
}
