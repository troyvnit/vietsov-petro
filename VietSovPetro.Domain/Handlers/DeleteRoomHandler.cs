using System;
using VietSovPetro.CommandProcessor.Commands;
using VietSovPetro.CommandProcessor.Commands.ICommands;
using VietSovPetro.Data.Infrastructure;
using VietSovPetro.Data.Repositories.IRepositories;
using VietSovPetro.Domain.Commands;

namespace VietSovPetro.Domain.Handlers
{
    public class DeleteRoomHandler : ICommandHandler<DeleteRoomCommand>
    {
        private readonly IRoomRepository roomRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeleteRoomHandler(IRoomRepository roomRepository, IUnitOfWork unitOfWork)
        {
            this.roomRepository = roomRepository;
            this.unitOfWork = unitOfWork;
        }
        public ICommandResult Execute(DeleteRoomCommand command)
        {
            var ID = Guid.Empty;
            var room = roomRepository.GetById(command.RoomID);
            room.IsDeleted = true;
            roomRepository.Update(room);
            ID = room.RoomID;
            unitOfWork.Commit();
            return new CommandResult(true, ID);
        }
    }
}
