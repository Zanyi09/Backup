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
    public class ObjectViewModel : BaseViewModel
    {
        private ObservableCollection<Model.Object> _List;
        public ObservableCollection<Model.Object> List { get => _List; set { _List = value; OnPropertyChanged(nameof(_List)); } }

        private ObservableCollection<Unit> _Unit;
        public ObservableCollection<Unit> Unit { get => _Unit; set { _Unit = value; OnPropertyChanged(nameof(_Unit)); } }

        private ObservableCollection<Suplier> _Suplier;
        public ObservableCollection<Suplier> Suplier { get => _Suplier; set { _Suplier = value; OnPropertyChanged(nameof(_Suplier)); } }

        private Model.Object _selecteditem;
        public Model.Object SelectedItem
        {
            get => _selecteditem;
            set
            {
                _selecteditem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    DisplayName = SelectedItem.DisplayName;
                    QRCode = SelectedItem.QRCode;
                    BarCode = SelectedItem.BarCode;
                    SelectedUnit = SelectedItem.Unit;
                    SelectedSuplier = SelectedItem.Suplier;
                }
            }
        }
        private Unit _SelectedUnit;
        public Unit SelectedUnit
        {
            get => _SelectedUnit;
            set
            {
                _SelectedUnit = value;
                OnPropertyChanged();
            }
        }
        private Suplier _SelectedSuplier;
        public Suplier SelectedSuplier
        {
            get => _SelectedSuplier;
            set
            {
                _SelectedSuplier = value;
                OnPropertyChanged();

            }
        }

        private string _id;
        public string Id { get => _id; set { _id = value; OnPropertyChanged(); } }
        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }
        private int _IdUnit;
        public int IdUnit { get => _IdUnit; set { _IdUnit = value; OnPropertyChanged(); } }
        private int _IdSuplier;
        public int IdSuplier { get => _IdSuplier; set { _IdSuplier = value; OnPropertyChanged(); } }
        private string _QRCode;
        public string QRCode { get => _QRCode; set { _QRCode = value; OnPropertyChanged(); } }
        private string _BarCode;
        public string BarCode { get => _BarCode; set { _BarCode = value; OnPropertyChanged(); } }

        public ICommand Addcommand { get; set; }
        public ICommand Editcommand { get; set; }
        public ICommand Deletecommand { get; set; }
        public ObjectViewModel()
        {
            List = new ObservableCollection<Model.Object>(Dataprovider._Istance.DB.Objects);
            Unit = new ObservableCollection<Unit>(Dataprovider._Istance.DB.Units);
            OnPropertyChanged(nameof(Unit));
            Suplier = new ObservableCollection<Suplier>(Dataprovider._Istance.DB.Supliers);
            OnPropertyChanged(nameof(Suplier));
            OnPropertyChanged(nameof(SelectedUnit));
            OnPropertyChanged(nameof(SelectedSuplier));
            Addcommand = new RelayCommand<object>((p) =>
            {
                if (SelectedSuplier == null && SelectedUnit == null)
                    return false;
                return true;
            },
            (p) =>
            {
                var Objectadd = new Model.Object() { DisplayName = DisplayName, BarCode = BarCode, QRCode = QRCode, IdSuplier = SelectedSuplier.Id, IdUnit = SelectedUnit.Id, Id = Guid.NewGuid().ToString() };
                Dataprovider._Istance.DB.Objects.Add(Objectadd);
                System.Windows.MessageBox.Show("Thêm thành công!");
                Dataprovider._Istance.DB.SaveChanges();

                List.Add(Objectadd);
            });

            Editcommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null || SelectedUnit == null || SelectedSuplier == null)
                    return false;
                var listsupplier = Dataprovider._Istance.DB.Objects.Where(a => a.Id == SelectedItem.Id);
                if (listsupplier != null || listsupplier.Count() != 0)
                    return true;
                return false;
            },
          (p) =>
          {
              var Object = Dataprovider._Istance.DB.Objects.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
              Object.DisplayName = DisplayName;
              Object.BarCode = BarCode;
              Object.QRCode = QRCode;
              Object.IdSuplier = SelectedSuplier.Id;
              Object.IdUnit = SelectedUnit.Id;
              Dataprovider._Istance.DB.SaveChanges();

              System.Windows.MessageBox.Show("Sửa thành công!");
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
            var objectdel = Dataprovider._Istance.DB.Objects.Where(a => a.Id == SelectedItem.Id).SingleOrDefault();

            Dataprovider._Istance.DB.Objects.Remove(objectdel);
            Dataprovider._Istance.DB.SaveChanges();

            System.Windows.Forms.MessageBox.Show("Xóa thành công!");
            List.Remove(objectdel);
        }
    }
}
