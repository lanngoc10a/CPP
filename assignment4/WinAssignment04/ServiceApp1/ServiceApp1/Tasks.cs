//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tasks
    {
        public int taskID { get; set; }
        public Nullable<int> roomNumb { get; set; }
        public bool cleaningStatus { get; set; }
        public bool roomService { get; set; }
        public bool maintenance { get; set; }
        public string taskStatus { get; set; }
    }
}