using VietSovPetro.CommandProcessor.Commands.ICommands;
using System;
using System.Collections.Generic;

namespace VietSovPetro.Domain.Commands
{
    public class CreateOrUpdateRoomTypeCommand : ICommand
    {
        public CreateOrUpdateRoomTypeCommand(Guid RoomTypeID, string RoomTypeName, string Description, string RoomGroup,
            bool IsPublished, bool IsNew, bool IsDeal, string LanguageCode)
        {
            this.RoomTypeID = RoomTypeID;
            this.RoomTypeName = RoomTypeName;
            this.RoomGroup = RoomGroup;
            this.Description = Description;
            this.IsPublished = IsPublished;
            this.IsNew = IsNew;
            this.IsDeal = IsDeal;
            this.LanguageCode = LanguageCode;
        }
        public Guid RoomTypeID { get; set; }
        public string RoomTypeName { get; set; }
        public string RoomGroup { get; set; }
        public string Description { get; set; }
        public string LanguageCode { get; set; }
        public bool IsPublished { get; set; }
        public bool IsNew { get; set; }
        public bool IsDeal { get; set; }
    }
}
