using QuanlykhoWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanlykhoWPF.ViewModel
{
    public class InputViewModel : BaseViewModel
    {
        private ObservableCollection<InputInfo> _list;
        public ObservableCollection<InputInfo> List { get => _list; set { _list = value; OnPropertyChanged(); } }

        private ObservableCollection<Input> _input;
        public ObservableCollection<Input> Inputlist { get => _input; set { _input = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.Object> _object;
        public ObservableCollection<Model.Object> Object { get => _object; set { _object = value; OnPropertyChanged(); } }


        private ObservableCollection<Unit> _Unit;
        public ObservableCollection<Unit> Unit { get => _Unit; set { _Unit = value; OnPropertyChanged(); } }

        private ObservableCollection<Suplier> _Suplier;
        public ObservableCollection<Suplier> Suplier { get => _Suplier; set { _Suplier = value; OnPropertyChanged(); } } 

        private InputInfo _selecteditem;
        public InputInfo SelectedItem { 
            get => _selecteditem; 
            set { _selecteditem = value; 
                OnPropertyChanged();
                if (SelectedItem != null) { 
                    IdObject = SelectedItem.IdObject;
                                                                        
                    Count = SelectedItem.Count;
                    InputPrice = SelectedItem.InputPrice;
                    OutputPrice = SelectedItem.OutputPrice;
                    Status = SelectedItem.Status;
                    SelectedInput = SelectedItem.Input;
                    Selectedobject = SelectedItem.Object;
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
        private string _Id;
        public string Id { get=> _Id; set { _Id = value; OnPropertyChanged(); } }
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



        public ICommand Addcommand { get; set; }
        public ICommand Editcommand { get; set; }
        public InputViewModel()
        {
            List = new ObservableCollection<InputInfo>(Dataprovider._Istance.DB.InputInfoes);
            Inputlist = new ObservableCollection<Input>(Dataprovider._Istance.DB.Inputs);
            Object = new ObservableCollection<Model.Object>(Dataprovider._Istance.DB.Objects);
            Unit = new ObservableCollection<Unit>(Dataprovider._Istance.DB.Units);
            Suplier = new ObservableCollection<Suplier>(Dataprovider._Istance.DB.Supliers);
            Addcommand = new RelayCommand<object>((p) =>
            {
                return true;
            },
            (p) =>
            {
                var Input = new Input() { Id = Guid.NewGuid().ToString(), DateInput = DateInput };
                Dataprovider._Istance.DB.Inputs.Add(Input);
                var Unit = new Model.Unit() { };
                var Supplier = new Model.Suplier() { };
                var Object = new Model.Object(){ Id= Guid.NewGuid().ToString(), DisplayName= Displayname,IdUnit= Unit.Id, IdSuplier=Supplier.Id};
                
                Dataprovider._Istance.DB.Objects.Add(Object);
                Dataprovider._Istance.DB.Units.Add(Unit);
                Dataprovider._Istance.DB.Supliers.Add(Supplier);
                var InputIfo = new InputInfo() { Id = Guid.NewGuid().ToString(),IdObject = Object.Id, IdInput = Input.Id, Count = Count, InputPrice = InputPrice, OutputPrice = OutputPrice, Status = Status };
                Dataprovider._Istance.DB.InputInfoes.Add(InputIfo);

                Dataprovider._Istance.DB.SaveChanges();
                List.Add(InputIfo);
                
            });

            Editcommand = new RelayCommand<object>((p) =>
            {
               // if (string.IsNullOrEmpty(DisplayName) || SelectedItem == null)
                   // return false;
                //var listadd = Dataprovider._Istance.DB.Inputs.Where(a => a.DisplayName == DisplayName);
                //if (listadd == null || listadd.Count() != 0)
                  //  return false;
                return true;
            },
          (p) =>
          {
              var Inputedit = Dataprovider._Istance.DB.Inputs.Where(a => a.Id == SelectedItem.Id).SingleOrDefault();
             // Inputedit.DisplayName = DisplayName;
              Dataprovider._Istance.DB.SaveChanges();

              //SelectedItem.DisplayName = DisplayName;
          });
        }
    }
}
