using VietSovPetro.CommandProcessor.Commands.ICommands;
using System;
using System.Collections.Generic;
using VietSovPetro.Model.Entities;

namespace VietSovPetro.Domain.Commands
{
    public class CreateOrUpdateRoomPropertyCommand : ICommand
    {
        public CreateOrUpdateRoomPropertyCommand(Guid RoomPropertyID, string RoomPropertyName, string RoomPropertyStringValue,
            decimal RoomPropertyNumberValue, string RoomPropertyType, bool IsNew, bool IsPublished, Guid RoomID, string Unit,
            int OrderID, Guid RoomPropertyRoomID)
        {
            this.RoomPropertyID = RoomPropertyID;
            this.RoomPropertyName = RoomPropertyName;
            this.RoomPropertyStringValue = RoomPropertyStringValue;
            this.RoomPropertyNumberValue = RoomPropertyNumberValue;
            this.IsPublished = IsPublished;
            this.IsNew = IsNew;
            this.RoomPropertyType = RoomPropertyType;
            this.RoomID = RoomID;
            this.Unit = Unit;
            this.OrderID = OrderID;
            this.RoomPropertyRoomID = RoomPropertyRoomID;
        }
        public Guid RoomPropertyID { get; set; }
        public string RoomPropertyName { get; set; }
        public string RoomPropertyStringValue { get; set; }
        public decimal RoomPropertyNumberValue { get; set; }
        public string RoomPropertyType { get; set; }
        public string Unit { get; set; }
        public int OrderID { get; set; }
        public bool IsPublished { get; set; }
        public bool IsNew { get; set; }
        public Guid RoomID { get; set; }
        public Guid RoomPropertyRoomID { get; set; }
    }
}
