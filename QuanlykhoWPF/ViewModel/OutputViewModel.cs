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
    public class OutputViewModel :BaseViewModel
    {
        private ObservableCollection<InputInfo> _list;
        public ObservableCollection<InputInfo> List { get => _list; set { _list = value; OnPropertyChanged(); } }

        private ObservableCollection<Output> _output;
        public ObservableCollection<Output> Outputlist { get => _output; set { _output = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.Object> _object;
        public ObservableCollection<Model.Object> Object { get => _object; set { _object = value; OnPropertyChanged(); } }


        private ObservableCollection<Unit> _Unit;
        public ObservableCollection<Unit> Unit { get => _Unit; set { _Unit = value; OnPropertyChanged(); } }

        private ObservableCollection<Suplier> _Suplier;
        public ObservableCollection<Suplier> Suplier { get => _Suplier; set { _Suplier = value; OnPropertyChanged(); } }


        private ObservableCollection<Customer> _customer;
        public ObservableCollection<Customer> Customer { get => _customer; set { _customer = value; OnPropertyChanged(); } }

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
                    OutputPrice = SelectedItem.OutputPrice;
                    Status = SelectedItem.Status;
                   // SelectedOutput = SelectedItem.Object;
                    Selectedobject = SelectedItem.Object;
                }
            }
        }
        private Output _Selectedoutput;
        public Output SelectedOutput
        {
            get => _Selectedoutput;
            set
            {
                _Selectedoutput = value; OnPropertyChanged();
                DateOutput = SelectedOutput.DateOutput;
            }
        }
        private Input _Selectedcustomer;
        public Input SelectedCustomer
        {
            get => _Selectedcustomer;
            set
            {
                _Selectedcustomer = value; OnPropertyChanged();
            }
        }
        private Model.Object _Selectedobject;
        public Model.Object Selectedobject
        {
            get => _Selectedobject;
            set
            {
                _Selectedobject = value; OnPropertyChanged();
                Displayname = _Selectedobject.DisplayName;
            }
        }
        private Customer _selectedCustomer;
        public Customer Customers
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value; OnPropertyChanged();
                Displayname = _Selectedobject.DisplayName;
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
       
        private DateTime? _DateOutput;
        public DateTime? DateOutput { get => _DateOutput; set { _DateOutput = value; OnPropertyChanged(); } }


        public ICommand Addcommand { get; set; }
        public ICommand Editcommand { get; set; }
        public OutputViewModel()
        {
            List = new ObservableCollection<InputInfo>(Dataprovider._Istance.DB.InputInfoes);
            Outputlist = new ObservableCollection<Output>(Dataprovider._Istance.DB.Outputs);
            Object = new ObservableCollection<Model.Object>(Dataprovider._Istance.DB.Objects);
            Unit = new ObservableCollection<Unit>(Dataprovider._Istance.DB.Units);
            Suplier = new ObservableCollection<Suplier>(Dataprovider._Istance.DB.Supliers);
            Customer = new ObservableCollection<Customer>(Dataprovider._Istance.DB.Customers);
            Addcommand = new RelayCommand<object>((p) =>
            {
                return true;
            },
            (p) =>
            {
                //var Input = new Input() { Id = Guid.NewGuid().ToString(), DateInput = DateInput };
                //Dataprovider._Istance.DB.Inputs.Add(Input);
                var Unit = new Model.Unit() { };
                var Supplier = new Model.Suplier() { };
                var Object = new Model.Object() { Id = Guid.NewGuid().ToString(), DisplayName = Displayname, IdUnit = Unit.Id, IdSuplier = Supplier.Id };

                Dataprovider._Istance.DB.Objects.Add(Object);
                Dataprovider._Istance.DB.Units.Add(Unit);
                Dataprovider._Istance.DB.Supliers.Add(Supplier);
               // var InputIfo = new InputInfo() { Id = Guid.NewGuid().ToString(), IdObject = Object.Id, IdInput = Input.Id, Count = Count, InputPrice = InputPrice, OutputPrice = OutputPrice, Status = Status };
               // Dataprovider._Istance.DB.InputInfoes.Add(InputIfo);

                Dataprovider._Istance.DB.SaveChanges();
              //  List.Add(InputIfo);

            });

            Editcommand = new RelayCommand<object>((p) =>
            {
                return true;
            },
          (p) =>
          {
              var Inputedit = Dataprovider._Istance.DB.InputInfoes.Where(a => a.Id == SelectedItem.Id).SingleOrDefault();
              var nameedit = Dataprovider._Istance.DB.Objects.Where(b => b.DisplayName == Selectedobject.DisplayName).FirstOrDefault();
              var dateedit = Dataprovider._Istance.DB.Outputs.Where(c => c.DateOutput == SelectedOutput.DateOutput).FirstOrDefault();
              //var Customeredit = Dataprovider._Istance.DB.Customers.Where(c => c.DateOutput == SelectedOutput.DateOutput).FirstOrDefault();
              Inputedit.IdObject = IdObject;
              nameedit.DisplayName = Displayname;
              dateedit.DateOutput = DateOutput;
              Inputedit.Count = Count;
              Inputedit.OutputPrice = OutputPrice;
              Inputedit.Status = Status;
              Dataprovider._Istance.DB.SaveChanges();

              Selectedobject.DisplayName = Displayname;

          });
        }
    }
}
