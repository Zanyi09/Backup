using FontAwesome.Sharp;
using QuanlykhoWPF.Model;
using QuanlykhoWPF.Views;
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
       
        public bool IsLoading = false;

        public string filePath = "C:/Users/IRTech/source/repos/QuanlykhoWPF/login.txt";

        private string _username;
        public string Username { get => _username; set { _username = value; OnPropertyChanged(); } }
        private string _caption;
        private IconChar _icon;
        public string Caption { get => _caption; set { _caption = value; OnPropertyChanged(); } }
        public IconChar Icon { get => _icon; set { _icon = value; OnPropertyChanged(); } }
       
        private BaseViewModel _currentChildView;
        public BaseViewModel CurrentChildView { get => _currentChildView; set { _currentChildView = value; OnPropertyChanged(); } }


        public ICommand WindowLoaded { get; set; }
        public ICommand LogoutCommand { get; set; }
        public ICommand Exitcommand { get; set; }
        public ICommand ShowHomeViewCommand { get; set; }
        public ICommand ShowHomeCustomer { get; set; }
        public ICommand ShowHomeSupplier { get; set; }
        public ICommand ShowHomeUnit { get; set; }       
        public ICommand ShowHomeObject { get; set; }
        public ICommand ShowHomeStaff { get; set; }
        public ICommand ShowHomeInput { get; set; }
        public MainViewModel() 
        {
           
            WindowLoaded = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (File.Exists(filePath))
                {
                    Username = File.ReadAllLines(filePath).FirstOrDefault();
                    OnPropertyChanged(nameof(Username));
                    IsLoading = true;
                    Login login = new Login();
                    login.Close();

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
                        p.Show();

                    }
                    else
                    {
                        p.Close();
                    }
                }
            });
            
            LogoutCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    File.Delete(filePath);
                    p.Close();
                }
            });
            Exitcommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                p.Close();
            });
            ShowHomeViewCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                CurrentChildView = new HomeViewModel();
                Caption = "Trang chủ";
                Icon = IconChar.Home;
                OnPropertyChanged(nameof(InputViewModel));

            });
            ShowHomeCustomer = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                CurrentChildView = new CustomerViewModel();
                Caption = "Khách hàng";
                Icon = IconChar.UserGroup;
                OnPropertyChanged(nameof(InputViewModel));
            }); 
            ShowHomeSupplier = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                CurrentChildView = new SupplierViewModel();
                Caption = "Nhà cung cấp";
                Icon = IconChar.Truck;
                OnPropertyChanged(nameof(InputViewModel));
            });
            ShowHomeUnit = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                CurrentChildView = new UnitViewModel();;
                Caption = "Đơn vị đo";
                Icon = IconChar.K;
                OnPropertyChanged(nameof(InputViewModel));
            });
            ShowHomeObject = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                CurrentChildView = new MainViewModel();
                Caption = "Vật tư";
                Icon = IconChar.Truck;
                OnPropertyChanged(nameof(InputViewModel));
            });  
            ShowHomeStaff = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                CurrentChildView = new StaffViewModel();
                Caption = "Nhân viên";
                Icon = IconChar.Person;
                OnPropertyChanged();
            });
            ShowHomeInput = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                CurrentChildView = new InputViewModel();
                Caption = "Nhập hàng";
                Icon = IconChar.ArrowAltCircleDown;
                OnPropertyChanged(nameof(InputViewModel));
            });
        }
    }
}
