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
        [HttpPost]
        public JsonResult GetRoomTypes()
        {
            var roomtypes = roomTypeRepository.GetAll().Where(a => a.IsDeleted != true).Select(Mapper.Map<RoomType, RoomTypeViewModel>).ToList();
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
            foreach (var room in roomRepository.GetAll().Where(a => a.IsDeleted != true))
            {
                var roomvm = Mapper.Map<Room, RoomViewModel>(room);
                roomvm.RoomTypeIDs = room.RoomTypes.Select(a => a.RoomTypeID).ToList();
                rooms.Add(roomvm);
            }
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
        [HttpPost]
        public JsonResult GetBooks(Guid RoomTypeID)
        {
            var books = new List<BookViewModel>();
            foreach (var book in bookRepository.GetAll().Where(b => b.Room.RoomTypes.FirstOrDefault().RoomTypeID == RoomTypeID))
            {
                var bookvm = Mapper.Map<Book, BookViewModel>(book);
                bookvm.Room = Mapper.Map<Room, RoomViewModel>(book.Room);
                books.Add(bookvm);
            }
            return Json(books, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult CreateOrUpdateBooks(string models)
        {
            var books = JsonConvert.DeserializeObject<List<Book>>(models);
            if (ModelState.IsValid)
            {
                foreach (var book in books)
                {
                    if (bookRepository.GetById(book.BookID) == null)
                    {
                        bookRepository.Add(book);
                    }
                    else
                    {
                        bookRepository.Update(book);
                    }
                }
                unitOfWork.Commit();
                return Json(books, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteBooks(string models)
        {
            var books = JsonConvert.DeserializeObject<List<Book>>(models);
            if (ModelState.IsValid)
            {
                foreach (var book in books)
                {
                    bookRepository.Delete(book);
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
