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
    
    public partial class Customer : BaseViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            this.OutputInfoes = new HashSet<OutputInfo>();
        }

        private int _id;
        public int Id { get => _id; set { _id = value; OnPropertyChanged(); } }
        private string _displayname;
        public string DisplayName { get => _displayname; set { _displayname = value; OnPropertyChanged(); } }
        private string _address;
        public string Address { get => _address; set { _address = value; OnPropertyChanged(); } }
        private string _Phone;
        public string Phone { get => _Phone; set { _Phone = value; OnPropertyChanged(); } }
        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }
        private string _MoreInfo;
        public string MoreInfo { get => _MoreInfo; set { _MoreInfo = value; OnPropertyChanged(); } }
        public Nullable<System.DateTime> ContractDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OutputInfo> OutputInfoes { get; set; }
    }
}
