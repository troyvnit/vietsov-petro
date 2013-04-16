using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using VietSovPetro.Core.Common;

namespace VietSovPetro.Model.Entities
{
    public class RestaurantMenu
    {
        [Key]
        public Guid RestaurantMenuID { get; set; }
        [Required]
        public string RestaurantMenuName { get; set; }
        public string RestaurantMenuValue { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPublished { get; set; }
        public bool IsNew { get; set; }
        public Guid RestaurantID { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
