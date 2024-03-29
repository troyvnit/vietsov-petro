﻿using System.Collections.Generic;
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
    using System.Globalization;

    public class VietSovPetroController : BaseController
    {
        //
        // GET: /VietSovPetro/
        private readonly IArticleRepository articleRepository;
        private readonly IRoomRepository roomRepository;

        private readonly IRoomPropertyRoomRepository roomPropertyRoomRepository;

        private readonly IUnitOfWork unitOfWork;

        public VietSovPetroController(IArticleRepository articleRepository,
            IRoomRepository roomRepository, IRoomPropertyRoomRepository roomPropertyRoomRepository, IUnitOfWork unitOfWork)
        {
            this.articleRepository = articleRepository;
            this.roomRepository = roomRepository;
            this.roomPropertyRoomRepository = roomPropertyRoomRepository;
            this.unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            ViewBag.RoomAndPrices = roomRepository.GetAll().Where(a =>
            {
                var roomTypes = a.RoomTypes;
                var checkRoomTypes = false;
                if (roomTypes != null)
                {
                    foreach (var roomType in roomTypes)
                    {
                        if (roomType.RoomTypeID == Guid.Parse("22222222-2222-2222-2222-222222222223"))
                        {
                            checkRoomTypes = true;
                        }
                    }
                }
                return (a.IsDeleted != true && a.IsPublished && checkRoomTypes && a.IsNew
                    && a.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
            }).OrderBy(a => a.OrderID).ThenBy(a => a.UpdatedOn).ThenBy(a => a.CreatedOn).ToList();
            ViewBag.Language = RouteData.Values["lang"].ToString().ToLower();
            var rarticles = new List<ArticleViewModel>();
            foreach (var article in articleRepository.GetAll().Where(a =>
            {
                var articleCategories = a.ArticleCategories;
                var checkCategories = false;
                if (articleCategories != null)
                {
                    foreach (var articleCategory in articleCategories)
                    {
                        if (articleCategory.ArticleCategoryID == Guid.Parse("99999999-9999-9999-9999-999999999100"))
                        {
                            checkCategories = true;
                        }
                    }
                }
                return (a.IsDeleted != true && a.IsPublished && checkCategories && a.IsNew
                    && a.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
            }).OrderBy(a => a.OrderID).ThenBy(a => a.UpdatedOn).ThenBy(a => a.CreatedOn))
            {
                var articlevm = Mapper.Map<Article, ArticleViewModel>(article);
                articlevm.ArticleCategoryIDs = article.ArticleCategories.Select(a => a.ArticleCategoryID).ToList();
                rarticles.Add(articlevm);
            }
            ViewBag.DealingRestaurantArticles = rarticles;
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
                        if (articleCategory.ArticleCategoryID == Guid.Parse("11111111-1111-1111-1111-111111111111"))
                        {
                            checkCategories = true;
                        }
                    }
                }
                return (a.IsDeleted != true && a.IsPublished && checkCategories
                    && a.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
            }).OrderBy(a => a.OrderID).ThenBy(a => a.UpdatedOn).ThenBy(a => a.CreatedOn))
            {
                var articlevm = Mapper.Map<Article, ArticleViewModel>(article);
                articlevm.ArticleCategoryIDs = article.ArticleCategories.Select(a => a.ArticleCategoryID).ToList();
                articles.Add(articlevm);
            }
            ViewBag.IntroductionArticles = articles;
            return View();
        }
        public ActionResult DetailPage(Guid articleID, Guid categoryID)
        {
            //var article = articleRepository.GetById(articleID);
            //var articlevm = Mapper.Map<Article, ArticleViewModel>(article);
            var articles = new List<ArticleViewModel>();
            foreach (var article in articleRepository.GetAll().Where(a => a.IsDeleted != true && a.IsPublished && a.RoomID == categoryID && a.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower())
                .OrderBy(a => a.OrderID).ThenBy(a => a.UpdatedOn).ThenBy(a => a.CreatedOn))
            {
                var articlevm = Mapper.Map<Article, ArticleViewModel>(article);
                articlevm.ArticleCategoryIDs = article.ArticleCategories.Select(a => a.ArticleCategoryID).ToList();
                articles.Add(articlevm);
            }
            ViewBag.Articles = articles;
            ViewBag.Article = articles.FirstOrDefault(a => a.ArticleID == articleID);
            return View();
        }
        public ActionResult CategoryPage(Guid categoryID)
        {
            var articles = new List<ArticleViewModel>();
            foreach (var article in articleRepository.GetAll().Where(a => a.IsDeleted != true && a.IsPublished && a.RoomID == categoryID && a.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower())
                .OrderBy(a => a.OrderID).ThenBy(a => a.UpdatedOn).ThenBy(a => a.CreatedOn))
            {
                var articlevm = Mapper.Map<Article, ArticleViewModel>(article);
                articlevm.ArticleCategoryIDs = article.ArticleCategories.Select(a => a.ArticleCategoryID).ToList();
                articles.Add(articlevm);
            }
            ViewBag.Articles = articles;
            ViewBag.CategoryID = categoryID;
            return View();
        }
        public ActionResult Activity()
        {
            ViewBag.Restaurant = roomRepository.GetAll().Where(a =>
            {
                var roomTypes = a.RoomTypes;
                var checkRoomTypes = false;
                if (roomTypes != null)
                {
                    foreach (var roomType in roomTypes)
                    {
                        if (roomType.RoomTypeID == Guid.Parse("33333333-3333-3333-3333-333333333335"))
                        {
                            checkRoomTypes = true;
                        }
                    }
                }
                return (a.IsDeleted != true && a.IsPublished && checkRoomTypes
                    && a.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
            }).OrderBy(a => a.OrderID).ThenBy(a => a.UpdatedOn).ThenBy(a => a.CreatedOn).ToList();
            ViewBag.Language = RouteData.Values["lang"].ToString().ToLower();
            ViewBag.Properties = roomPropertyRoomRepository.GetAll();
            var articles = new List<ArticleViewModel>();
            foreach (var article in articleRepository.GetAll().Where(a =>
            {
                var articleCategories = a.ArticleCategories;
                var checkCategories = false;
                if (articleCategories != null)
                {
                    foreach (var articleCategory in articleCategories)
                    {
                        if (articleCategory.ArticleCategoryID == Guid.Parse("11111111-1111-1111-1111-111111111112"))
                        {
                            checkCategories = true;
                        }
                    }
                }
                return (a.IsDeleted != true && a.IsPublished && checkCategories && a.RoomID == null
                    && a.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
            }).OrderBy(a => a.OrderID).ThenBy(a => a.UpdatedOn).ThenBy(a => a.CreatedOn))
            {
                var articlevm = Mapper.Map<Article, ArticleViewModel>(article);
                articlevm.ArticleCategoryIDs = article.ArticleCategories.Select(a => a.ArticleCategoryID).ToList();
                articles.Add(articlevm);
            }
            ViewBag.RestaurantArticles = articles;
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
                        if (articleCategory.ArticleCategoryID == Guid.Parse("33333333-3333-3333-3333-333333333333"))
                        {
                            checkCategories = true;
                        }
                    }
                }
                return (a.IsDeleted != true && a.IsPublished && checkCategories
                    && a.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
            }).OrderBy(a => a.OrderID).ThenBy(a => a.UpdatedOn).ThenBy(a => a.CreatedOn))
            {
                var articlevm = Mapper.Map<Article, ArticleViewModel>(article);
                articlevm.ArticleCategoryIDs = article.ArticleCategories.Select(a => a.ArticleCategoryID).ToList();
                articles.Add(articlevm);
            }
            ViewBag.NewsArticles = articles;
            return View();
        }
        public ActionResult Destination(int page = 1)
        {
            var pageSize = Int32.Parse(ConfigurationManager.AppSettings.Get("DestinationPageSize"));
            var articles = new List<ArticleViewModel>();
            foreach (var article in articleRepository.GetAll().Where(a =>
            {
                var articleCategories = a.ArticleCategories;
                var checkCategories = false;
                if (articleCategories != null)
                {
                    foreach (var articleCategory in articleCategories)
                    {
                        if (articleCategory.ArticleCategoryID == Guid.Parse("44444444-4444-4444-4444-444444444444"))
                        {
                            checkCategories = true;
                        }
                    }
                }
                return (a.IsDeleted != true && a.IsPublished && checkCategories
                    && a.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
            }).Skip((page - 1) * pageSize).Take(pageSize).OrderBy(a => a.OrderID).ThenBy(a => a.UpdatedOn).ThenBy(a => a.CreatedOn))
            {
                var articlevm = Mapper.Map<Article, ArticleViewModel>(article);
                articlevm.ArticleCategoryIDs = article.ArticleCategories.Select(a => a.ArticleCategoryID).ToList();
                articles.Add(articlevm);
            }
            ViewBag.DestinationArticles = articles;
            ViewBag.Page = page;
            ViewBag.Count = articles.Count;
            return View();
        }
        public ActionResult Partner(int page = 1)
        {
            var pageSize = Int32.Parse(ConfigurationManager.AppSettings.Get("PartnerPageSize"));
            var articles = new List<ArticleViewModel>();
            foreach (var article in articleRepository.GetAll().Where(a =>
            {
                var articleCategories = a.ArticleCategories;
                var checkCategories = false;
                if (articleCategories != null)
                {
                    foreach (var articleCategory in articleCategories)
                    {
                        if (articleCategory.ArticleCategoryID == Guid.Parse("55555555-5555-5555-5555-555555555555"))
                        {
                            checkCategories = true;
                        }
                    }
                }
                return (a.IsDeleted != true && a.IsPublished && checkCategories
                    && a.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
            }).Skip((page - 1) * pageSize).Take(pageSize).OrderBy(a => a.OrderID).ThenBy(a => a.UpdatedOn).ThenBy(a => a.CreatedOn))
            {
                var articlevm = Mapper.Map<Article, ArticleViewModel>(article);
                articlevm.ArticleCategoryIDs = article.ArticleCategories.Select(a => a.ArticleCategoryID).ToList();
                articles.Add(articlevm);
            }
            ViewBag.PartnerArticles = articles;
            ViewBag.Page = page;
            ViewBag.Count = articles.Count;
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
                        if (articleCategory.ArticleCategoryID == Guid.Parse("66666666-6666-6666-6666-666666666666"))
                        {
                            checkCategories = true;
                        }
                    }
                }
                return (a.IsDeleted != true && a.IsPublished && checkCategories
                    && a.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
            }).OrderBy(a => a.OrderID).ThenBy(a => a.UpdatedOn).ThenBy(a => a.CreatedOn))
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
                    if (roomTypes != null)
                    {
                        foreach (var roomType in roomTypes)
                        {
                            if (roomType.RoomTypeID == Guid.Parse("11111111-1111-1111-1111-111111111111"))
                            {
                                checkRoomTypes = true;
                            }
                        }
                    }
                    return (a.IsDeleted != true && a.IsPublished && checkRoomTypes
                        && a.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
                }).OrderBy(a => a.OrderID).ThenBy(a => a.UpdatedOn).ThenBy(a => a.CreatedOn).ToList();
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
                        if (roomType.RoomTypeID == Guid.Parse("22222222-2222-2222-2222-222222222222"))
                        {
                            checkRoomTypes = true;
                        }
                    }
                }
                return (a.IsDeleted != true && a.IsPublished && checkRoomTypes
                    && a.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
            }).OrderBy(a => a.OrderID).ThenBy(a => a.UpdatedOn).ThenBy(a => a.CreatedOn).ToList();
            ViewBag.Language = RouteData.Values["lang"].ToString().ToLower();
            ViewBag.Properties = roomPropertyRoomRepository.GetAll();
            var articles = new List<ArticleViewModel>();
            foreach (var article in articleRepository.GetAll().Where(a =>
            {
                var articleCategories = a.ArticleCategories;
                var checkCategories = false;
                if (articleCategories != null)
                {
                    foreach (var articleCategory in articleCategories)
                    {
                        if (articleCategory.ArticleCategoryID == Guid.Parse("77777777-7777-7777-7777-777777777777"))
                        {
                            checkCategories = true;
                        }
                    }
                }
                return (a.IsDeleted != true && a.IsPublished && checkCategories
                    && a.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
            }).OrderBy(a => a.OrderID).ThenBy(a => a.UpdatedOn).ThenBy(a => a.CreatedOn))
            {
                var articlevm = Mapper.Map<Article, ArticleViewModel>(article);
                articlevm.ArticleCategoryIDs = article.ArticleCategories.Select(a => a.ArticleCategoryID).ToList();
                articles.Add(articlevm);
            }
            ViewBag.RoomArticles = articles;
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
                        if (roomType.RoomTypeID == Guid.Parse("33333333-3333-3333-3333-333333333333"))
                        {
                            checkRoomTypes = true;
                        }
                    }
                }
                return (a.IsDeleted != true && a.IsPublished && checkRoomTypes
                    && a.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
            }).OrderBy(a => a.OrderID).ThenBy(a => a.UpdatedOn).ThenBy(a => a.CreatedOn).ToList();
            ViewBag.Language = RouteData.Values["lang"].ToString().ToLower();
            ViewBag.Properties = roomPropertyRoomRepository.GetAll();
            var articles = new List<ArticleViewModel>();
            foreach (var article in articleRepository.GetAll().Where(a =>
            {
                var articleCategories = a.ArticleCategories;
                var checkCategories = false;
                if (articleCategories != null)
                {
                    foreach (var articleCategory in articleCategories)
                    {
                        if (articleCategory.ArticleCategoryID == Guid.Parse("88888888-8888-8888-8888-888888888888"))
                        {
                            checkCategories = true;
                        }
                    }
                }
                return (a.IsDeleted != true && a.IsPublished && checkCategories && a.RoomID == null
                    && a.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
            }).OrderBy(a => a.OrderID).ThenBy(a => a.UpdatedOn).ThenBy(a => a.CreatedOn))
            {
                var articlevm = Mapper.Map<Article, ArticleViewModel>(article);
                articlevm.ArticleCategoryIDs = article.ArticleCategories.Select(a => a.ArticleCategoryID).ToList();
                articles.Add(articlevm);
            }
            ViewBag.RestaurantArticles = articles;
            return View();
        }
        public ActionResult DealingRestaurant()
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
                        if (articleCategory.ArticleCategoryID == Guid.Parse("99999999-9999-9999-9999-999999999100"))
                        {
                            checkCategories = true;
                        }
                    }
                }
                return (a.IsDeleted != true && a.IsPublished && checkCategories
                    && a.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
            }).OrderBy(a => a.OrderID).ThenBy(a => a.UpdatedOn).ThenBy(a => a.CreatedOn))
            {
                var articlevm = Mapper.Map<Article, ArticleViewModel>(article);
                articlevm.ArticleCategoryIDs = article.ArticleCategories.Select(a => a.ArticleCategoryID).ToList();
                articles.Add(articlevm);
            }
            ViewBag.DealingRestaurantArticles = articles;
            return View();
        }
        public ActionResult DealingRoom()
        {
            ViewBag.RoomAndPrices = roomRepository.GetAll().Where(a =>
            {
                var roomTypes = a.RoomTypes;
                var checkRoomTypes = false;
                if (roomTypes != null)
                {
                    foreach (var roomType in roomTypes)
                    {
                        if (roomType.RoomTypeID == Guid.Parse("22222222-2222-2222-2222-222222222223"))
                        {
                            checkRoomTypes = true;
                        }
                    }
                }
                return (a.IsDeleted != true && a.IsPublished && checkRoomTypes
                    && a.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
            }).OrderBy(a => a.OrderID).ThenBy(a => a.UpdatedOn).ThenBy(a => a.CreatedOn).ToList();
            ViewBag.Language = RouteData.Values["lang"].ToString().ToLower();
            var articles = new List<ArticleViewModel>();
            foreach (var article in articleRepository.GetAll().Where(a =>
            {
                var articleCategories = a.ArticleCategories;
                var checkCategories = false;
                if (articleCategories != null)
                {
                    foreach (var articleCategory in articleCategories)
                    {
                        if (articleCategory.ArticleCategoryID == Guid.Parse("99999999-9999-9999-9999-999999999999"))
                        {
                            checkCategories = true;
                        }
                    }
                }
                return (a.IsDeleted != true && a.IsPublished && checkCategories
                    && a.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
            }).OrderBy(a => a.OrderID).ThenBy(a => a.UpdatedOn).ThenBy(a => a.CreatedOn))
            {
                var articlevm = Mapper.Map<Article, ArticleViewModel>(article);
                articlevm.ArticleCategoryIDs = article.ArticleCategories.Select(a => a.ArticleCategoryID).ToList();
                articles.Add(articlevm);
            }
            ViewBag.RoomArticles = articles;
            return View();
        }
        public ActionResult Booking(Guid? RoomID, string checkin, string checkout)
        {
            if (RoomID != null)
            {
                var room = roomRepository.GetById((Guid)RoomID);
                var books = room.Books;
                var roomvm = Mapper.Map<Room, RoomViewModel>(room);
                ViewBag.Room = roomvm;
                DateTime? begindt = null, enddt = null;
                if (!String.IsNullOrEmpty(checkin))
                {
                    begindt = DateTime.ParseExact(checkin, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                if (!String.IsNullOrEmpty(checkout))
                {
                    enddt = DateTime.ParseExact(checkout, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                if (books != null)
                {
                    int bookTimes = 0;
                    foreach (var book in books)
                    {
                        if ((book.End.AddDays(-1) >= begindt && book.End.AddDays(-1) <= enddt) || (book.Begin >= begindt && book.Begin <= enddt))
                        {
                            bookTimes += book.NoOfRoom != null ? Int32.Parse(book.NoOfRoom) : 1;
                        }
                    }
                    ViewBag.BookAvailable = room.Quantity - bookTimes;
                }
            }
            ViewBag.Checkin = checkin;
            ViewBag.Checkout = checkout;
            var articles = new List<ArticleViewModel>();
            foreach (var article in articleRepository.GetAll().Where(a =>
            {
                var articleCategories = a.ArticleCategories;
                var checkCategories = false;
                if (articleCategories != null)
                {
                    foreach (var articleCategory in articleCategories)
                    {
                        if (articleCategory.ArticleCategoryID == Guid.Parse("77777777-7777-7777-7777-777777777777"))
                        {
                            checkCategories = true;
                        }
                    }
                }
                return (a.IsDeleted != true && a.IsPublished && checkCategories
                    && a.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
            }).OrderBy(a => a.OrderID).ThenBy(a => a.UpdatedOn).ThenBy(a => a.CreatedOn))
            {
                var articlevm = Mapper.Map<Article, ArticleViewModel>(article);
                articlevm.ArticleCategoryIDs = article.ArticleCategories.Select(a => a.ArticleCategoryID).ToList();
                articles.Add(articlevm);
            }
            ViewBag.RoomArticles = articles;
            return View();
        }
        [HttpPost]
        public JsonResult QuickBook(BookViewModel form, Guid RoomID)
        {
            form.BookID = Guid.NewGuid();
            var room = roomRepository.GetById(RoomID);
            var books = room.Books;
            var checkDate = true;
            form.NoOfRoom = form.NoOfRoom == null ? "1" : form.NoOfRoom; 
            if (books != null)
            {
                int bookTimes = 0;
                foreach (var book in books)
                {
                    if ((book.End.AddDays(-1) >= form.Begin && book.End.AddDays(-1) <= form.End) || (book.Begin >= form.Begin && book.Begin <= form.End))
                    {
                        bookTimes += book.NoOfRoom != null ? Int32.Parse(book.NoOfRoom) : 1; 
                    }
                }
                if (bookTimes + Int32.Parse(form.NoOfRoom) > room.Quantity)
                {
                    checkDate = false;
                }
            }
            if (checkDate == false)
            {
                return Json("Phòng đã được đặt, vui lòng chọn phòng hoặc thời gian khác!", JsonRequestBehavior.AllowGet);
            }
            room.Books.Add(new Book
            {
                BookID = Guid.NewGuid(),
                Name = form.Name,
                Email = form.Email,
                Begin = form.Begin,
                End = form.End,
                Time = form.Time,
                GuestQuantity = form.GuestQuantity,
                MeetingType = form.MeetingType,
                Price = form.Price,
                Message = form.Message,
                UserCardName = form.UserCardName,
                UserCardNumber = form.UserCardNumber,
                UserCardType = form.UserCardType,
                DueDate = form.DueDate,
                RoomID = RoomID,
                Airline = form.Airline,
                Children = form.Children,
                DateOfBirth = form.DateOfBirth,
                EstimatedArrivalTime = form.EstimatedArrivalTime,
                Fax = form.Fax,
                FirstName = form.FirstName,
                FlightNo = form.FlightNo,
                KindOfBed = form.KindOfBed,
                LastName = form.LastName,
                NonSmoking = form.NonSmoking,
                NoOfGuest = form.NoOfGuest,
                NoOfRoom = form.NoOfRoom,
                SpecialRequest = form.SpecialRequest,
                Tel = form.Tel
            });
            roomRepository.Update(room);
            unitOfWork.Commit();
            var fromAddress = ConfigurationManager.AppSettings.Get("SendMailMessagesFromAddress");
            var hostAddress = ConfigurationManager.AppSettings.Get("SendMailSTMPHostAddress");
            var toAddress = ConfigurationManager.AppSettings.Get("SendMailSTMPToAddress");
            var username = ConfigurationManager.AppSettings.Get("SendMailSMTPUserName");
            var password = ConfigurationManager.AppSettings.Get("SendMailSMTPUserPassword");
            var content = room.RoomTypes.FirstOrDefault().RoomTypeID == Guid.Parse("11111111-1111-1111-1111-111111111111") ?
                "THÔNG TIN KHÁCH HÀNG ĐẶT PHÒNG<br /><br />" +
                          "Họ và tên: " + form.Name + "<br /><br />" +
                          "Email: " + form.Email + "<br /><br />" +
                          "Điện thoại: " + form.Tel + "<br /><br />" +
                          "Phòng: " + room.RoomName + "<br /><br />" +
                          "Ngày bắt đầu: " + form.Begin + "<br /><br />" +
                          "Ngày kết thúc: " + form.End + "<br /><br />" +
                          "Thời gian: " + form.Time + "<br /><br />" +
                          "Số lượng khách: " + form.GuestQuantity + "<br /><br />" +
                          "Loại cuộc họp: " + form.MeetingType + "<br /><br />" +
                          "Giá: " + form.Price + "<br /><br />" +
                          "Tin nhắn: " + form.Message + "<br /><br />" 
                          :
                          "THÔNG TIN KHÁCH HÀNG ĐẶT PHÒNG<br /><br />" +
                          "Họ và tên: " + form.FirstName + " " + form.LastName + "<br /><br />" +
                          "Email: " + form.Email + "<br /><br />" +
                          "Phòng: " + room.RoomName + "<br /><br />" +
                          "Ngày bắt đầu: " + String.Format("{0:dd/MM/yyyy}", form.Begin) + "<br /><br />" +
                          "Ngày kết thúc: " + String.Format("{0:dd/MM/yyyy}", form.End) + "<br /><br />" +
                          "Số lượng phòng: " + form.NoOfRoom + "<br /><br />" +
                          "Số lượng khách: " + form.NoOfGuest + "<br /><br />" +
                          "Trẻ em: " + form.Children + "<br /><br />" +
                          "Loại giường: " + form.KindOfBed + "<br /><br />" +
                          "Hãng hàng không: " + form.Airline + "<br /><br />" +
                          "Mã chuyến bay: " + form.FlightNo + "<br /><br />" +
                          (form.EstimatedArrivalTime != "0" ? "Đón vào lúc: " + form.EstimatedArrivalTime + "<br /><br />" : string.Empty) +
                          "Không hút thuốc: " + form.NonSmoking + "<br /><br />" +
                          "Yêu cầu đặc biệt: " + form.SpecialRequest + "<br /><br />" +
                          "Ngày sinh: " + form.DateOfBirth + "<br /><br />" +
                          "Điện thoại: " + form.Tel + "<br /><br />" +
                          "Fax: " + form.Fax + "<br /><br />";
            //"THÔNG TIN THẺ<br /><br />" +
            //"Tên chủ thẻ: " + form.UserCardName + "<br /><br />" +
            //"Số thẻ: " + form.UserCardNumber + "<br /><br />" +
            //"Loại thẻ: " + form.UserCardType + "<br /><br />" +
            //"Ngày hết hạn: " + form.DueDate + "<br /><br />";
            var email = new Email(fromAddress, hostAddress, toAddress, username, password, "Thông tin đặt phòng VietSov Petro Resort", content);
            var success = email.send();
            var contenttocustomer = room.RoomTypes.FirstOrDefault().RoomTypeID == Guid.Parse("11111111-1111-1111-1111-111111111111") ?
                "<b>BẠN ĐÃ ĐẶT PHÒNG TẠI <a href='http://vipd.vn'>VIETSOV PETRO</a> VỚI THÔNG TIN</b><br /><br />" +
                          "Họ và tên: " + form.Name + "<br /><br />" +
                          "Email: " + form.Email + "<br /><br />" +
                          "Điện thoại: " + form.Tel + "<br /><br />" +
                          "Phòng: " + room.RoomName + "<br /><br />" +
                          "Thông tin phòng: " + room.Description + "<br /><br />" +
                          "Ngày bắt đầu: " + String.Format("{0:dd/MM/yyyy}", form.Begin) + "<br /><br />" +
                          "Ngày kết thúc: " + String.Format("{0:dd/MM/yyyy}", form.End) + "<br /><br />" +
                          "Thời gian: " + form.Time + "<br /><br />" +
                          "Số lượng khách: " + form.GuestQuantity + "<br /><br />" +
                          "Loại cuộc họp: " + form.MeetingType + "<br /><br />" +
                          "Giá: " + form.Price + "<br /><br />" +
                          "Tin nhắn: " + form.Message + "<br /><br />"
                          :
                          "<b>BẠN ĐÃ ĐẶT PHÒNG TẠI <a href='http://vipd.vn'>VIETSOV PETRO</a> VỚI THÔNG TIN</b><br /><br />" +
                          "Họ và tên: " + form.FirstName + " " + form.LastName + "<br /><br />" +
                          "Email: " + form.Email + "<br /><br />" +
                          "Phòng: " + room.RoomName + "<br /><br />" +
                          "Thông tin phòng: " + room.Description + "<br /><br />" +
                          "Ngày bắt đầu: " + String.Format("{0:dd/MM/yyyy}", form.Begin) +"<br /><br />" +
                          "Ngày kết thúc: " + String.Format("{0:dd/MM/yyyy}", form.End) + "<br /><br />" +
                          "Số lượng phòng: " + form.NoOfRoom + "<br /><br />" +
                          "Số lượng khách: " + form.NoOfGuest + "<br /><br />" +
                          "Trẻ em: " + form.Children + "<br /><br />" +
                          "Loại giường: " + form.KindOfBed + "<br /><br />" +
                          "Hãng hàng không: " + form.Airline + "<br /><br />" +
                          "Mã chuyến bay: " + form.FlightNo + "<br /><br />" +
                          (form.EstimatedArrivalTime != "0" ? "Đón vào lúc: " + form.EstimatedArrivalTime + "<br /><br />" : string.Empty) +
                          "Không hút thuốc: " + form.NonSmoking + "<br /><br />" +
                          "Yêu cầu đặc biệt: " + form.SpecialRequest + "<br /><br />" +
                          "Ngày sinh: " + form.DateOfBirth + "<br /><br />" +
                          "Điện thoại: " + form.Tel + "<br /><br />" +
                          "Fax: " + form.Fax + "<br /><br />";
            var emailtocustomer = new Email(fromAddress, hostAddress, form.Email, username, password, "Thông tin đặt phòng VietSov Petro Resort", contenttocustomer);
            success = emailtocustomer.send();
            return Json(!success ? "Quá trình gửi thông tin qua email thất bại, thông tin được lưu vào cơ sở dữ liệu tạm!" : "Thông tin đặt phòng của bạn đã được gửi, cảm ơn!");
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(FormCollection f)
        {
            var fromAddress = ConfigurationManager.AppSettings.Get("SendMailMessagesFromAddress");
            var hostAddress = ConfigurationManager.AppSettings.Get("SendMailSTMPHostAddress");
            var toAddress = ConfigurationManager.AppSettings.Get("SendMailSTMPToAddress");
            var username = ConfigurationManager.AppSettings.Get("SendMailSMTPUserName");
            var password = ConfigurationManager.AppSettings.Get("SendMailSMTPUserPassword");
            var content = "THÔNG TIN<br /><br />" +
                          "Họ và tên: " + f["first_name"] + "<br /><br />" +
                          "Email: " + f["email"] + "<br /><br />" +
                          "Địa chỉ: " + f["address"] + "<br /><br />" +
                          "Điện thoại: " + f["tel"] + "<br /><br />" +
                          "Chủ đề: " + f["title"] + "<br /><br />" +
                          "Nội dung: " + f["message"] + "<br /><br />";
            var email = new Email(fromAddress, hostAddress, toAddress, username, password, "Thông tin liên hệ VietSov Petro Resort", content);
            var success = email.send();
            return Json(!success ? "Gửi liên hệ thất bại, vui lòng thử lại sau!" : "Thông tin liên hệ của bạn đã được gửi, cảm ơn!");
        }
        public ActionResult _RoomFilter(string begin, string end, Guid? roomTypeID, bool IsDeal = false)
        {
            DateTime? begindt = null, enddt = null;
            if (!String.IsNullOrEmpty(begin))
            {
                begindt = DateTime.ParseExact(begin, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            if (!String.IsNullOrEmpty(end))
            {
                enddt = DateTime.ParseExact(end, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            ViewBag.Rooms = roomRepository.GetAll().Where(a =>
            {
                var roomTypes = a.RoomTypes;
                var checkRoomTypes = false;
                var books = a.Books;
                var checkDate = true;
                var checkDeal = true;
                if (roomTypeID == null)
                {
                    checkRoomTypes = true;
                }
                else
                {
                    if (roomTypes != null && roomTypes.Count > 0)
                    {
                        foreach (var roomType in roomTypes)
                        {
                            if (roomType.RoomTypeID == roomTypeID)
                            {
                                checkRoomTypes = true;
                            }
                        }
                    }
                }
                if (books != null)
                {
                    int bookTimes = 0;
                    foreach (var book in books)
                    {
                        if ((book.End.AddDays(-1) >= begindt && book.End.AddDays(-1) <= enddt) || (book.Begin >= begindt && book.Begin <= enddt))
                        {
                            bookTimes += book.NoOfRoom != null ? Int32.Parse(book.NoOfRoom) : 1;
                        }
                    }
                    if (bookTimes >= a.Quantity)
                    {
                        checkDate = false;
                    }
                }
                if (IsDeal)
                {
                    checkDeal = a.IsDeal;
                }
                return (a.IsDeleted != true && a.IsPublished && checkRoomTypes && checkDate && checkDeal
                    && a.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
            }).OrderBy(a => a.OrderID).ToList();
            ViewBag.Properties = roomPropertyRoomRepository.GetAll();
            return PartialView();
        }
    }
}

