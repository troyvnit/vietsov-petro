using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using VietSovPetro.Core.Common;

namespace VietSovPetro.Model.Entities
{
    public class RoomDetail
    {
        [Key]
        public Guid RoomDetailID { get; set; }
        [Required]
        public string RoomDetailName { get; set; }
        public string RoomDetailValue { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPublished { get; set; }
        public bool IsNew { get; set; }
        public Guid RoomID { get; set; }
        public virtual Room Room { get; set; }
    }
}
