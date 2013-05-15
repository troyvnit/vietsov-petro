using VietSovPetro.CommandProcessor.Commands.ICommands;
using VietSovPetro.Domain.Commands;
using VietSovPetro.Data.Infrastructure;
using VietSovPetro.Data.Repositories.IRepositories;
using VietSovPetro.Model.Entities;
using System;
using VietSovPetro.CommandProcessor.Commands;

namespace VietSovPetro.Domain.Handlers
{
    public class CreateOrUpdateRoomTypeHandler : ICommandHandler<CreateOrUpdateRoomTypeCommand>
    {
        private readonly IRoomTypeRepository roomTypeRepository;
        private readonly IUnitOfWork unitOfWork;
        public CreateOrUpdateRoomTypeHandler(IRoomTypeRepository roomTypeRepository, IUnitOfWork unitOfWork)
        {
            this.roomTypeRepository = roomTypeRepository;
            this.unitOfWork = unitOfWork;
        }
        public ICommandResult Execute(CreateOrUpdateRoomTypeCommand command)
        {
            Guid ID;
            var roomType = new RoomType
            {
                RoomTypeID = command.RoomTypeID,
                RoomGroup = command.RoomGroup,
                Description = command.Description,
                IsPublished = command.IsPublished,
                IsNew = command.IsNew,
                IsDeal = command.IsDeal,
                LanguageCode = command.LanguageCode
            };
            if (roomType.RoomTypeID == Guid.Empty)
            {
                roomType.RoomTypeID = Guid.NewGuid();
                roomTypeRepository.Add(roomType);
                ID = roomType.RoomTypeID;
            }
            else
            {
                roomTypeRepository.Update(roomType);
                ID = roomType.RoomTypeID;
            }
            unitOfWork.Commit();
            return new CommandResult(true, ID);
        }
    }
}
