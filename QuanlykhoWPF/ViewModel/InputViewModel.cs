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

        private ObservableCollection<Input> _listip;
        public ObservableCollection<Input> Listip { get => _listip; set { _listip = value; OnPropertyChanged(); } }

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
                    DateInput = SelectedInput.DateInput;
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
                OnPropertyChanged();
            }
        }
        private string _Id;
        public string Id { get=> _Id; set { _Id = value; OnPropertyChanged(); } }
        private string _IdObject;
        public string IdObject { get => _IdObject; set { _IdObject = value; OnPropertyChanged(); } }
        private string _IdInput;
        public string IdInput { get => _IdInput; set { _IdInput = value; OnPropertyChanged(); } }
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
            Listip = new ObservableCollection<Input>(Dataprovider._Istance.DB.Inputs);

            Addcommand = new RelayCommand<object>((p) =>
            {
                return true;
            },
            (p) =>
            {
                var InputIfo = new InputInfo() { Id = Guid.NewGuid().ToString(),IdObject = IdObject, IdInput = Guid.NewGuid().ToString(), Count = Count, InputPrice = InputPrice, OutputPrice = OutputPrice, Status = Status };
                Dataprovider._Istance.DB.InputInfoes.Add(InputIfo);
                var Input = new Input() { Id = IdInput,DateInput = DateInput };
                Dataprovider._Istance.DB.Inputs.Add(Input);
                Dataprovider._Istance.DB.InputInfoes.Add(InputIfo);
                Dataprovider._Istance.DB.Inputs.Add(Input);

                Dataprovider._Istance.DB.SaveChanges();

               List.Add(InputIfo);
               Listip.Add(Input);
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
