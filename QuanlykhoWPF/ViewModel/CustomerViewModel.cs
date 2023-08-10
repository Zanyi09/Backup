using QuanlykhoWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace QuanlykhoWPF.ViewModel
{
    public class CustomerViewModel : BaseViewModel
    {
        private ObservableCollection<Customer> _list;
        public ObservableCollection<Customer> List { get => _list; set { _list = value; OnPropertyChanged(); } }

        private Customer _selecteditem;
        public Customer SelectedItem
        {
            get => _selecteditem;
            set
            {
                _selecteditem = value; OnPropertyChanged();
                if (SelectedItem != null)
                {
                    DisplayName = SelectedItem.DisplayName;
                    Address = SelectedItem.Address;
                    Email = SelectedItem.Email;
                    Phone = SelectedItem.Phone;
                    Moreinfo = SelectedItem.MoreInfo;
                    ContractDate = SelectedItem.ContractDate;
                }
            }
        }

        private string _displayname;
        public string DisplayName { get => _displayname; set { _displayname = value; OnPropertyChanged(); } }

        private string _address;
        public string Address { get => _address; set { _address = value; OnPropertyChanged(); } }

        private string _email;
        public string Email { get => _email; set { _email = value; OnPropertyChanged(); } }

        private string _phone;
        public string Phone { get => _phone; set { _phone = value; OnPropertyChanged(); } }

        private string _moreinfo;
        public string Moreinfo { get => _moreinfo; set { _moreinfo = value; OnPropertyChanged(); } }

        private DateTime? _contractDate;
        public DateTime? ContractDate { get => _contractDate; set { _contractDate = value; OnPropertyChanged(); } }

        public ICommand Addcommand { get; set; }
        public ICommand Editcommand { get; set; }
        public CustomerViewModel()
        {
            List = new ObservableCollection<Customer>(Dataprovider._Istance.DB.Customers);

            Addcommand = new RelayCommand<object>((p) =>
            {
                return true;
            },
            (p) =>
            {
                var Customeradd = new Customer() { DisplayName = DisplayName, Address = Address, Email = Email, Phone = Phone, MoreInfo = Moreinfo, ContractDate = ContractDate };
                Dataprovider._Istance.DB.Customers.Add(Customeradd);
                MessageBox.Show("Thêm thành công!");
                Dataprovider._Istance.DB.SaveChanges();

                List.Add(Customeradd);
            });

            Editcommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;
                var listsupplier = Dataprovider._Istance.DB.Customers.Where(a => a.Id == SelectedItem.Id);
                if (listsupplier != null || listsupplier.Count() != 0)
                    return true;
                return false;
            },
          (p) =>
          {
              var Customeredit = Dataprovider._Istance.DB.Customers.Where(a => a.Id == SelectedItem.Id).SingleOrDefault();
              Customeredit.DisplayName = DisplayName;
              Customeredit.Address = Address;
              Customeredit.Email = Email;
              Customeredit.Phone = Phone;
              Customeredit.MoreInfo = Moreinfo;
              Customeredit.ContractDate = ContractDate;

              Dataprovider._Istance.DB.SaveChanges();
              MessageBox.Show("Sửa thành công!");
              SelectedItem.DisplayName = DisplayName;
          });
        }
    }
}
