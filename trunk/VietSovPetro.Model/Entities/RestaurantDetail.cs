using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using VietSovPetro.Core.Common;

namespace VietSovPetro.Model.Entities
{
    public class RestaurantDetail
    {
        [Key]
        public Guid RestaurantDetailID { get; set; }
        [Required]
        public string RestaurantDetailName { get; set; }
        public string RestaurantDetailValue { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPublished { get; set; }
        public bool IsNew { get; set; }
        public Guid RestaurantID { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
