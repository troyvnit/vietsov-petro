using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace VietSovPetro.BO.ViewModels
{
    public class ArticleViewModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid ArticleID { get; set; }
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
        public bool IsPublished { get; set; }
        public bool IsNew { get; set; }
        public List<Guid> ArticleCategoryIDs { get; set; }
    }
}