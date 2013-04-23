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
    public class CanAddRoomProperty : IValidationHandler<CreateOrUpdateRoomPropertyCommand>
    {
        private readonly IRoomPropertyRepository roomPropertyRepository;
        public CanAddRoomProperty(IRoomPropertyRepository roomPropertyRepository)
        {
            this.roomPropertyRepository = roomPropertyRepository;
        }
        public IEnumerable<ValidationResult> Validate(CreateOrUpdateRoomPropertyCommand command)
        {
            RoomProperty isRoomPropertyExists = null;
            if (command.RoomPropertyID == Guid.Empty)
                isRoomPropertyExists = roomPropertyRepository.Get(c => c.RoomPropertyName == command.RoomPropertyName);
            else
                isRoomPropertyExists = roomPropertyRepository.Get(c => c.RoomPropertyName == command.RoomPropertyName && c.RoomPropertyID != command.RoomPropertyID);
            if (isRoomPropertyExists != null)
            {
                yield return new ValidationResult("RoomPropertyName", "Existed");
            }
        }
    }
}
