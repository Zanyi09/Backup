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
    
    public partial class Unit : BaseViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Unit()
        {
            this.Objects = new HashSet<Object>();
        }

        private int _id;
        public int Id { get => _id; set { _id = value; OnPropertyChanged(); } }
        private string _displayname;
        public string DisplayName { get => _displayname; set { _displayname = value; OnPropertyChanged(); } }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Object> Objects { get; set; }
    }
}
