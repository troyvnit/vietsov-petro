﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using VietSovPetro.Model.Entities;

namespace VietSovPetro.BO.ViewModels
{
    public class RoomPropertyViewModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid RoomPropertyID { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid RoomID { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid RoomPropertyRoomID { get; set; }
        [Required]
        public string RoomPropertyName { get; set; }
        public string RoomPropertyStringValue { get; set; }
        public decimal RoomPropertyNumberValue { get; set; }
        public string RoomPropertyType { get; set; }
        public string Unit { get; set; }
        public int OrderID { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPublished { get; set; }
        public bool IsNew { get; set; }
    }
}