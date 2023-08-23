using QuanlykhoWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Forms;

namespace QuanlykhoWPF.ViewModel
{
    public class InputViewModel : BaseViewModel
    {
        private ObservableCollection<InputInfo> _list;
        public ObservableCollection<InputInfo> List { get => _list; set { _list = value; OnPropertyChanged(); } }

        private ObservableCollection<Input> _input;
        public ObservableCollection<Input> Input { get => _input; set { _input = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.Object> _object;
        public ObservableCollection<Model.Object> Object { get => _object; set { _object = value; OnPropertyChanged(); } }


        private ObservableCollection<Unit> _Unit;
        public ObservableCollection<Unit> Unit { get => _Unit; set { _Unit = value; OnPropertyChanged(); } }

        private ObservableCollection<Suplier> _Suplier;
        public ObservableCollection<Suplier> Suplier { get => _Suplier; set { _Suplier = value; OnPropertyChanged(); } }

        private InputInfo _selecteditem;
        public InputInfo SelectedItem
        {
            get => _selecteditem;
            set
            {
                _selecteditem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    IdObject = SelectedItem.IdObject;

                    Count = SelectedItem.Count;
                    InputPrice = SelectedItem.InputPrice;
                    OutputPrice = SelectedItem.OutputPrice;
                    Status = SelectedItem.Status;
                    Selectedobject = SelectedItem.Object;
                    SelectedInput = SelectedItem.Input;
                }
            }
        }
        private Input _Selectedinput;
        public Input SelectedInput
        {
            get => _Selectedinput;
            set
            {
                _Selectedinput = value; OnPropertyChanged();
                DateInput = SelectedInput.DateInput;
            }
        }
        private Model.Object _Selectedobject;
        public Model.Object Selectedobject
        {
            get => _Selectedobject;
            set
            {
                _Selectedobject = value; OnPropertyChanged();
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
        private string _Id;
        public string Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }
        private string _IdObject;
        public string IdObject { get => _IdObject; set { _IdObject = value; OnPropertyChanged(); } }
        private string _IdInput;
        public string IdInput { get => _IdInput; set { _IdInput = value; OnPropertyChanged(); } }

        private string _displayname;
        public string Displayname { get => _displayname; set { _displayname = value; OnPropertyChanged(); } }

        private int _Count;
        public Nullable<int> Count { get => _Count; set { _Count = (int)value; OnPropertyChanged(); } }
        private double _InputPrice;
        public Nullable<double> InputPrice { get => _InputPrice; set { _InputPrice = (int)value; OnPropertyChanged(); } }
        private double _OutputPrice;
        public Nullable<double> OutputPrice { get => _OutputPrice; set { _OutputPrice = (int)value; OnPropertyChanged(); } }
        private string _Status;
        public string Status { get => _Status; set { _Status = value; OnPropertyChanged(); } }
        private DateTime? _DateInput;
        public DateTime? DateInput { get => _DateInput; set { _DateInput = value; OnPropertyChanged(); } }

        public ICommand FirstCommand { get; set; }
        public ICommand PreviousCommand { get; set; }
        public ICommand NextCommand { get; set; }
        public ICommand LastCommand { get; set; }

        /// </pagination>
        public ICommand Addcommand { get; set; }
        public ICommand Editcommand { get; set; }
        public ICommand Deletecommand { get; set; }
        public InputViewModel()
        {
            List = new ObservableCollection<InputInfo>(Dataprovider._Istance.DB.InputInfoes);
            Input = new ObservableCollection<Input>(Dataprovider._Istance.DB.Inputs);
            Object = new ObservableCollection<Model.Object>(Dataprovider._Istance.DB.Objects);
            //Loadpagination();
            Addcommand = new RelayCommand<object>((p) =>
            {
                return true;
            },
            (p) =>
            {
                var Input = new Input() { Id = Guid.NewGuid().ToString(), DateInput = DateInput };
                Dataprovider._Istance.DB.Inputs.Add(Input);
                var InputIfo = new InputInfo() { Id = Guid.NewGuid().ToString(), IdObject = Selectedobject.Id, IdInput = Input.Id, Count = Count, InputPrice = InputPrice, OutputPrice = OutputPrice, Status = Status };
                Dataprovider._Istance.DB.InputInfoes.Add(InputIfo);

                Dataprovider._Istance.DB.SaveChanges();
                List.Add(InputIfo);

            });

            Editcommand = new RelayCommand<object>((p) =>
            {
                return true;
            },
          (p) =>
          {
              var Inputedit = Dataprovider._Istance.DB.InputInfoes.Where(a => a.Id == SelectedItem.Id).SingleOrDefault();
              var nameedit = Dataprovider._Istance.DB.Objects.Where(b => b.DisplayName == Selectedobject.DisplayName).FirstOrDefault();
              var dateedit = Dataprovider._Istance.DB.Inputs.Where(c => c.DateInput == SelectedInput.DateInput).FirstOrDefault();
              Inputedit.IdObject = IdObject;
              nameedit.DisplayName = Selectedobject.DisplayName;
              dateedit.DateInput = DateInput;
              Inputedit.Count = Count;
              Inputedit.InputPrice = InputPrice;
              Inputedit.OutputPrice = OutputPrice;
              Inputedit.Status = Status;
              Dataprovider._Istance.DB.SaveChanges();


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
            var input = Dataprovider._Istance.DB.Inputs.Where(x => x.Id == SelectedInput.Id).FirstOrDefault();
            var inputdel = Dataprovider._Istance.DB.InputInfoes.Where(a => a.Id == SelectedItem.Id).SingleOrDefault();

            Dataprovider._Istance.DB.Inputs.Remove(input);
            Dataprovider._Istance.DB.InputInfoes.Remove(inputdel);
            Dataprovider._Istance.DB.SaveChanges();
            System.Windows.Forms.MessageBox.Show("Xóa thành công!");
            List.Remove(inputdel);
        }
    }
}
