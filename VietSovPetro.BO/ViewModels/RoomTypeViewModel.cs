using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using VietSovPetro.Model.Entities;

namespace VietSovPetro.BO.ViewModels
{
    public class RoomTypeViewModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid RoomTypeID { get; set; }
        [Required]
        public string RoomTypeName { get; set; }
        [Required]
        public string RoomGroup { get; set; }
        public string Description { get; set; }
        public string LanguageCode { get; set; }
        public bool IsPublished { get; set; }
        public bool IsNew { get; set; }
        public bool IsDeal { get; set; }
    }
}