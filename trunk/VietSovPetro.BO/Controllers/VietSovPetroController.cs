using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using VietSovPetro.BO.ViewModels;
using VietSovPetro.Data.Repositories.IRepositories;
using VietSovPetro.Model.Entities;

namespace VietSovPetro.BO.Controllers
{
    public class VietSovPetroController : BaseController
    {
        //
        // GET: /VietSovPetro/
        private readonly IArticleRepository articleRepository;
        private readonly IRoomRepository roomRepository;

        public VietSovPetroController(IArticleRepository articleRepository, IRoomRepository roomRepository)
        {
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
            foreach (var article in articleRepository.GetAll().Where(a =>
                {
                    var firstOrDefault = a.ArticleCategories.FirstOrDefault();
                    return firstOrDefault != null && (a.IsDeleted != true && a.IsPublished && firstOrDefault.ArticleCategoryType == "Introduction" 
                        && firstOrDefault.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
                }).OrderBy(a => a.OrderID))
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
            ViewBag.MeetingAndEventRooms = roomRepository.GetAll().Where(a =>
                {
                    var firstOrDefault = a.RoomTypes.FirstOrDefault();
                    return firstOrDefault != null && (a.IsDeleted != true && a.IsPublished && firstOrDefault.RoomGroup == "Meeting Room" 
                        && firstOrDefault.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
                }).OrderBy(a => a.OrderID).ToList();
            ViewBag.Language = RouteData.Values["lang"].ToString().ToLower();
            return View();
        }
        public ActionResult RoomAndPrice()
        {
            ViewBag.RoomAndPrices = roomRepository.GetAll().Where(a =>
                {
                    var firstOrDefault = a.RoomTypes.FirstOrDefault();
                    return firstOrDefault != null && (a.IsDeleted != true && a.IsPublished && firstOrDefault.RoomGroup == "Room And Price" 
                        && firstOrDefault.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
                }).OrderBy(a => a.OrderID).ToList();
            ViewBag.Language = RouteData.Values["lang"].ToString().ToLower();
            return View();
        }
        public ActionResult Restaurant()
        {
            ViewBag.Restaurant = roomRepository.GetAll().Where(a =>
            {
                var firstOrDefault = a.RoomTypes.FirstOrDefault();
                return firstOrDefault != null && (a.IsDeleted != true && a.IsPublished && firstOrDefault.RoomGroup == "Restaurant" 
                    && firstOrDefault.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
            }).OrderBy(a => a.OrderID).ToList();
            ViewBag.Language = RouteData.Values["lang"].ToString().ToLower();
            return View();
        }
        public ActionResult Booking()
        {
            return View();
        }
    }
}
