using VietSovPetro.CommandProcessor.Commands.ICommands;
using VietSovPetro.Domain.Commands;
using VietSovPetro.Data.Infrastructure;
using VietSovPetro.Data.Repositories.IRepositories;
using VietSovPetro.Model.Entities;
using System;
using VietSovPetro.CommandProcessor.Commands;
using System.Collections.Generic;
using System.Linq;

namespace VietSovPetro.Domain.Handlers
{
    public class CreateOrUpdateRoomHandler : ICommandHandler<CreateOrUpdateRoomCommand>
    {
        private readonly IRoomRepository roomRepository;
        private readonly IRoomTypeRepository roomTypeRepository;
        private readonly IUnitOfWork unitOfWork;
        public CreateOrUpdateRoomHandler(IRoomRepository roomRepository, IUnitOfWork unitOfWork, IRoomTypeRepository roomTypeRepository)
        {
            this.roomRepository = roomRepository;
            this.unitOfWork = unitOfWork;
            this.roomTypeRepository = roomTypeRepository;
        }
        public ICommandResult Execute(CreateOrUpdateRoomCommand command)
        {
            var ID = Guid.Empty;
            if (command.RoomID == Guid.Empty)
            {
                var room = new Room
                {
                    RoomID = Guid.NewGuid(),
                    RoomName = command.RoomName,
                    Description = command.Description,
                    BookedFrom = command.BookedFrom,
                    BookedTo = command.BookedTo,
                    IsDeal = command.IsDeal,
                    IsNew = command.IsNew,
                    IsPublished = command.IsPublished,
                    IsDeleted = false,
                    ImageUrl = command.ImageUrl,
                    Quantity = command.Quantity,
                    OrderID = command.OrderID
                };
                room.RoomTypes = new List<RoomType>();
                foreach (Guid rID in command.RoomTypeIDs)
                {
                    var roomtype = roomTypeRepository.GetById(rID);
                    room.RoomTypes.Add(roomtype);
                }
                roomRepository.Add(room);
                ID = room.RoomID;
            }
            else
            {
                var room = roomRepository.GetById(command.RoomID);
                room.RoomName = command.RoomName;
                room.Description = command.Description;
                room.BookedFrom = command.BookedFrom;
                room.BookedTo = command.BookedTo;
                room.IsDeal = command.IsDeal;
                room.IsNew = command.IsNew;
                room.IsPublished = command.IsPublished;
                room.IsDeleted = false;
                room.ImageUrl = command.ImageUrl;
                room.Quantity = command.Quantity;
                room.OrderID = command.OrderID;

                var roomtypes = new List<RoomType>();
                foreach (Guid rID in command.RoomTypeIDs)
                {
                    var roomType = roomTypeRepository.GetById(rID);
                    roomtypes.Add(roomType);
                }
                var deleteCats = room.RoomTypes.Where(ac => !command.RoomTypeIDs.Contains(ac.RoomTypeID)).ToList();
                var addCats = roomtypes.Where(ac => !room.RoomTypes.Select(a => a.RoomTypeID).Contains(ac.RoomTypeID)).ToList();

                foreach (var deleteCat in deleteCats)
                {
                    room.RoomTypes.Remove(deleteCat);
                }

                foreach (var addCat in addCats)
                {
                    room.RoomTypes.Add(addCat);
                }
                roomRepository.Update(room);
                ID = room.RoomID;
            }
            unitOfWork.Commit();
            return new CommandResult(true, ID);
        }
    }
}
