using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VietSovPetro.Model.Entities
{
    using System.Web.Mvc;

    public class Room
    {
        public Room()
        {
            CreatedOn = DateTime.Now;
            UpdatedOn = DateTime.Now;
        }
        [Key]
        public Guid RoomID { get; set; }
        [Required]
        public string RoomName { get; set; }
        [Required]
        public string RoomTypeName { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        [AllowHtml]
        public string Detail { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        public int OrderID { get; set; }
        public string LanguageCode { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPublished { get; set; }
        public bool IsNew { get; set; }
        public bool IsDeal { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid UpdatedBy { get; set; }
        public virtual ICollection<RoomType> RoomTypes { get; set; }
        public virtual ICollection<RoomPropertyRooms> RoomPropertyRooms { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
