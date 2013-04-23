using VietSovPetro.CommandProcessor.Commands.ICommands;
using System;
using System.Collections.Generic;
using VietSovPetro.Model.Entities;

namespace VietSovPetro.Domain.Commands
{
    public class CreateOrUpdateRoomPropertyCommand : ICommand
    {
        public CreateOrUpdateRoomPropertyCommand(Guid RoomPropertyID, string RoomPropertyName, string RoomPropertyStringValue,
            int RoomPropertyNumberValue, short RoomPropertyType, bool IsNew, bool IsPublished, Guid RoomID)
        {
            this.RoomPropertyID = RoomPropertyID;
            this.RoomPropertyName = RoomPropertyName;
            this.RoomPropertyStringValue = RoomPropertyStringValue;
            this.RoomPropertyNumberValue = RoomPropertyNumberValue;
            this.IsPublished = IsPublished;
            this.IsNew = IsNew;
            this.RoomPropertyType = RoomPropertyType;
            this.RoomID = RoomID;
        }
        public Guid RoomPropertyID { get; set; }
        public string RoomPropertyName { get; set; }
        public string RoomPropertyStringValue { get; set; }
        public int RoomPropertyNumberValue { get; set; }
        public short RoomPropertyType { get; set; }
        public bool IsPublished { get; set; }
        public bool IsNew { get; set; }
        public Guid RoomID { get; set; }
    }
}
