using VietSovPetro.CommandProcessor.Commands.ICommands;
using VietSovPetro.Domain.Commands;
using VietSovPetro.Data.Infrastructure;
using VietSovPetro.Data.Repositories.IRepositories;
using VietSovPetro.Model.Entities;
using System;
using VietSovPetro.CommandProcessor.Commands;

namespace VietSovPetro.Domain.Handlers
{
    public class CreateOrUpdateRoomPropertyHandler : ICommandHandler<CreateOrUpdateRoomPropertyCommand>
    {
        private readonly IRoomPropertyRepository roomPropertyRepository;
        private readonly IUnitOfWork unitOfWork;
        public CreateOrUpdateRoomPropertyHandler(IRoomPropertyRepository roomPropertyRepository, IUnitOfWork unitOfWork)
        {
            this.roomPropertyRepository = roomPropertyRepository;
            this.unitOfWork = unitOfWork;
        }
        public ICommandResult Execute(CreateOrUpdateRoomPropertyCommand command)
        {
            Guid ID;
            var roomProperty = new RoomProperty
            {
                RoomPropertyID = command.RoomPropertyID,
                RoomPropertyName = command.RoomPropertyName,
                RoomPropertyStringValue = command.RoomPropertyStringValue,
                RoomPropertyNumberValue = command.RoomPropertyNumberValue,
                IsPublished = command.IsPublished,
                IsNew = command.IsNew,
                RoomPropertyType = command.RoomPropertyType,
                RoomID = command.RoomID,
                OrderID = command.OrderID,
                LanguageCode = command.LanguageCode
            };
            if (roomProperty.RoomPropertyID == Guid.Empty)
            {
                roomProperty.RoomPropertyID = Guid.NewGuid();
                roomPropertyRepository.Add(roomProperty);
                ID = roomProperty.RoomPropertyID;
            }
            else
            {
                roomPropertyRepository.Update(roomProperty);
                ID = roomProperty.RoomPropertyID;
            }
            unitOfWork.Commit();
            return new CommandResult(true, ID);
        }
    }
}
