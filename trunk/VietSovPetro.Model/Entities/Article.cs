using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using VietSovPetro.Core.Common;
using System.Web.Mvc;

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
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        [AllowHtml]
        public string Content { get; set; }
        [Required]
        public string Author { get; set; }
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
