using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using VietSovPetro.Core.Common;

namespace VietSovPetro.Model.Entities
{
    public class Gallery
    {
        [Key]
        public Guid GalleryID { get; set; }
        [Required]
        public string GalleryType { get; set; }
        [Required]
        public string Url { get; set; }
        public Guid ArticleID { get; set; }
        public virtual Article Article { get; set; }

    }
}
