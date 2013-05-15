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
    public class CanAddRoomType : IValidationHandler<CreateOrUpdateRoomTypeCommand>
    {
        private readonly IRoomTypeRepository roomTypeRepository;
        public CanAddRoomType(IRoomTypeRepository roomTypeRepository)
        {
            this.roomTypeRepository = roomTypeRepository;
        }
        public IEnumerable<ValidationResult> Validate(CreateOrUpdateRoomTypeCommand command)
        {
            RoomType isRoomTypeExists = null;
            if (command.RoomTypeID == Guid.Empty)
                isRoomTypeExists = roomTypeRepository.Get(c => c.RoomGroup == command.RoomGroup);
            else
                isRoomTypeExists = roomTypeRepository.Get(c => c.RoomGroup == command.RoomGroup && c.RoomTypeID != command.RoomTypeID);
            if (isRoomTypeExists != null)
            {
                yield return new ValidationResult("RoomGroup", "Existed");
            }
        }
    }
}
