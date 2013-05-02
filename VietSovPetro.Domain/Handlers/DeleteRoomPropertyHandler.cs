using System;
using VietSovPetro.CommandProcessor.Commands;
using VietSovPetro.CommandProcessor.Commands.ICommands;
using VietSovPetro.Data.Infrastructure;
using VietSovPetro.Data.Repositories.IRepositories;
using VietSovPetro.Domain.Commands;

namespace VietSovPetro.Domain.Handlers
{
    public class DeleteRoomPropertyHandler : ICommandHandler<DeleteRoomPropertyCommand>
    {
        private readonly IRoomPropertyRepository roomPropertyRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeleteRoomPropertyHandler(IRoomPropertyRepository roomPropertyRepository, IUnitOfWork unitOfWork)
        {
            this.roomPropertyRepository = roomPropertyRepository;
            this.unitOfWork = unitOfWork;
        }
        public ICommandResult Execute(DeleteRoomPropertyCommand command)
        {
            var ID = Guid.Empty;
            var roomProperty = roomPropertyRepository.GetById(command.RoomPropertyID);
            roomPropertyRepository.Update(roomProperty);
            ID = roomProperty.RoomPropertyID;
            unitOfWork.Commit();
            return new CommandResult(true, ID);
        }
    }
}
