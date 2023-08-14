using QuanlykhoWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;

namespace QuanlykhoWPF.ViewModel
{
    public class MainViewModel :BaseViewModel
    {
        private ObservableCollection<Inventory> _Tonkholist;
        public ObservableCollection<Inventory> Tonkholist { get => _Tonkholist; set {  _Tonkholist = value; OnPropertyChanged(); } }

        public bool IsLoading = false;
        public ICommand WindowLoaded { get; set; }
        public ICommand Unitcommand { get; set; }
        public ICommand Suppliercommand { get; set; }
        public ICommand Customercommand { get; set; }
        public ICommand Objectcommand { get; set; }
        public ICommand Usercommand { get; set; }
        public ICommand Inputcommand { get;set; }
        public ICommand Outputcommand { get;set; }
        public ICommand Logoutcommand { get; set; }
        public ICommand FirstCommand { get; set; }
        public ICommand PreviousCommand { get; set; }
        public ICommand NextCommand { get; set; }
        public ICommand LastCommand { get; set; }
        public string filePath = "C:/Users/ssvan/source/repos/QuanlykhoWPF/login.txt";

        private int _currentPage =1;
        public int CurrentPage
        {
            get => _currentPage; 
            set
            {
                _currentPage = value; OnPropertyChanged();
            }
        }

        private int _NumberofPage =10;
        public int NumberofPage
        {
            get => _NumberofPage; 
            set
            {
                _NumberofPage = value; OnPropertyChanged();
                UpdateEnableState();
            }
        }

        private void UpdateEnableState()
        {
            IsFirstEnabled = CurrentPage > 1;
            IsPreviousEnabled = CurrentPage > 1;
            IsNextEnabled = CurrentPage < NumberofPage;
            IsLastEnabled = CurrentPage < NumberofPage;
        }

        private int _selectedrecord = 5;
        public int SelectedRecord
        {
            get => _selectedrecord;
            set
            {
                _selectedrecord = value; OnPropertyChanged();
                UpdateRecordCount();
            }
        }
        private bool _isFirstEnabled;

        public bool IsFirstEnabled
        {
            get { return _isFirstEnabled; }
            set
            {
                _isFirstEnabled = value;
                OnPropertyChanged(nameof(IsFirstEnabled));
            }
        }
        private bool _isPreviousEnabled;
        public bool IsPreviousEnabled
        {
            get { return _isPreviousEnabled; }
            set
            {
                _isPreviousEnabled = value;
                OnPropertyChanged(nameof(IsPreviousEnabled));
            }
        }
        private bool _isNextEnabled;

        public bool IsNextEnabled
        {
            get { return _isNextEnabled; }
            set
            {
                _isNextEnabled = value;
                OnPropertyChanged(nameof(IsNextEnabled));
            }
        }
        private bool _isLastEnabled;

        public bool IsLastEnabled
        {
            get { return _isLastEnabled; }
            set
            {
                _isLastEnabled = value;
                OnPropertyChanged(nameof(IsLastEnabled));
            }
        }
        private int _Soluongtonkho =0;
        public int Soluongtonkho
        {
            get { return _Soluongtonkho; }
            set
            {
                _Soluongtonkho = value;
                OnPropertyChanged();
            }
        }
        private int _Soluongnhap = 0;
        public int Soluongnhap
        {
            get { return _Soluongnhap; }
            set
            {
                _Soluongnhap = value;
                OnPropertyChanged();
            }
        }
        private int _Soluongxuat= 0;
        public int Soluongxuat
        {
            get { return _Soluongxuat; }
            set
            {
                _Soluongxuat = value;
                OnPropertyChanged();
            }
        }
        //public List<Inventory> LstOfRecords { get; private set; } = new List<Inventory>();
        int RecordStartFrom = 0;
        private void LastPage(object obj)
        {
            var recordsToskip = SelectedRecord * (NumberofPage - 1);
            UpdateCollection(LstOfRecords.Skip(recordsToskip));
            CurrentPage = NumberofPage;
            UpdateEnableState();
        }
        private void FirstPage(object obj)
        {
            UpdateCollection(LstOfRecords.Take(SelectedRecord));
            CurrentPage = 1;
            UpdateEnableState();
        }
        private void PreviousPage(object obj)
        {
            CurrentPage--;
            RecordStartFrom = LstOfRecords.Count - SelectedRecord * (NumberofPage - (CurrentPage - 1));
            var recorsToShow = LstOfRecords.Skip(RecordStartFrom).Take(SelectedRecord);
            UpdateCollection(recorsToShow);
            UpdateEnableState();
        }
        private void NextPage(object obj)
        {
            RecordStartFrom = CurrentPage * SelectedRecord;
            var recordsToShow = LstOfRecords.Skip(RecordStartFrom).Take(SelectedRecord);
            UpdateCollection(recordsToShow);
            CurrentPage++;
            UpdateEnableState();
        }

        private void UpdateRecordCount()
        {
            NumberofPage = (int)Math.Ceiling((double)LstOfRecords.Count / SelectedRecord);
            NumberofPage = NumberofPage == 0 ? 1 : NumberofPage;
            UpdateCollection(LstOfRecords.Take(SelectedRecord));
            CurrentPage = 1;
        }
        public List<Inventory> LstOfRecords { get; private set; } = new List<Inventory>();

        public MainViewModel()
        {   
            WindowLoaded = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (File.Exists(filePath))
                {
                    IsLoading = true;
                    Login login1 = new Login();
                    login1.Close();
                    Loaddatatonkho();
                }
                else
                {
                    IsLoading = true;
                    if (p == null)
                        return;
                    p.Hide();
                    Login login = new Login();
                    login.ShowDialog();
                    if (login.DataContext == null)
                        return;
                    var LoginVM = login.DataContext as LoginViewModel;
                    if (LoginVM.IsLogin)
                    {
                        Loaddatatonkho();
                        p.Show();

                    }
                    else
                    {
                        p.Close();
                    }
                }
                
                
            });
            Unitcommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                UnitWindow uw = new UnitWindow();
                uw.ShowDialog();
            });
            Suppliercommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                SupplierWindow sw = new SupplierWindow();
                sw.ShowDialog();
            });
            Customercommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CustomerWindow sw = new CustomerWindow();
                sw.ShowDialog();
            });
            Objectcommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                ObjectWindow ow = new ObjectWindow();
                ow.ShowDialog();
            }); 
            Usercommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                UserWindow ow = new UserWindow();
                ow.ShowDialog();
            });
            Inputcommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                InputWindow ow = new InputWindow();
                ow.ShowDialog();
            });
            Outputcommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                OutputWindow ow = new OutputWindow();
                ow.ShowDialog();
            });
            Logoutcommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    File.Delete(filePath);
                    p.Close();
                  //  Login login = new Login();
                   // login.ShowDialog();
                    
                }
            });
            #region Pagination
            NextCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                NextPage(p);
            });
            FirstCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                FirstPage(p);
            });
            LastCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                LastPage(p);
            });
            PreviousCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                PreviousPage(p);
            });
            #endregion


        }

        public void Loaddatatonkho()
        {
            Tonkholist = new ObservableCollection<Inventory>();

            var objectlist = Dataprovider._Istance.DB.Objects;
            int i = 1;
            int input = 0;
            int output = 0;
            foreach (var item in objectlist)
            {
                var Inputlist = Dataprovider._Istance.DB.InputInfoes.Where(p=> p.IdObject == item.Id);
                var Outputlist = Dataprovider._Istance.DB.OutputInfoes.Where(p => p.IdObject == item.Id);
                if (Inputlist != null && Inputlist.Count() >0)
                {
                    input = (int)Inputlist.Sum(p => p.Count);
                }
                if(Outputlist != null && Outputlist.Count() > 0)
                {
                    output = (int)Outputlist.Sum(p => p.Count);
                }

                Inventory inventory = new Inventory();
                inventory.STT = i;
                inventory.Object = item;
                inventory.Count = input - output;
                inventory.Input = input;
                inventory.Output = output;
                Soluongnhap += input;
                Soluongxuat += output;
                Soluongtonkho += input - output;
                LstOfRecords.Add(inventory);
                i++;  
            }

            UpdateCollection(LstOfRecords.Take(SelectedRecord));
            UpdateRecordCount();

        }
        private void UpdateCollection(IEnumerable<Inventory> iven)
        {
           // Tonkholist.Clear();
            foreach (var item in iven)
            {
                Tonkholist.Add(item);
            }
        }
    }
}
