using System;
using VietSovPetro.CommandProcessor.Commands.ICommands;

namespace VietSovPetro.Domain.Commands
{
    public class DeleteRoomPropertyCommand : ICommand
    {
        public Guid RoomPropertyID;
        public bool IsDeleted;
    }
}
