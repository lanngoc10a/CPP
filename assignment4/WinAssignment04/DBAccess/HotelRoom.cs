//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class HotelRoom
    {
        public int roomID { get; set; }
        public Nullable<int> roomNumb { get; set; }
        public Nullable<int> floorOfHotel { get; set; }
        public Nullable<int> numbOfBeds { get; set; }
        public Nullable<int> roomSize { get; set; }
        public Nullable<bool> cleaningStatus { get; set; }
        public Nullable<bool> service { get; set; }
        public Nullable<bool> maintenance { get; set; }
        public string taskNotes { get; set; }
        public bool isUsed { get; set; }
        public Nullable<int> resNumb { get; set; }
    }
}