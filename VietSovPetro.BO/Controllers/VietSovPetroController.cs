using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using VietSovPetro.BO.Models;
using VietSovPetro.BO.ViewModels;
using VietSovPetro.Data.Repositories.IRepositories;
using VietSovPetro.Model.Entities;
using VietSovPetro.Core.Common;
using System.Configuration;

namespace VietSovPetro.BO.Controllers
{
    public class VietSovPetroController : BaseController
    {
        //
        // GET: /VietSovPetro/
        private readonly IArticleRepository articleRepository;
        private readonly IRoomRepository roomRepository;
        private readonly IRoomPropertyRepository roomPropertyRepository;
        private readonly IRoomPropertyRoomRepository roomPropertyRoomRepository;

        public VietSovPetroController(IArticleRepository articleRepository, IRoomRepository roomRepository, IRoomPropertyRepository roomPropertyRepository, IRoomPropertyRoomRepository roomPropertyRoomRepository)
        {
            this.articleRepository = articleRepository;
            this.roomRepository = roomRepository;
            this.roomPropertyRepository = roomPropertyRepository;
            this.roomPropertyRoomRepository = roomPropertyRoomRepository;
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
        public ActionResult Activity()
        {
            var articles = new List<ArticleViewModel>();
            foreach (var article in articleRepository.GetAll().Where(a =>
            {
                var firstOrDefault = a.ArticleCategories.FirstOrDefault();
                return firstOrDefault != null && (a.IsDeleted != true && a.IsPublished && firstOrDefault.ArticleCategoryType == "Activity"
                    && firstOrDefault.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
            }).OrderBy(a => a.OrderID))
            {
                var articlevm = Mapper.Map<Article, ArticleViewModel>(article);
                articlevm.ArticleCategoryIDs = article.ArticleCategories.Select(a => a.ArticleCategoryID).ToList();
                articles.Add(articlevm);
            }
            ViewBag.ActivityArticles = articles;
            return View();
        }
        public ActionResult News()
        {
            var articles = new List<ArticleViewModel>();
            foreach (var article in articleRepository.GetAll().Where(a =>
            {
                var firstOrDefault = a.ArticleCategories.FirstOrDefault();
                return firstOrDefault != null && (a.IsDeleted != true && a.IsPublished && firstOrDefault.ArticleCategoryType == "News"
                    && firstOrDefault.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
            }).OrderBy(a => a.OrderID))
            {
                var articlevm = Mapper.Map<Article, ArticleViewModel>(article);
                articlevm.ArticleCategoryIDs = article.ArticleCategories.Select(a => a.ArticleCategoryID).ToList();
                articles.Add(articlevm);
            }
            ViewBag.NewsArticles = articles;
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
            ViewBag.Properties = roomPropertyRoomRepository.GetAll();
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
            ViewBag.Properties = roomPropertyRoomRepository.GetAll();
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
            ViewBag.Properties = roomPropertyRoomRepository.GetAll();
            return View();
        }
        public ActionResult DealingRestaurant()
        {
            ViewBag.Restaurant = roomRepository.GetAll().Where(a =>
            {
                var firstOrDefault = a.RoomTypes.FirstOrDefault();
                return firstOrDefault != null && (a.IsDeleted != true && a.IsPublished && firstOrDefault.RoomGroup == "Restaurant" && a.IsDeal
                    && firstOrDefault.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
            }).OrderBy(a => a.OrderID).ToList();
            ViewBag.Language = RouteData.Values["lang"].ToString().ToLower();
            ViewBag.Properties = roomPropertyRoomRepository.GetAll();
            return View();
        }
        public ActionResult DealingRoom()
        {
            ViewBag.DealingRoom = roomRepository.GetAll().Where(a =>
            {
                var firstOrDefault = a.RoomTypes.FirstOrDefault();
                return firstOrDefault != null && (a.IsDeleted != true && a.IsPublished && (firstOrDefault.RoomGroup == "Room And Price" || firstOrDefault.RoomGroup == "Meeting Room") && a.IsDeal
                    && firstOrDefault.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
            }).OrderBy(a => a.OrderID).ToList();
            ViewBag.Language = RouteData.Values["lang"].ToString().ToLower();
            ViewBag.Properties = roomPropertyRoomRepository.GetAll();
            return View();
        }
        public ActionResult Booking()
        {
            return View();
        }
        [HttpPost]
        public ActionResult QuickBook(BookFormModels form)
        {
            string fromAddress = ConfigurationManager.AppSettings.Get("SendMailMessagesFromAddress").ToString();
            string toAddress = ConfigurationManager.AppSettings.Get("SendMailSTMPHostAddress").ToString();
            string username = ConfigurationManager.AppSettings.Get("SendMailSMTPUserName").ToString();
            string password = ConfigurationManager.AppSettings.Get("SendMailSMTPUserPassword").ToString();
            Email email = new Email(fromAddress, toAddress, username, password, "Thông tin đặt phòng VietSov Petro", form.Name);
            bool success = email.send();
            if (!success)
            {
                return Content("Hệ thông đang bảo trì, vui lòng thử lại vào dịp khác!", "text/html");
            }
            return Content("Thông tin đặt phòng của bạn đã được gửi, cảm ơn!", "text/html");
        }
    }
}

