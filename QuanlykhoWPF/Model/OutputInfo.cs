//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanlykhoWPF.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class OutputInfo
    {
        public string Id { get; set; }
        public string IdObject { get; set; }
        public string IdInputInfo { get; set; }
        public int IdCustomer { get; set; }
        public Nullable<int> Count { get; set; }
        public string Status { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual InputInfo InputInfo { get; set; }
        public virtual Object Object { get; set; }
    }
}
