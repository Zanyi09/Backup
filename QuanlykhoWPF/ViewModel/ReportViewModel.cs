using QuanlykhoWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanlykhoWPF.ViewModel
{
    public class ReportViewModel : BaseViewModel
    {
        private int _id;
        public int Id { get => _id; set { _id = value; OnPropertyChanged(); } }
        private int _IdSuplier;
        public int IdSuplier { get => _IdSuplier; set { _IdSuplier = value; OnPropertyChanged(); } }
        private string _IdObject;
        public string IdObject { get => _IdObject; set { _IdObject = value; OnPropertyChanged(); } }

        private string _displaysuplier;
        public string Displaysuplier { get => _displaysuplier; set { _displaysuplier = value; OnPropertyChanged(); } }
        private string _displayobject;
        public string Displayobject { get => _displayobject; set { _displayobject = value; OnPropertyChanged(); } }

        private Nullable<int> _Quantitysp;
        public Nullable<int> Quantitysp { get => _Quantitysp; set { _Quantitysp = value; OnPropertyChanged(); } }
        private Nullable<int> _Quantityob;
        public Nullable<int> Quantityob { get => _Quantityob; set { _Quantityob = value; OnPropertyChanged(); } }

        private ObservableCollection<Report> _list;
        public ObservableCollection<Report> List { get => _list; set { _list = value; OnPropertyChanged(); } }        

        private ObservableCollection<Report> _listob;
        public ObservableCollection<Report> Listob { get => _listob; set { _listob = value; OnPropertyChanged(); } }
        public ReportViewModel() 
        {
            LoaddataSuplier();
            LoaddataObject();

        }

        
        private void LoaddataSuplier()
        {
            int i = 1;
            List = new ObservableCollection<Report>();
            var suplierlist = Dataprovider._Istance.DB.Supliers.OrderByDescending(x => x.Objects.Count);
            foreach (var item in suplierlist)
            {
                Report reports = new Report();
                reports.Id = i;
                reports.Displaysuplier = item.DisplayName;
                reports.Quantitysp = item.Objects.Count;
                Dataprovider._Istance.DB.Reports.Add(reports);
                List.Add(reports);
                i++;
            }
            UpdateCollection(List);
        }
        private void LoaddataObject()
        {
            int input = 0;
            Listob = new ObservableCollection<Report>();
            var Inputlist = Dataprovider._Istance.DB.InputInfoes.OrderByDescending(p => p.Count);
            foreach (var item in Inputlist)
            {
                var s = Dataprovider._Istance.DB.InputInfoes.Where(p => p.IdObject == item.Id);
                if (Inputlist != null && Inputlist.Count() > 0)
                {
                    input = (int)Inputlist.Sum(p => p.Count);
                }
                Report report = new Report();
                report.Displayobject = item.Object.DisplayName;
                report.Quantityob = input;

                Listob.Add(report);
            }
            UpdateCollections(Listob);
        }

        private void UpdateCollection(IEnumerable<Report> reports)
        {
            List.Clear();
            foreach (var item in reports)
            {
                List.Add(item);
                OnPropertyChanged(nameof(List));
            }

        }

        private void UpdateCollections(IEnumerable<Report> reports)
        {
            Listob.Clear();
            foreach (var item in reports)
            {
                Listob.Add(item);
                OnPropertyChanged(nameof(Listob));
            }

        }
    }
}
