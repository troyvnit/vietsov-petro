using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace VietSovPetro.BO.ViewModels
{
    public class BookViewModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid BookID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public Guid RoomID { get; set; }
        [Required]
        public DateTime Begin { get; set; }
        [Required]
        public DateTime End { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public string GuestQuantity { get; set; }
        public string MeetingType { get; set; }
        [Required]
        public string Price { get; set; }
        public string Message { get; set; }
        public string UserCardName { get; set; }
        public string UserCardNumber { get; set; }
        public string UserCardType { get; set; }
        public DateTime? DueDate { get; set; }
    }
}