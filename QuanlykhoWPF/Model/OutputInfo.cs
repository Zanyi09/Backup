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
    
    public partial class OutputInfo : BaseViewModel
    {
        private string _id;
        public string Id { get => _id; set { _id = value; OnPropertyChanged(); } }
        private string _IdObject;
        public string IdObject { get => _IdObject; set { _IdObject = value; OnPropertyChanged(); } }
        private string _IdInputInfo;
        public string IdInputInfo { get => _IdInputInfo; set { _IdInputInfo = value; OnPropertyChanged(); } }
        private int _IdCustomer;
        public int IdCustomer { get => _IdCustomer; set { _IdCustomer = value; OnPropertyChanged(); } }
        private Nullable<int> _Count;
        public Nullable<int> Count { get=> _Count; set { _Count = value; OnPropertyChanged(); } }
        private string _status;
        public string Status { get => _status; set { _status = value; OnPropertyChanged(); } }
        private DateTime? _DateOutput;
        public DateTime? DateOutput { get => _DateOutput; set { _DateOutput = value; OnPropertyChanged(); } }

        private Customer _customer;
        public virtual Customer Customer { get=> _customer; set { _customer = value; OnPropertyChanged(); } }
        private InputInfo _InputInfo;
        public virtual InputInfo InputInfo { get => _InputInfo; set { _InputInfo = value; OnPropertyChanged(); } }
        public Object _Object;
        public virtual Object Object { get => _Object; set { _Object = value; OnPropertyChanged(); } }
    }
}
