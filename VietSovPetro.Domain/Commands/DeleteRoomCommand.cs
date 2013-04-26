using System;
using VietSovPetro.CommandProcessor.Commands.ICommands;

namespace VietSovPetro.Domain.Commands
{
    public class DeleteRoomCommand : ICommand
    {
        public Guid RoomID;
        public bool IsDeleted;
    }
}
