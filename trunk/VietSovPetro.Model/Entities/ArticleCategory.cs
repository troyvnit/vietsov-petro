using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using VietSovPetro.Core.Common;

namespace VietSovPetro.Model.Entities
{
    public class ArticleCategory
    {
        [Key]
        public Guid ArticleCategoryID { get; set; }
        [Required]
        public string ArticleCategoryName { get; set; }
        [Required]
        public string ArticleCategoryType { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPublished { get; set; }
        public bool IsNew { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
