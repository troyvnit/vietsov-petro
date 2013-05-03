using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VietSovPetro.BO.Models
{
    public class BookFormModels
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int? Room { get; set; }
        public DateTime? Begin { get; set; }
        public DateTime? End { get; set; }
        public int? Time { get; set; }
        public int? GuestQuantity { get; set; }
        public string MeetingType { get; set; }
        public int? Price { get; set; }
        public string Message { get; set; }
        public string UserCardName { get; set; }
        public string UserCardNumber { get; set; }
        public string UserCardType { get; set; }
        public DateTime? DueDate { get; set; }
    }
}