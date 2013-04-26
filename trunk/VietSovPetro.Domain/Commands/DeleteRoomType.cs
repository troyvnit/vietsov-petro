using System;
using VietSovPetro.CommandProcessor.Commands.ICommands;

namespace VietSovPetro.Domain.Commands
{
    public class DeleteRoomTypeCommand : ICommand
    {
        public Guid RoomTypeID;
        public bool IsDeleted;
    }
}
