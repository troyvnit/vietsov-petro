using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Newtonsoft.Json;
using VietSovPetro.BO.ViewModels;
using VietSovPetro.CommandProcessor.Commands;
using VietSovPetro.CommandProcessor.Dispatcher;
using VietSovPetro.Data.Repositories.IRepositories;
using VietSovPetro.Domain.Commands;
using VietSovPetro.Model.Entities;

namespace VietSovPetro.BO.Controllers
{
    public class RoomController : Controller
    {
        //
        // GET: /Room/
        private readonly IRoomRepository roomRepository;
        private readonly IRoomTypeRepository roomTypeRepository;
        private readonly IRoomPropertyRepository roomPropertyRepository;
        private readonly ICommandBus commandBus;
        public RoomController(ICommandBus commandBus, IRoomRepository roomRepository, IRoomTypeRepository roomTypeRepository, IRoomPropertyRepository roomPropertyRepository)
        {
            this.commandBus = commandBus;
            this.roomRepository = roomRepository;
            this.roomTypeRepository = roomTypeRepository;
            this.roomPropertyRepository = roomPropertyRepository;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetRoomTypes()
        {
            var roomtypes = new List<RoomTypeViewModel>();
            foreach (RoomType roomtype in roomTypeRepository.GetAll().Where(a => a.IsDeleted != true))
            {
                roomtypes.Add(Mapper.Map<RoomType, RoomTypeViewModel>(roomtype));
            }
            return Json(roomtypes, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult CreateOrUpdateRoomTypes(string models)
        {
            RoomTypeViewModel roomType = JsonConvert.DeserializeObject<List<RoomTypeViewModel>>(models).FirstOrDefault();
            if (ModelState.IsValid)
            {
                var command = Mapper.Map<RoomTypeViewModel, CreateOrUpdateRoomTypeCommand>(roomType);
                IEnumerable<ValidationResult> errors = commandBus.Validate(command);
                if (ModelState.IsValid)
                {
                    var result = commandBus.Submit(command);
                    return Json(command, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetRooms()
        {
            var rooms = new List<RoomViewModel>();
            foreach (Room room in roomRepository.GetAll().Where(a => a.IsDeleted != true))
            {
                var roomvm = Mapper.Map<Room, RoomViewModel>(room);
                roomvm.RoomTypeIDs = room.RoomTypes.Select(a => a.RoomTypeID).ToList();
                rooms.Add(roomvm);
            }
            return Json(rooms, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult CreateOrUpdateRooms(string models)
        {
            RoomViewModel articleCategory = JsonConvert.DeserializeObject<List<RoomViewModel>>(models).FirstOrDefault();
            if (ModelState.IsValid)
            {
                var command = Mapper.Map<RoomViewModel, CreateOrUpdateRoomCommand>(articleCategory);
                IEnumerable<ValidationResult> errors = commandBus.Validate(command);
                if (ModelState.IsValid)
                {
                    var result = commandBus.Submit(command);
                    return Json(command, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetRoomPropertys(Guid? rID)
        {
            var roomPropertys = new List<RoomPropertyViewModel>();
            foreach (RoomProperty roomProperty in roomPropertyRepository.GetAll().Where(a => a.IsDeleted != true && a.RoomID == rID))
            {
                roomPropertys.Add(Mapper.Map<RoomProperty, RoomPropertyViewModel>(roomProperty));
            }
            return Json(roomPropertys, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult CreateOrUpdateRoomPropertys(string models)
        {
            RoomPropertyViewModel roomProperty = JsonConvert.DeserializeObject<List<RoomPropertyViewModel>>(models).FirstOrDefault();
            if (ModelState.IsValid)
            {
                var command = Mapper.Map<RoomPropertyViewModel, CreateOrUpdateRoomPropertyCommand>(roomProperty);
                IEnumerable<ValidationResult> errors = commandBus.Validate(command);
                if (ModelState.IsValid)
                {
                    var result = commandBus.Submit(command);
                    return Json(command, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
    }
}
