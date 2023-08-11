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
        public string filePath = "C:/Users/ssvan/source/repos/QuanlykhoWPF/login.txt";
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


        }

        public void Loaddatatonkho()
        {
            Tonkholist = new ObservableCollection<Inventory>();

            var objectlist = Dataprovider._Istance.DB.Objects;
            int i = 1;
            foreach (var item in objectlist)
            {
                var Inputlist = Dataprovider._Istance.DB.InputInfoes.Where(p=> p.IdObject == item.Id);
                var Outputlist = Dataprovider._Istance.DB.OutputInfoes.Where(p=> p.IdObject == item.Id);

                int input = 0;
                int output = 0;

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

                Tonkholist.Add(inventory);
                i++;
                    
            }

        }
    }
}
