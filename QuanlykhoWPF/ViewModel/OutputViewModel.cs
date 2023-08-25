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
    public class OutputViewModel : BaseViewModel
    {
        private ObservableCollection<OutputInfo> _list;
        public ObservableCollection<OutputInfo> List { get => _list; set { _list = value; OnPropertyChanged(); } }

        private ObservableCollection<Output> _Output;
        public ObservableCollection<Output> Ouput { get => _Output; set { _Output = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.Object> _object;
        public ObservableCollection<Model.Object> Object { get => _object; set { _object = value; OnPropertyChanged(); } }

        private ObservableCollection<Customer> _customner;
        public ObservableCollection<Customer> Customer { get => _customner; set { _customner = value; OnPropertyChanged(); } }

        private ObservableCollection<InputInfo> _Inputinfo;
        public ObservableCollection<InputInfo> Inputinfo { get => _Inputinfo; set { _Inputinfo = value; OnPropertyChanged(); } }

        private OutputInfo _selecteditem;
        public OutputInfo SelectedItem
        {
            get => _selecteditem;
            set
            {
                _selecteditem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    IdObject = SelectedItem.IdObject;
                    Id = SelectedItem.Id;
                    IdObject = SelectedItem.IdObject;
                    IdInputInfo = SelectedItem.IdInputInfo;
                    IdCustomer = SelectedItem.IdCustomer;
                    Count = SelectedItem.Count;
                    Status = SelectedItem.Status;

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
        private Model.Object _Selectedobject;
        public Model.Object Selectedobject
        {
            get => _Selectedobject;
            set
            {
                _Selectedobject = value; OnPropertyChanged();
            }
        }
        private Customer _Selectedcutomer;
        public Customer Selectedcutomer
        {
            get => _Selectedcutomer;
            set
            {
                _Selectedcutomer = value; OnPropertyChanged();
            }
        }
        private InputInfo _Selectedinput;
        public InputInfo Selectedinput
        {
            get => _Selectedinput;
            set
            {
                _Selectedinput = value; OnPropertyChanged();
            }
        }
        private string _Id;
        public string Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }
        private string _IdObject;
        public string IdObject { get => _IdObject; set { _IdObject = value; OnPropertyChanged(); } }
        private string _IdInputInfo;
        public string IdInputInfo { get => _IdInputInfo; set { _IdInputInfo = value; OnPropertyChanged(); } }
        private int _IdCustomer;
        public int IdCustomer { get => _IdCustomer; set { _IdCustomer = value; OnPropertyChanged(); } }
        private Nullable<int> _Count;
        public Nullable<int> Count { get => _Count; set { _Count = value; OnPropertyChanged(); } }
        private string _Status;
        public string Status { get => _Status; set { _Status = value; OnPropertyChanged(); } }
        private DateTime? _DateOutput;
        public DateTime? DateOutput { get => _DateOutput; set { _DateOutput = value; OnPropertyChanged(); } }

        public ICommand Addcommand { get; set; }
        public ICommand Editcommand { get; set; }
        public ICommand Deletecommand { get; set; }
        public OutputViewModel()
        {
            List = new ObservableCollection<OutputInfo>(Dataprovider._Istance.DB.OutputInfoes);
            Ouput = new ObservableCollection<Output>(Dataprovider._Istance.DB.Outputs);
            Object = new ObservableCollection<Model.Object>(Dataprovider._Istance.DB.Objects.Join(Dataprovider._Istance.DB.InputInfoes, o => o.Id, i=>i.IdObject,(o,i)=>o));
            Inputinfo = new ObservableCollection<InputInfo>(Dataprovider._Istance.DB.InputInfoes);
            Customer = new ObservableCollection<Customer>(Dataprovider._Istance.DB.Customers);
            Addcommand = new RelayCommand<object>((p) =>
            {
                return true;
            },
           (p) =>
           {
               var Output = new Output() { Id = Guid.NewGuid().ToString(), DateOutput = DateOutput };
               Dataprovider._Istance.DB.Outputs.Add(Output);
               var Outputinfor = new OutputInfo() { Id = Guid.NewGuid().ToString(), IdObject = Selectedobject.Id,IdCustomer = Selectedcutomer.Id,  IdInputInfo = "22af7fa6-d4fc-4496-99bd-c3e7916f81be", Count = Count, Status = Status };
               if(Outputinfor.Status == "Complete")
               {
                   var editinputinfor = Dataprovider._Istance.DB.InputInfoes.Where(x => x.Id == Outputinfor.IdInputInfo).FirstOrDefault();
                   editinputinfor.Count -= Outputinfor.Count;

               }
               Dataprovider._Istance.DB.OutputInfoes.Add(Outputinfor);

               Dataprovider._Istance.DB.SaveChanges();
               List.Add(Outputinfor);

           });
        }
    }
}
