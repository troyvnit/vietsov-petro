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
    public class RoomPropertyRooms
    {
        [Key, Column(Order = 0)]
        public Guid RoomPropertyID { get; set; }
        [Key, Column(Order = 1)]
        public Guid RoomID { get; set; }
        public string RoomPropertyStringValue { get; set; }
        public int RoomPropertyNumberValue { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPublished { get; set; }
        public bool IsNew { get; set; }
        public virtual RoomProperty RoomProperty { get; set; }
        public virtual Room Room { get; set; }
    }
}
