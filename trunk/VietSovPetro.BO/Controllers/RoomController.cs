﻿using System;
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
        private readonly ICommandBus commandBus;
        private readonly IUnitOfWork unitOfWork;
        public RoomController(ICommandBus commandBus, IRoomRepository roomRepository, IRoomTypeRepository roomTypeRepository, IRoomPropertyRepository roomPropertyRepository, IRoomPropertyRoomRepository roomPropertyRoomRepository, IUnitOfWork unitOfWork)
        {
            this.commandBus = commandBus;
            this.roomRepository = roomRepository;
            this.roomTypeRepository = roomTypeRepository;
            this.roomPropertyRepository = roomPropertyRepository;
            this.roomPropertyRoomRepository = roomPropertyRoomRepository;
            this.unitOfWork = unitOfWork;
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
                foreach (var command in roomTypes.Select(Mapper.Map<RoomTypeViewModel, CreateOrUpdateRoomTypeCommand>))
                {
                    commandBus.Validate(command);
                    if (ModelState.IsValid)
                    {
                        commandBus.Submit(command);
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
        [HttpPost]
        public ActionResult CreateOrUpdateRooms(string models)
        {
            var rooms = JsonConvert.DeserializeObject<List<RoomViewModel>>(models);
            if (ModelState.IsValid)
            {
                foreach (var command in rooms.Select(Mapper.Map<RoomViewModel, CreateOrUpdateRoomCommand>))
                {
                    commandBus.Validate(command);
                    if (ModelState.IsValid)
                    {
                        commandBus.Submit(command);
                    }
                }
                return Json(rooms, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteRooms(string models)
        {
            var rooms = JsonConvert.DeserializeObject<List<RoomViewModel>>(models);
            if (ModelState.IsValid)
            {
                foreach (var command in rooms.Select(Mapper.Map<RoomViewModel, DeleteRoomCommand>))
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
                    roomPropertyViewModel.RoomPropertyRoomID = roomPropertyRoom.RoomPropertyRoomID;
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
                        var roomPropertyRoom = new RoomPropertyRooms {
                            RoomPropertyRoomID = command.RoomPropertyRoomID != Guid.Empty ? command.RoomPropertyRoomID : Guid.NewGuid(),
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
                        else {
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
    }
}
