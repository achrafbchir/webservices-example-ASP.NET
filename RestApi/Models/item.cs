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
    
    public partial class item
    {
        public System.Guid ItemId { get; set; }
        public Nullable<System.Guid> Cart_CartId { get; set; }
        public Nullable<System.Guid> product_Id { get; set; }
        public int quantity { get; set; }
    
        public virtual cart cart { get; set; }
    }
}