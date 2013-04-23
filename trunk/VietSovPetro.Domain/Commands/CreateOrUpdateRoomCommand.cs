using VietSovPetro.CommandProcessor.Commands.ICommands;
using System;
using System.Collections.Generic;
using VietSovPetro.Model.Entities;

namespace VietSovPetro.Domain.Commands
{
    public class CreateOrUpdateRoomCommand : ICommand
    {
        public CreateOrUpdateRoomCommand(Guid RoomID, string RoomName, DateTime? BookedFrom, DateTime? BookedTo, string Description,
            bool IsPublished, bool IsNew, bool IsDeal, Guid? ArticleID, Article Article, List<Guid> RoomTypeIDs)
        {
            this.RoomID = RoomID;
            this.RoomName = RoomName;
            this.BookedFrom = BookedFrom;
            this.BookedTo = BookedTo;
            this.Description = Description;
            this.IsPublished = IsPublished;
            this.IsNew = IsNew;
            this.IsDeal = IsDeal;
            this.ArticleID = ArticleID;
            this.Article = Article;
            this.RoomTypeIDs = RoomTypeIDs;
        }
        public Guid RoomID { get; set; }
        public string RoomName { get; set; }
        public DateTime? BookedFrom { get; set; }
        public DateTime? BookedTo { get; set; }
        public string Description { get; set; }
        public bool IsPublished { get; set; }
        public bool IsNew { get; set; }
        public bool IsDeal { get; set; }
        public Guid? ArticleID { get; set; }
        public virtual Article Article { get; set; }
        public List<Guid> RoomTypeIDs { get; set; }
    }
}
