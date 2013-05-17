using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;

using VietSovPetro.BO.ViewModels;
using VietSovPetro.Data.Repositories.IRepositories;
using VietSovPetro.Model.Entities;
using VietSovPetro.Core.Common;
using System.Configuration;
using VietSovPetro.Data.Infrastructure;
using System;
using VietSovPetro.BO.Models;

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
                    var roomTypes = a.RoomTypes;
                    var checkRoomTypes = false;
                    if(roomTypes != null)
                    {
                        foreach(var roomType in roomTypes)
                        {
                            if(roomType.RoomGroup == "Meeting Room")
                            {
                                checkRoomTypes = true;
                            }
                        }
                    }
                    return (a.IsDeleted != true && a.IsPublished && checkRoomTypes 
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
                var roomTypes = a.RoomTypes;
                var checkRoomTypes = false;
                if (roomTypes != null)
                {
                    foreach (var roomType in roomTypes)
                    {
                        if (roomType.RoomGroup == "Room And Price")
                        {
                            checkRoomTypes = true;
                        }
                    }
                }
                return (a.IsDeleted != true && a.IsPublished && checkRoomTypes
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
                var roomTypes = a.RoomTypes;
                var checkRoomTypes = false;
                if (roomTypes != null)
                {
                    foreach (var roomType in roomTypes)
                    {
                        if (roomType.RoomGroup == "Restaurant")
                        {
                            checkRoomTypes = true;
                        }
                    }
                }
                return (a.IsDeleted != true && a.IsPublished && checkRoomTypes
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
                var roomTypes = a.RoomTypes;
                var checkRoomTypes = false;
                if (roomTypes != null)
                {
                    foreach (var roomType in roomTypes)
                    {
                        if (roomType.RoomGroup == "Restaurant")
                        {
                            checkRoomTypes = true;
                        }
                    }
                }
                return (a.IsDeleted != true && a.IsPublished && checkRoomTypes && a.IsDeal
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
                var roomTypes = a.RoomTypes;
                var checkRoomTypes = false;
                if (roomTypes != null)
                {
                    foreach (var roomType in roomTypes)
                    {
                        if (roomType.RoomGroup == "Meeting And Event" || roomType.RoomGroup == "Room And Price")
                        {
                            checkRoomTypes = true;
                        }
                    }
                }
                return (a.IsDeleted != true && a.IsPublished && checkRoomTypes && a.IsDeal
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
        public JsonResult QuickBook(BookViewModel form)
        {
            if (!ModelState.IsValid)
            {
                return Json("Thông tin nhập không hợp lệ!");
            }
            var fromAddress = ConfigurationManager.AppSettings.Get("SendMailMessagesFromAddress");
            var toAddress = ConfigurationManager.AppSettings.Get("SendMailSTMPHostAddress");
            var username = ConfigurationManager.AppSettings.Get("SendMailSMTPUserName");
            var password = ConfigurationManager.AppSettings.Get("SendMailSMTPUserPassword");
            var email = new Email(fromAddress, toAddress, username, password, "Thông tin đặt phòng VietSov Petro", form.Name);
            var success = email.send();
            form.BookID = Guid.NewGuid();
            var room = roomRepository.GetById(form.RoomID);
            room.Books.Add(new Book { BookID = Guid.NewGuid(), Name = form.Name, Email = form.Email, Begin = form.Begin, 
                End = form.End, Time = form.Time, GuestQuantity = form.GuestQuantity, MeetingType = form.MeetingType,
                Price = form.Price, Message = form.Message, UserCardName = form.UserCardName, UserCardNumber = form.UserCardNumber,
                UserCardType = form.UserCardType, DueDate = form.DueDate, RoomID = form.RoomID
            });
            roomRepository.Update(room);
            unitOfWork.Commit();
            return Json(!success ? "Quá trình gửi thông tin qua email thất bại, thông tin được lưu vào cơ sở dữ liệu tạm!" : "Thông tin đặt phòng của bạn đã được gửi, cảm ơn!");
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
        public ActionResult _RoomFilter(DateTime begin, DateTime end, string roomGroup, bool IsDeal)
        {
            ViewBag.Rooms = roomRepository.GetAll().Where(a =>
            {
                var roomTypes = a.RoomTypes;
                var checkRoomTypes = false;
                var books = a.Books;
                var checkDate = true;
                if (roomTypes != null)
                {
                    foreach (var roomType in roomTypes)
                    {
                        if (roomType.RoomGroup == roomGroup)
                        {
                            checkRoomTypes = true;
                        }
                    }
                }
                if(books != null)
                {
                    foreach (var book in books)
                    {
                        if((book.End > begin && book.End < end)||(book.Begin > begin && book.Begin < end))
                        {
                            checkDate = false;
                        }
                    }
                }
                return (a.IsDeleted != true && a.IsPublished && checkRoomTypes && checkDate && a.IsDeal == IsDeal
                    && a.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
            }).OrderBy(a => a.OrderID).ToList();
            ViewBag.Properties = roomPropertyRoomRepository.GetAll();
            return View();
        }
    }
}

