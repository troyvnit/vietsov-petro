using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using VietSovPetro.Core.Common;

namespace VietSovPetro.Model.Entities
{
    public class Article
    {
        public Article()
        {
            CreatedOn = DateTime.Now;
            UpdatedOn = DateTime.Now;
            //UserID = Guid.Parse("9680f042-3d4e-43ee-8573-f62a32cfd976");
        }
        [Key]
        public Guid ArticleID { get; set; }
        [Required]
        public int ActicleNumber { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        [MaxLength(50)]
        public string Author { get; set; }
        [MaxLength(256)]
        public string ImageUrl { get; set; }
        public int OrderID { get; set; }
        public string LanguageCode { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPublished { get; set; }
        public bool IsNew { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid UpdatedBy { get; set; }
        //public Guid UserID { get; set; }
        //public virtual User User { get; set; }
        public virtual ICollection<ArticleCategory> ArticleCategories { get; set; }
    }
}
