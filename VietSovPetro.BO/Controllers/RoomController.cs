using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Newtonsoft.Json;
using VietSovPetro.BO.ViewModels;
using VietSovPetro.CommandProcessor.Dispatcher;
using VietSovPetro.Data.Infrastructure;
using VietSovPetro.Data.Repositories.IRepositories;
using VietSovPetro.Domain.Commands;
using VietSovPetro.Model.Entities;

namespace VietSovPetro.BO.Controllers
{
    using System.Globalization;

    [Authorize]
    public class RoomController : Controller
    {
        //
        // GET: /Room/
        private readonly IRoomRepository roomRepository;
        private readonly IRoomTypeRepository roomTypeRepository;
        private readonly IRoomPropertyRepository roomPropertyRepository;
        private readonly IRoomPropertyRoomRepository roomPropertyRoomRepository;
        private readonly IBookRepository bookRepository;
        private readonly ICommandBus commandBus;
        private readonly IUnitOfWork unitOfWork;
        public RoomController(ICommandBus commandBus, IRoomRepository roomRepository, IRoomTypeRepository roomTypeRepository, 
            IRoomPropertyRepository roomPropertyRepository, IRoomPropertyRoomRepository roomPropertyRoomRepository,
            IUnitOfWork unitOfWork, IBookRepository bookRepository)
        {
            this.commandBus = commandBus;
            this.roomRepository = roomRepository;
            this.roomTypeRepository = roomTypeRepository;
            this.roomPropertyRepository = roomPropertyRepository;
            this.roomPropertyRoomRepository = roomPropertyRoomRepository;
            this.unitOfWork = unitOfWork;
            this.bookRepository = bookRepository;
        }
        public ActionResult Index()
        {
            if (Session["VietSovPetroAdmin"] != null)
            {
                return View("~/Views/Admin/Room/Index.cshtml");
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult RestaurantIndex()
        {
            if (Session["VietSovPetroAdmin"] != null)
            {
                return View("~/Views/Admin/Room/RestaurantIndex.cshtml");
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public JsonResult GetRoomTypes()
        {
            var roomtypes = roomTypeRepository.GetAll().Where(a => a.IsDeleted != true && a.RoomTypeID != Guid.Parse("33333333-3333-3333-3333-333333333333") && a.RoomTypeID != Guid.Parse("33333333-3333-3333-3333-333333333334") && a.RoomTypeID != Guid.Parse("33333333-3333-3333-3333-333333333335")).Select(Mapper.Map<RoomType, RoomTypeViewModel>).ToList();
            return Json(roomtypes.OrderBy(r => r.RoomGroup), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetRoomTypesRestaurant()
        {
            var roomtypes = roomTypeRepository.GetAll().Where(a => a.IsDeleted != true && a.RoomTypeID == Guid.Parse("33333333-3333-3333-3333-333333333333") || a.RoomTypeID == Guid.Parse("33333333-3333-3333-3333-333333333335")).Select(Mapper.Map<RoomType, RoomTypeViewModel>).ToList();
            return Json(roomtypes.OrderBy(r => r.RoomGroup), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetRoomGroups()
        {
            var roomtypes = from r in roomTypeRepository.GetAll() where r.IsDeleted != true select new { RoomGroup = r.RoomGroup.Distinct() }; //roomTypeRepository.GetAll().Where(a => a.IsDeleted != true).Select(Mapper.Map<RoomType, RoomTypeViewModel>).ToList();
            return Json(roomtypes.OrderBy(r => r.RoomGroup), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult CreateOrUpdateRoomTypes(string models)
        {
            var roomTypes = JsonConvert.DeserializeObject<List<RoomTypeViewModel>>(models);
            if (ModelState.IsValid)
            {
                foreach (var roomType in roomTypes)
                {
                    var command = Mapper.Map<RoomTypeViewModel, CreateOrUpdateRoomTypeCommand>(roomType);
                    commandBus.Validate(command);
                    if (ModelState.IsValid)
                    {
                        var result = commandBus.Submit(command);
                        roomType.RoomTypeID = result.ID;
                    }
                }
                return Json(roomTypes, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteRoomTypes(string models)
        {
            var roomTypes = JsonConvert.DeserializeObject<List<RoomTypeViewModel>>(models);
            if (ModelState.IsValid)
            {
                foreach (var command in roomTypes.Select(Mapper.Map<RoomTypeViewModel, DeleteRoomTypeCommand>))
                {
                    commandBus.Submit(command);
                }
                return Json(roomTypes, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetRooms()
        {
            var rooms = new List<RoomViewModel>();
            foreach (var room in roomRepository.GetAll().Where(a =>
            {
                var roomTypes = a.RoomTypes;
                var checkRoomTypes = false;
                if (roomTypes != null)
                {
                    foreach (var roomType in roomTypes)
                    {
                        if (roomType.RoomTypeID != Guid.Parse("33333333-3333-3333-3333-333333333333") && roomType.RoomTypeID != Guid.Parse("33333333-3333-3333-3333-333333333334") && roomType.RoomTypeID != Guid.Parse("33333333-3333-3333-3333-333333333335"))
                        {
                            checkRoomTypes = true;
                        }
                    }
                }
                return (a.IsDeleted != true && a.IsPublished && checkRoomTypes);
            }))
            {
                var roomvm = Mapper.Map<Room, RoomViewModel>(room);
                roomvm.RoomTypeIDs = room.RoomTypes.Select(a => a.RoomTypeID).ToList();
                rooms.Add(roomvm);
            }
            return Json(rooms.OrderBy(r => r.OrderID), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetRoomsRestaurant()
        {
            var rooms = new List<RoomViewModel>();
            foreach (var room in roomRepository.GetAll().Where(a =>
            {
                var roomTypes = a.RoomTypes;
                var checkRoomTypes = false;
                if (roomTypes != null)
                {
                    foreach (var roomType in roomTypes)
                    {
                        if (roomType.RoomTypeID == Guid.Parse("33333333-3333-3333-3333-333333333333") || roomType.RoomTypeID == Guid.Parse("33333333-3333-3333-3333-333333333335"))
                        {
                            checkRoomTypes = true;
                        }
                    }
                }
                return (a.IsDeleted != true && a.IsPublished && checkRoomTypes);
            }))
            {
                var roomvm = Mapper.Map<Room, RoomViewModel>(room);
                roomvm.RoomTypeIDs = room.RoomTypes.Select(a => a.RoomTypeID).ToList();
                rooms.Add(roomvm);
            }
            return Json(rooms.OrderBy(r => r.OrderID), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetRoomsRestaurantForDropDown()
        {
            var rooms = new List<RoomViewModel>();
            foreach (var room in roomRepository.GetAll().Where(a =>
            {
                var roomTypes = a.RoomTypes;
                var checkRoomTypes = false;
                if (roomTypes != null)
                {
                    foreach (var roomType in roomTypes)
                    {
                        if (roomType.RoomTypeID == Guid.Parse("33333333-3333-3333-3333-333333333333") || roomType.RoomTypeID == Guid.Parse("33333333-3333-3333-3333-333333333335"))
                        {
                            checkRoomTypes = true;
                        }
                    }
                }
                return (a.IsDeleted != true && a.IsPublished && checkRoomTypes);
            }))
            {
                var roomvm = Mapper.Map<Room, RoomViewModel>(room);
                roomvm.RoomTypeIDs = room.RoomTypes.Select(a => a.RoomTypeID).ToList();
                rooms.Add(roomvm);
            }
            rooms.Add(new RoomViewModel{RoomID = Guid.Empty, RoomName = "null"});
            return Json(rooms.OrderBy(r => r.OrderID), JsonRequestBehavior.AllowGet);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CreateOrUpdateRooms(string models)
        {
            var rooms = JsonConvert.DeserializeObject<List<RoomViewModel>>(models);
            if (ModelState.IsValid)
            {
                foreach (var room in rooms)
                {
                    var command = Mapper.Map<RoomViewModel, CreateOrUpdateRoomCommand>(room);
                    commandBus.Validate(command);
                    if (ModelState.IsValid)
                    {
                        var result = commandBus.Submit(command);
                        room.RoomID = result.ID;
                    }
                }
                return Json(rooms, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DeleteRooms(string models)
        {
            var rooms = JsonConvert.DeserializeObject<List<DeleteRoom>>(models);
            if (ModelState.IsValid)
            {
                foreach (var command in rooms.Select(Mapper.Map<DeleteRoom, DeleteRoomCommand>))
                {
                    commandBus.Submit(command);
                }
                return Json(rooms, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetRoomProperties(Guid? rID)
        {
            var roomPropertys = roomPropertyRepository.GetAll().ToList();
            var roomPropertyRooms = new List<RoomPropertyViewModel>();
            foreach (var roomProperty in roomPropertys)
            {
                var roomPropertyViewModel = new RoomPropertyViewModel
                {
                    RoomPropertyID = roomProperty.RoomPropertyID,
                    RoomID = rID != null ? (Guid)rID : Guid.Empty,
                    RoomPropertyName = roomProperty.RoomPropertyName,
                    RoomPropertyType = roomProperty.RoomPropertyType,
                    OrderID = roomProperty.OrderID,
                    Unit = roomProperty.Unit
                };
                var roomPropertyRoom = roomPropertyRoomRepository.GetAll().FirstOrDefault(a => a.RoomID == roomPropertyViewModel.RoomID && a.RoomPropertyID == roomProperty.RoomPropertyID);
                if (roomPropertyRoom != null)
                {
                    roomPropertyViewModel.RoomPropertyStringValue = roomPropertyRoom.RoomPropertyStringValue;
                    roomPropertyViewModel.RoomPropertyNumberValue = roomPropertyRoom.RoomPropertyNumberValue;
                    roomPropertyViewModel.IsNew = roomPropertyRoom.IsNew;
                    roomPropertyViewModel.IsPublished = roomPropertyRoom.IsPublished;
                }
                roomPropertyRooms.Add(roomPropertyViewModel);
            }
            return Json(roomPropertyRooms.OrderBy(r => r.OrderID), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult CreateOrUpdateRoomProperties(string models)
        {
            var roomProperties = JsonConvert.DeserializeObject<List<RoomPropertyViewModel>>(models);
            if (ModelState.IsValid)
            {
                foreach (var roomProperty in roomProperties)
                {
                    var command = Mapper.Map<RoomPropertyViewModel, CreateOrUpdateRoomPropertyCommand>(roomProperty);
                    commandBus.Validate(command);
                    if (ModelState.IsValid)
                    {
                        var result = commandBus.Submit(command);
                        var roomPropertyRoom = new RoomPropertyRooms
                        {
                            RoomID = command.RoomID,
                            RoomPropertyID = result.ID,
                            RoomPropertyStringValue = command.RoomPropertyStringValue,
                            RoomPropertyNumberValue = command.RoomPropertyNumberValue,
                            IsNew = command.IsNew,
                            IsPublished = command.IsPublished
                        };
                        if (roomPropertyRoomRepository.GetAll().Any(r => r.RoomID == command.RoomID && r.RoomPropertyID == result.ID))
                        {
                            roomPropertyRoomRepository.Update(roomPropertyRoom);
                        }
                        else
                        {
                            roomPropertyRoomRepository.Add(roomPropertyRoom);
                        }
                        unitOfWork.Commit();
                        roomProperty.RoomPropertyID = result.ID;
                    }
                }
                return Json(roomProperties, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteRoomProperties(string models)
        {
            var roomProperties = JsonConvert.DeserializeObject<List<RoomPropertyViewModel>>(models);
            if (ModelState.IsValid)
            {
                foreach (var command in roomProperties.Select(Mapper.Map<RoomPropertyViewModel, DeleteRoomPropertyCommand>))
                {
                    commandBus.Submit(command);
                }
                return Json(roomProperties, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult BookMeeting()
        {
            if (Session["VietSovPetroAdmin"] != null)
            {
                return View("~/Views/Admin/Room/BookMeeting.cshtml");
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult BookRoom()
        {
            if (Session["VietSovPetroAdmin"] != null)
            {
                return View("~/Views/Admin/Room/BookRoom.cshtml");
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult BookLimited()
        {
            if (Session["VietSovPetroAdmin"] != null)
            {
                return View("~/Views/Admin/Room/BookLimited.cshtml");
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public JsonResult GetBooks(Guid RoomTypeID)
        {
            var books = new List<BookViewModel>();
            foreach (var book in bookRepository.GetAll().Where(b => b.Room.RoomTypes.FirstOrDefault().RoomTypeID == RoomTypeID && b.Time != "Limited"))
            {
                var bookvm = Mapper.Map<Book, BookViewModel>(book);
                bookvm.Room = Mapper.Map<Room, RoomViewModel>(book.Room);
                books.Add(bookvm);
            }
            return Json(books, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetBooksLimited()
        {
            var books = new List<BookViewModel>();
            foreach (var book in bookRepository.GetAll().Where(b => b.Time == "Limited"))
            {
                var bookvm = Mapper.Map<Book, BookViewModel>(book);
                bookvm.Room = Mapper.Map<Room, RoomViewModel>(book.Room);
                bookvm.NoOfRoom = (bookvm.Room.Quantity - Int32.Parse(bookvm.NoOfRoom)).ToString(CultureInfo.InvariantCulture);
                books.Add(bookvm);
            }
            return Json(books, JsonRequestBehavior.AllowGet);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CreateOrUpdateBooks(string models)
        {
            var books = JsonConvert.DeserializeObject<List<Book>>(models);
            if (ModelState.IsValid)
            {
                foreach (var book in books)
                {
                    var room = roomRepository.GetById(book.Room.RoomID);
                    var existBook = bookRepository.GetById(book.BookID);
                    if (existBook == null)
                    {
                        room.Books.Add(new Book
                            {
                                BookID = book.BookID,
                                Begin = book.Begin,
                                End = book.Begin.AddDays(1),
                                NoOfRoom = (book.Room.Quantity - Int32.Parse(book.NoOfRoom)).ToString(CultureInfo.InvariantCulture),
                                Time = "Limited"
                            });
                        roomRepository.Update(room);
                    }
                    else
                    {
                        bookRepository.Delete(existBook);
                        unitOfWork.Commit();
                        room.Books.Add(new Book
                        {
                            BookID = book.BookID,
                            Begin = book.Begin,
                            End = book.Begin.AddDays(1),
                            NoOfRoom = (book.Room.Quantity - Int32.Parse(book.NoOfRoom)).ToString(CultureInfo.InvariantCulture),
                            Time = "Limited"
                        });
                        roomRepository.Update(room);
                    }
                }
                unitOfWork.Commit();
                return Json(books, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DeleteBooks(string models)
        {
            var books = JsonConvert.DeserializeObject<List<Book>>(models);
            if (ModelState.IsValid)
            {
                foreach (var book in books)
                {
                    var existBook = bookRepository.GetById(book.BookID);
                    bookRepository.Delete(existBook);
                }
                unitOfWork.Commit();
                return Json(books, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
    }
    public class DeleteRoom
    {
        public Guid RoomID;
        public bool IsDeleted;
    }
}
