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
    using System.Globalization;

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
        public JsonResult QuickBook(BookViewModel form, Guid RoomID)
        {
            form.BookID = Guid.NewGuid();
            var room = roomRepository.GetById(RoomID);
            var books = room.Books;
            var checkDate = true;
            if (books != null)
            {
                foreach (var book in books)
                {
                    if ((book.End > form.Begin && book.End < form.End) || (book.Begin > form.Begin && book.Begin < form.End))
                    {
                        checkDate = false;
                    }
                }
            }
            if(checkDate == false)
            {
                return Json("Phòng đã được đặt, vui lòng chọn phòng hoặc thời gian khác!", JsonRequestBehavior.AllowGet);
            }
            room.Books.Add(new Book { BookID = Guid.NewGuid(), Name = form.Name, Email = form.Email, Begin = form.Begin, 
                End = form.End, Time = form.Time, GuestQuantity = form.GuestQuantity, MeetingType = form.MeetingType,
                Price = form.Price, Message = form.Message, UserCardName = form.UserCardName, UserCardNumber = form.UserCardNumber,
                                      UserCardType = form.UserCardType,
                                      DueDate = form.DueDate,
                                      RoomID = RoomID
            });
            roomRepository.Update(room);
            unitOfWork.Commit();
            var fromAddress = ConfigurationManager.AppSettings.Get("SendMailMessagesFromAddress");
            var toAddress = ConfigurationManager.AppSettings.Get("SendMailSTMPHostAddress");
            var username = ConfigurationManager.AppSettings.Get("SendMailSMTPUserName");
            var password = ConfigurationManager.AppSettings.Get("SendMailSMTPUserPassword");
            var content = "THÔNG TIN KHÁCH HÀNG<br /><br />" +
                          "Họ và tên: " + form.Name + "<br /><br />" +
                          "Email: " + form.Email + "<br /><br />" +
                          "Phòng: " + room.RoomName + "<br /><br />" +
                          "Ngày bắt đầu: " + form.Begin + "<br /><br />" +
                          "Ngày kết thúc: " + form.End + "<br /><br />" +
                          "Thời gian: " + form.Time + "<br /><br />" +
                          "Số lượng khách: " + form.GuestQuantity + "<br /><br />" +
                          "Loại cuộc họp: " + form.MeetingType + "<br /><br />" +
                          "Giá: " + form.Price + "<br /><br />" +
                          "Tinh nhắn: " + form.Message + "<br /><br />" +
                          "THÔNG TIN THẺ<br /><br />" +
                          "Tên chủ thẻ: " + form.UserCardName + "<br /><br />" +
                          "Số thẻ: " + form.UserCardNumber + "<br /><br />" +
                          "Loại thẻ: " + form.UserCardType + "<br /><br />" +
                          "Ngày hết hạn: " + form.DueDate + "<br /><br />";
            var email = new Email(fromAddress, toAddress, username, password, "Thông tin đặt phòng VietSov Petro Resort", content);
            var success = email.send();
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
            var toAddress = ConfigurationManager.AppSettings.Get("SendMailSTMPHostAddress");
            var username = ConfigurationManager.AppSettings.Get("SendMailSMTPUserName");
            var password = ConfigurationManager.AppSettings.Get("SendMailSMTPUserPassword");
            var content = "THÔNG TIN<br /><br />" +
                          "Họ và tên: " + f["first_name"] + "<br /><br />" +
                          "Email: " + f["email"] + "<br /><br />" +
                          "Địa chỉ: " + f["address"] + "<br /><br />" +
                          "Điện thoại: " + f["tel"] + "<br /><br />" +
                          "Chủ đề: " + f["title"] + "<br /><br />" +
                          "Nội dung: " + f["message"] + "<br /><br />";
            var email = new Email(fromAddress, toAddress, username, password, "Thông tin liên hệ VietSov Petro Resort", content);
            var success = email.send();
            return Json(!success ? "Gửi liên hệ thất bại, vui lòng thử lại sau!" : "Thông tin liên hệ của bạn đã được gửi, cảm ơn!");
        }
        public ActionResult _RoomFilter(string begin, string end, string roomGroup, bool IsDeal = false)
        {
            var begindt = DateTime.ParseExact(begin, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var enddt = DateTime.ParseExact(end, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            ViewBag.Rooms = roomRepository.GetAll().Where(a =>
            {
                var roomTypes = a.RoomTypes;
                var checkRoomTypes = false;
                var books = a.Books;
                var checkDate = true;
                if(roomGroup == null)
                {
                    checkRoomTypes = true;
                }
                else
                {
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
                }
                if(books != null)
                {
                    foreach (var book in books)
                    {
                        if((book.End > begindt && book.End < enddt)||(book.Begin > begindt && book.Begin < enddt))
                        {
                            checkDate = false;
                        }
                    }
                }
                return (a.IsDeleted != true && a.IsPublished && checkRoomTypes && checkDate && a.IsDeal == IsDeal
                    && a.LanguageCode.ToLower() == RouteData.Values["lang"].ToString().ToLower());
            }).OrderBy(a => a.OrderID).ToList();
            ViewBag.Properties = roomPropertyRoomRepository.GetAll();
            return PartialView();
        }
    }
}

