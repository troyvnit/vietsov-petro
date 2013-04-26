using System;
using VietSovPetro.CommandProcessor.Commands;
using VietSovPetro.CommandProcessor.Commands.ICommands;
using VietSovPetro.Data.Infrastructure;
using VietSovPetro.Data.Repositories.IRepositories;
using VietSovPetro.Domain.Commands;

namespace VietSovPetro.Domain.Handlers
{
    public class DeleteRoomTypeHandler : ICommandHandler<DeleteRoomTypeCommand>
    {
        private readonly IRoomTypeRepository roomTypeRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeleteRoomTypeHandler(IRoomTypeRepository roomTypeRepository, IUnitOfWork unitOfWork)
        {
            this.roomTypeRepository = roomTypeRepository;
            this.unitOfWork = unitOfWork;
        }
        public ICommandResult Execute(DeleteRoomTypeCommand command)
        {
            var ID = Guid.Empty;
            var roomType = roomTypeRepository.GetById(command.RoomTypeID);
            roomType.IsDeleted = true;
            roomTypeRepository.Update(roomType);
            ID = roomType.RoomTypeID;
            unitOfWork.Commit();
            return new CommandResult(true, ID);
        }
    }
}
