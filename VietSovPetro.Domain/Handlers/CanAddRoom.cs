using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietSovPetro.CommandProcessor.Commands;
using VietSovPetro.CommandProcessor.Commands.ICommands;
using VietSovPetro.Data.Repositories.IRepositories;
using VietSovPetro.Domain.Commands;
using VietSovPetro.Model.Entities;

namespace VietSovPetro.Domain.Handlers
{
    public class CanAddRoom : IValidationHandler<CreateOrUpdateRoomCommand>
    {
        private readonly IRoomRepository roomRepository;
        public CanAddRoom(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }
        public IEnumerable<ValidationResult> Validate(CreateOrUpdateRoomCommand command)
        {
            Room isRoomExists = null;
            if (command.RoomID == Guid.Empty)
                isRoomExists = roomRepository.Get(c => c.RoomName == command.RoomName);
            else
                isRoomExists = roomRepository.Get(c => c.RoomName == command.RoomName && c.RoomID != command.RoomID);
            if (isRoomExists != null)
            {
                yield return new ValidationResult("RoomName", "Existed");
            }
        }
    }
}
