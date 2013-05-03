﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using VietSovPetro.Core.Common;

namespace VietSovPetro.Model.Entities
{
    public class RoomPropertyRooms
    {
        public RoomPropertyRooms()
        {
            RoomPropertyRoomID = Guid.NewGuid();
        }
        [Key]
        public Guid RoomPropertyRoomID { get; set; }
        public Guid RoomPropertyID { get; set; }
        public Guid RoomID { get; set; }
        public string RoomPropertyStringValue { get; set; }
        public int RoomPropertyNumberValue { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPublished { get; set; }
        public bool IsNew { get; set; }
        public virtual RoomProperty RoomProperty { get; set; }
        public virtual Room Room { get; set; }
    }
}