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
using VietSovPetro.Data.Infrastructure;
using System;

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
        private readonly IBookRepository bookRepository;
        private readonly IUnitOfWork unitOfWork;

        public VietSovPetroController(IArticleRepository articleRepository, 
            IRoomRepository roomRepository, IRoomPropertyRepository roomPropertyRepository, IRoomPropertyRoomRepository roomPropertyRoomRepository,
            IBookRepository bookRepository, IUnitOfWork unitOfWork)
        {
            this.articleRepository = articleRepository;
            this.roomRepository = roomRepository;
            this.roomPropertyRepository = roomPropertyRepository;
            this.roomPropertyRoomRepository = roomPropertyRoomRepository;
            this.bookRepository = bookRepository;
            this.unitOfWork = unitOfWork;
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
                var articleCategories = a.ArticleCategories;
                var checkCategories = false;
                if (articleCategories != null)
                {
                    foreach (var articleCategory in articleCategories)
                    {
                        if (articleCategory.ArticleCategoryType == "Introduction")
                        {
                            checkCategories = true;
                        }
                    }
                }
                return (a.IsDeleted != true && a.IsPublished && checkCategories
                    && a.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
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
                var articleCategories = a.ArticleCategories;
                var checkCategories = false;
                if (articleCategories != null)
                {
                    foreach (var articleCategory in articleCategories)
                    {
                        if (articleCategory.ArticleCategoryType == "Activity")
                        {
                            checkCategories = true;
                        }
                    }
                }
                return (a.IsDeleted != true && a.IsPublished && checkCategories
                    && a.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
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
                var articleCategories = a.ArticleCategories;
                var checkCategories = false;
                if (articleCategories != null)
                {
                    foreach (var articleCategory in articleCategories)
                    {
                        if (articleCategory.ArticleCategoryType == "News")
                        {
                            checkCategories = true;
                        }
                    }
                }
                return (a.IsDeleted != true && a.IsPublished && checkCategories
                    && a.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
            }).OrderBy(a => a.OrderID))
            {
                var articlevm = Mapper.Map<Article, ArticleViewModel>(article);
                articlevm.ArticleCategoryIDs = article.ArticleCategories.Select(a => a.ArticleCategoryID).ToList();
                articles.Add(articlevm);
            }
            ViewBag.NewsArticles = articles;
            return View();
        }
        public ActionResult Destination()
        {
            var articles = new List<ArticleViewModel>();
            foreach (var article in articleRepository.GetAll().Where(a =>
            {
                var articleCategories = a.ArticleCategories;
                var checkCategories = false;
                if (articleCategories != null)
                {
                    foreach(var articleCategory in articleCategories)
                    {
                        if(articleCategory.ArticleCategoryType == "Destination")
                        {
                            checkCategories = true;
                        }
                    }
                }
                return (a.IsDeleted != true && a.IsPublished && checkCategories
                    && a.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
            }).OrderBy(a => a.OrderID))
            {
                var articlevm = Mapper.Map<Article, ArticleViewModel>(article);
                articlevm.ArticleCategoryIDs = article.ArticleCategories.Select(a => a.ArticleCategoryID).ToList();
                articles.Add(articlevm);
            }
            ViewBag.DestinationArticles = articles;
            return View();
        }
        public ActionResult Partner()
        {
            var articles = new List<ArticleViewModel>();
            foreach (var article in articleRepository.GetAll().Where(a =>
            {
                var articleCategories = a.ArticleCategories;
                var checkCategories = false;
                if (articleCategories != null)
                {
                    foreach (var articleCategory in articleCategories)
                    {
                        if (articleCategory.ArticleCategoryType == "Partner")
                        {
                            checkCategories = true;
                        }
                    }
                }
                return (a.IsDeleted != true && a.IsPublished && checkCategories
                    && a.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
            }).OrderBy(a => a.OrderID))
            {
                var articlevm = Mapper.Map<Article, ArticleViewModel>(article);
                articlevm.ArticleCategoryIDs = article.ArticleCategories.Select(a => a.ArticleCategoryID).ToList();
                articles.Add(articlevm);
            }
            ViewBag.PartnerArticles = articles;
            return View();
        }
        public ActionResult Feedback()
        {
            var articles = new List<ArticleViewModel>();
            foreach (var article in articleRepository.GetAll().Where(a =>
            {
                var articleCategories = a.ArticleCategories;
                var checkCategories = false;
                if (articleCategories != null)
                {
                    foreach (var articleCategory in articleCategories)
                    {
                        if (articleCategory.ArticleCategoryType == "Feedback")
                        {
                            checkCategories = true;
                        }
                    }
                }
                return (a.IsDeleted != true && a.IsPublished && checkCategories
                    && a.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
            }).OrderBy(a => a.OrderID))
            {
                var articlevm = Mapper.Map<Article, ArticleViewModel>(article);
                articlevm.ArticleCategoryIDs = article.ArticleCategories.Select(a => a.ArticleCategoryID).ToList();
                articles.Add(articlevm);
            }
            ViewBag.FeedbackArticles = articles;
            return View();
        }
        public ActionResult MeetingAndEvent()
        {
            ViewBag.MeetingAndEventRooms = roomRepository.GetAll().Where(a =>
                {
                    var firstOrDefault = a.RoomTypes.FirstOrDefault();
                    return firstOrDefault != null && (a.IsDeleted != true && a.IsPublished && firstOrDefault.RoomGroup == "Meeting Room" 
                        && a.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
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
                        && a.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
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
                    && a.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
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
                    && a.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
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
                    && a.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
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
        public ActionResult QuickBook(Book form)
        {
            string fromAddress = ConfigurationManager.AppSettings.Get("SendMailMessagesFromAddress").ToString();
            string toAddress = ConfigurationManager.AppSettings.Get("SendMailSTMPHostAddress").ToString();
            string username = ConfigurationManager.AppSettings.Get("SendMailSMTPUserName").ToString();
            string password = ConfigurationManager.AppSettings.Get("SendMailSMTPUserPassword").ToString();
            Email email = new Email(fromAddress, toAddress, username, password, "Thông tin đặt phòng VietSov Petro", form.Name);
            bool success = email.send();
            form.BookID = Guid.NewGuid();
            bookRepository.Add(form);
            unitOfWork.Commit();
            if (!success)
            {
                return Content("Quá trình gửi thông tin qua email thất bại, thông tin được lưu vào cơ sở dữ liệu tạm!", "text/html");
            }
            return Content("Thông tin đặt phòng của bạn đã được gửi, cảm ơn!", "text/html");
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(FormCollection f)
        {
            return Content("Thông tin liên hệ của bạn đã được gửi, cảm ơn!", "text/html");
        }
    }
}

