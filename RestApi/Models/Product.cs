//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class product
    {
        public System.Guid C_Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public long price { get; set; }
        public int quantity { get; set; }
        public Nullable<System.Guid> User_Id { get; set; }
        public string image { get; set; }
    
        public virtual user user { get; set; }
    }
}
