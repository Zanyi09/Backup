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
    using QuanlykhoWPF.ViewModel;
    using System;
    using System.Collections.Generic;
    
    public partial class Input : BaseViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Input()
        {
            this.InputInfoes = new HashSet<InputInfo>();
        }
        private string _id;
        public string Id { get => _id; set { _id = value; OnPropertyChanged(); } }
        private Nullable<System.DateTime> _Datainput;
        public Nullable<System.DateTime> DateInput { get => _Datainput; set { _Datainput = value; OnPropertyChanged(); } }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InputInfo> InputInfoes { get; set; }
    }
}
