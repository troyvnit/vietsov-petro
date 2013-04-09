using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using VietSovPetro.Core.Common;

namespace VietSovPetro.Domain.Entities
{
    public class Room
    {
        public Room()
        {
            CreatedOn = DateTime.Now;
        }
        [Key]
        public Guid RoomID { get; set; }
        [Required]
        public string RoomType { get; set; }
        [Required]
        public bool IsBooked { get; set; }
        public DateTime BookedFrom { get; set; }
        public DateTime BookedTo { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid UpdatedBy { get; set; }
        public Guid ArticleID { get; set; }
        public virtual Article Article { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
    }
}
