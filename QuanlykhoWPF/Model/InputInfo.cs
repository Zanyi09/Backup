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
    
    public partial class InputInfo
    {
        public string Id { get; set; }
        public string IdObject { get; set; }
        public string IdInput { get; set; }
        public Nullable<int> Count { get; set; }
        public Nullable<double> InputPrice { get; set; }
        public Nullable<double> OutputPrice { get; set; }
        public string Status { get; set; }
    
        public virtual Input Input { get; set; }
        public virtual Object Object { get; set; }
    }
}
