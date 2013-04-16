using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using VietSovPetro.Core.Common;

namespace VietSovPetro.Model.Entities
{
    public class Restaurant
    {
        public Restaurant()
        {
            CreatedOn = DateTime.Now;
        }
        [Key]
        public Guid RestaurantID { get; set; }
        [Required]
        public string RestaurantName { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPublished { get; set; }
        public bool IsNew { get; set; }
        public bool IsDeal { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid UpdatedBy { get; set; }
        public Guid ArticleID { get; set; }
        public virtual Article Article { get; set; }
        public virtual ICollection<RestaurantDetail> RestaurantDetails { get; set; }
        public virtual ICollection<RestaurantMenu> RestaurantMenus { get; set; }
    }
}
