using QuanlykhoWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace QuanlykhoWPF.ViewModel
{
    public class SupplierViewModel : BaseViewModel
    {
        private ObservableCollection<Suplier> _list;
        public ObservableCollection<Suplier> List { get => _list; set { _list = value; OnPropertyChanged(); } }

        private Suplier _selecteditem;
        public Suplier SelectedItem
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
        public ICommand DeleteCommand { get; set; }
        public SupplierViewModel()
        {
            List = new ObservableCollection<Suplier>(Dataprovider._Istance.DB.Supliers);

            Addcommand = new RelayCommand<object>((p) =>
            {
                return true;
            },
            (p) =>
            {
                var Suplieradd = new Suplier() { DisplayName = DisplayName, Address = Address, Email = Email, Phone = Phone, MoreInfo = Moreinfo , ContractDate = ContractDate};
                Dataprovider._Istance.DB.Supliers.Add(Suplieradd);
                System.Windows.MessageBox.Show("Thêm thành công!");
                Dataprovider._Istance.DB.SaveChanges();

                List.Add(Suplieradd);
            });

            Editcommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;
                var listsupplier = Dataprovider._Istance.DB.Supliers.Where(a => a.Id == SelectedItem.Id);
                if (listsupplier != null || listsupplier.Count() != 0)
                    return true;
                return false;
            },
          (p) =>
          {
              var Suplieredit = Dataprovider._Istance.DB.Supliers.Where(a => a.Id == SelectedItem.Id).SingleOrDefault();
              Suplieredit.DisplayName = DisplayName;
              Suplieredit.Address = Address;
              Suplieredit.Email = Email;
              Suplieredit.Phone = Phone;
              Suplieredit.MoreInfo = Moreinfo;
              Suplieredit.ContractDate = ContractDate;
              Dataprovider._Istance.DB.SaveChanges();
              System.Windows.MessageBox.Show("Sửa thành công!");
              SelectedItem.DisplayName = DisplayName;
          });
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                return true;
            },
            (p) =>
            {
              DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo);
              if (dialogResult == DialogResult.Yes)
              {
                  Delete(p);
              }
            });
        }
        private void Delete(object b)
        {
            var supplierdel = Dataprovider._Istance.DB.Supliers.Where(a => a.Id == SelectedItem.Id).SingleOrDefault();
            Dataprovider._Istance.DB.Supliers.Remove(supplierdel);
            Dataprovider._Istance.DB.SaveChanges();
            System.Windows.Forms.MessageBox.Show("Xóa thành công!");
            List.Remove(supplierdel);
        }
    }
}
