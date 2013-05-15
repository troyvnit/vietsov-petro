using VietSovPetro.CommandProcessor.Commands.ICommands;
using System;
using System.Collections.Generic;
using VietSovPetro.Model.Entities;

namespace VietSovPetro.Domain.Commands
{
    public class CreateOrUpdateRoomCommand : ICommand
    {
        public CreateOrUpdateRoomCommand(Guid RoomID, string RoomName, string RoomTypeName, DateTime? BookedFrom, DateTime? BookedTo, string Description,
            bool IsPublished, bool IsNew, bool IsDeal, Guid? ArticleID, List<Guid> RoomTypeIDs,
            int Quantity, string ImageUrl, int OrderID, string LanguageCode)
        {
            this.RoomID = RoomID;
            this.RoomName = RoomName;
            this.RoomTypeName = RoomTypeName;
            this.BookedFrom = BookedFrom;
            this.BookedTo = BookedTo;
            this.Description = Description;
            this.IsPublished = IsPublished;
            this.IsNew = IsNew;
            this.IsDeal = IsDeal;
            this.RoomTypeIDs = RoomTypeIDs;
            this.Quantity = Quantity;
            this.ImageUrl = ImageUrl;
            this.OrderID = OrderID;
            this.LanguageCode = LanguageCode;
        }
        public Guid RoomID { get; set; }
        public string RoomName { get; set; }
        public string RoomTypeName { get; set; }
        public DateTime? BookedFrom { get; set; }
        public DateTime? BookedTo { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int OrderID { get; set; }
        public string LanguageCode { get; set; }
        public string ImageUrl { get; set; }
        public bool IsPublished { get; set; }
        public bool IsNew { get; set; }
        public bool IsDeal { get; set; }
        public List<Guid> RoomTypeIDs { get; set; }
    }
}
