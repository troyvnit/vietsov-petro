using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace VietSovPetro.BO.ViewModels
{
    public class ArticleCategoryViewModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid ArticleCategoryID { get; set; }
        [Required]
        public string ArticleCategoryName { get; set; }
        [Required]
        public string ArticleCategoryType { get; set; }
        public string Description { get; set; }
    }
}