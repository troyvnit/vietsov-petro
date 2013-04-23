using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using VietSovPetro.Model.Entities;

namespace VietSovPetro.BO.ViewModels
{
    public class RoomViewModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid RoomID { get; set; }
        [Required]
        public string RoomName { get; set; }
        public DateTime? BookedFrom { get; set; }
        public DateTime? BookedTo { get; set; }
        public string Description { get; set; }
        public bool IsPublished { get; set; }
        public bool IsNew { get; set; }
        public bool IsDeal { get; set; }
        public Guid? ArticleID { get; set; }
        public virtual Article Article { get; set; }
        public List<Guid> RoomTypeIDs { get; set; }
    }
}