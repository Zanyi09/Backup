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
    public class UnitViewModel : BaseViewModel
    {
        private ObservableCollection<Unit> _list;
        public ObservableCollection<Unit> List { get => _list; set { _list = value; OnPropertyChanged(); } }

        private Unit _selecteditem;
        public Unit SelectedItem { get => _selecteditem; set { _selecteditem = value; OnPropertyChanged(); if (SelectedItem != null) { DisplayName = SelectedItem.DisplayName; } } }

        private string _displayname;
        public string DisplayName { get => _displayname; set { _displayname = value; OnPropertyChanged(); } }

        public ICommand Addcommand { get; set; }
        public ICommand Editcommand { get; set; }
        public ICommand Deletecommand { get; set; }
        public UnitViewModel()
        {
            List = new ObservableCollection<Unit>(Dataprovider._Istance.DB.Units);

            Addcommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(DisplayName))
                    return false;
                var listadd = Dataprovider._Istance.DB.Units.Where(a => a.DisplayName == DisplayName);
                if (listadd == null || listadd.Count() != 0)
                    return false;
                return true;
            }, 
            (p) =>
            {
                var unitadd = new Unit() { DisplayName = DisplayName };
                Dataprovider._Istance.DB.Units.Add(unitadd);
                System.Windows.MessageBox.Show("Thêm thành công!");
                Dataprovider._Istance.DB.SaveChanges();

                List.Add(unitadd);
            });

            Editcommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(DisplayName) || SelectedItem == null)
                    return false;
                var listadd = Dataprovider._Istance.DB.Units.Where(a => a.DisplayName == DisplayName);
                if (listadd == null || listadd.Count() != 0)
                    return false;
                return true;
            },
          (p) =>
          {
              var unitedit = Dataprovider._Istance.DB.Units.Where(a => a.Id == SelectedItem.Id).SingleOrDefault();
              unitedit.DisplayName = DisplayName;
              Dataprovider._Istance.DB.SaveChanges();
              System.Windows.Forms.MessageBox.Show("Sửa thành công!");
              SelectedItem.DisplayName = DisplayName;
          });
            Deletecommand = new RelayCommand<object>((p) =>
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
            var unitdel = Dataprovider._Istance.DB.Units.Where(a => a.Id == SelectedItem.Id).SingleOrDefault();
            Dataprovider._Istance.DB.Units.Remove(unitdel);
            Dataprovider._Istance.DB.SaveChanges();
            System.Windows.Forms.MessageBox.Show("Xóa thành công!");
        }
    }
}
