using QuanlykhoWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanlykhoWPF.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public bool IsLogin { get; set; }
        private string _username;
        public string Username { get => _username; set => _username = value; }
        private string _password;
        public string Password { get => _password; set => _password =value; }
        public ICommand Logincommand { get; set; }
        public ICommand Passwordcommand { get; set; }
        public ICommand Exitcommand { get; set; }

        public LoginViewModel()
        {
            Username = "";
            Password = "";
            IsLogin = false;
            Logincommand = new RelayCommand<Window>((p) => { return true; }, (p) =>{ Login(p); });
            Exitcommand = new RelayCommand<Window>((p) => { return true; }, (p) =>{ p.Close(); });
            Passwordcommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>{ Password = p.Password; });
        }
        public void Login( Window p)
        {
           
            if (p == null)
                return;
            string passencode = MD5Hash(Base64Encode(Password));
            var account = Dataprovider._Istance.DB.Users.Where(x => x.UserName == Username && x.Password == passencode).Count();
            if(account > 0)
            {
                IsLogin = true;

                p.Close();
            }
            else
            {
                IsLogin = false;
                MessageBox.Show("Sai mật khẩu hoặc tài khoản!");
            }
          
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
