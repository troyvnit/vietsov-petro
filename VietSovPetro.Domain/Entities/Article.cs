using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using VietSovPetro.Core.Common;

namespace VietSovPetro.Domain.Entities
{
    public class Article
    {
        public Article()
        {
            CreatedOn = DateTime.Now;
        }
        [Key]
        public Guid ArticleID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Descripton { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid UpdatedBy { get; set; }
        public Guid UserID { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ArticleCategory> ArticleCategories { get; set; }
        public virtual ICollection<Gallery> Galleries { get; set; }
    }
}
