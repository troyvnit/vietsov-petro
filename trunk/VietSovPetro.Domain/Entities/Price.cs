using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using VietSovPetro.Core.Common;

namespace VietSovPetro.Domain.Entities
{
    public class Price
    {
        public Price()
        {
            CreatedOn = DateTime.Now;
        }
        [Key]
        public Guid PriceID { get; set; }
        [Required]
        public Guid PriceType { get; set; }
        [Required]
        public Guid PriceValue { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid UpdatedBy { get; set; }
        public Guid RoomID { get; set; }
        public virtual Room Room { get; set; }
    }
}
