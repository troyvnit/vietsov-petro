using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using VietSovPetro.Core.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace VietSovPetro.Model.Entities
{
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
        public DateTime? BookedFrom { get; set; }
        public DateTime? BookedTo { get; set; }
        public string Description { get; set; }
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
        public virtual ICollection<RoomProperty> RoomProperties { get; set; }
    }
}
