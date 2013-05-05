using System;

using Newtonsoft.Json;

namespace VietSovPetro.BO.ViewModels
{
    public class RoomPropertyRoomViewModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid RoomPropertyID { get; set; }
        public string RoomPropertyName { get; set; }
        public string RoomPropertyStringValue { get; set; }
        public int RoomPropertyNumberValue { get; set; }
        public string RoomPropertyType { get; set; }
        public string Unit { get; set; }
        public int OrderID { get; set; }
        public string LanguageCode { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPublished { get; set; }
        public bool IsNew { get; set; }
        public Guid RoomID { get; set; }
    }
}