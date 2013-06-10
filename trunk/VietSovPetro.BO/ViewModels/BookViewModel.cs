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
    using VietSovPetro.Model.Entities;

    public class BookViewModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid BookID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public RoomViewModel Room { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public string Time { get; set; }
        public string GuestQuantity { get; set; }
        public string MeetingType { get; set; }
        public string Price { get; set; }
        public string Message { get; set; }
        public string NoOfRoom { get; set; }
        public string NoOfGuest { get; set; }
        public string Children { get; set; }
        public string KindOfBed { get; set; }
        public string Airline { get; set; }
        public string FlightNo { get; set; }
        public string EstimatedArrivalTime { get; set; }
        public string NonSmoking { get; set; }
        public string SpecialRequest { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string UserCardName { get; set; }
        public string UserCardNumber { get; set; }
        public string UserCardType { get; set; }
        public DateTime? DueDate { get; set; }
    }
}