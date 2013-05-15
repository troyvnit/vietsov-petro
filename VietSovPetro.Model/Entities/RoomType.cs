using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using VietSovPetro.Core.Common;

namespace VietSovPetro.Model.Entities
{
    public class RoomType
    {
        [Key]
        public Guid RoomTypeID { get; set; }
        [Required]
        public string RoomGroup { get; set; }
        public string LanguageCode { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPublished { get; set; }
        public bool IsNew { get; set; }
        public bool IsDeal { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
