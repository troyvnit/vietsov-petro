using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using VietSovPetro.Core.Common;

namespace VietSovPetro.Model.Entities
{
    public class RoomProperty
    {
        [Key]
        public Guid RoomPropertyID { get; set; }
        [Required]
        public string RoomPropertyName { get; set; }
        public string RoomPropertyType { get; set; }
        public string Unit { get; set; }
        public int OrderID { get; set; }
        public string LanguageCode { get; set; }
        
        public virtual ICollection<RoomPropertyRooms> RoomPropertyRooms { get; set; }
    }
}
