using QuanlykhoWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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


        public List<Report> LstOfRecords { get; private set; } = new List<Report>();
        public List<Report> LstOfRecords2 { get; private set; } = new List<Report>();

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
                List.Add(reports);
                i++;
            }
          UpdateCollection(List.Take(5));
        }
        private void LoaddataObject()
        {
            List = new ObservableCollection<Report>();
            var Inputlist = Dataprovider._Istance.DB.InputInfoes.OrderByDescending(p => p.Count);
    
            foreach (var item in Inputlist)
            {
                Report report = new Report();
                report.Displayobject = item.Object.DisplayName;
                report.Quantityob = item.Count;

                List.Add(report);
            }
            UpdateCollections(List.Take(5));
        }

        private void UpdateCollection(IEnumerable<Report> reports)
        {
            LstOfRecords.Clear();
            foreach (var item in reports)
            {
                LstOfRecords.Add(item);
                OnPropertyChanged(nameof(LstOfRecords));
            }

        }

        private void UpdateCollections(IEnumerable<Report> reports)
        {
            LstOfRecords2.Clear();
            foreach (var item in reports)
            {
                LstOfRecords2.Add(item);
                OnPropertyChanged(nameof(LstOfRecords2));
            }

        }
    }
}
