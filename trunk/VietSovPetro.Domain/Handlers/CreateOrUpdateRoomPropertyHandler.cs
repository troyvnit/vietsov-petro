﻿using VietSovPetro.CommandProcessor.Commands.ICommands;
using VietSovPetro.Domain.Commands;
using VietSovPetro.Data.Infrastructure;
using VietSovPetro.Data.Repositories.IRepositories;
using VietSovPetro.Model.Entities;
using System;
using VietSovPetro.CommandProcessor.Commands;

namespace VietSovPetro.Domain.Handlers
{
    public class CreateOrUpdateRoomPropertyHandler : ICommandHandler<CreateOrUpdateRoomPropertyCommand>
    {
        private readonly IRoomPropertyRepository roomPropertyRepository;
        private readonly IUnitOfWork unitOfWork;
        public CreateOrUpdateRoomPropertyHandler(IRoomPropertyRepository roomPropertyRepository, IUnitOfWork unitOfWork)
        {
            this.roomPropertyRepository = roomPropertyRepository;
            this.unitOfWork = unitOfWork;
        }
        public ICommandResult Execute(CreateOrUpdateRoomPropertyCommand command)
        {
            var roomProperty = new RoomProperty
            {
                RoomPropertyID = command.RoomPropertyID,
                RoomPropertyName = command.RoomPropertyName,
                RoomPropertyStringValue = command.RoomPropertyStringValue,
                RoomPropertyNumberValue = command.RoomPropertyNumberValue,
                IsPublished = command.IsPublished,
                IsNew = command.IsNew,
                RoomPropertyType = command.RoomPropertyType,
                RoomID = command.RoomID
            };
            if (roomProperty.RoomPropertyID == Guid.Empty)
            {
                roomProperty.RoomPropertyID = Guid.NewGuid();
                roomPropertyRepository.Add(roomProperty);
            }
            else
            {
                roomPropertyRepository.Update(roomProperty);
            }
            unitOfWork.Commit();
            return new CommandResult(true);
        }
    }
}