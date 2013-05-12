using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using VietSovPetro.Core.Common;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace VietSovPetro.Model.Entities
{
    public class Book
    {
        [Key]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid BookID { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Room { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? Begin { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? End { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Time { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? GuestQuantity { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string MeetingType { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Price { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string UserCardName { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string UserCardNumber { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string UserCardType { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? DueDate { get; set; }
    }
}
