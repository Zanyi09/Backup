using QuanlykhoWPF.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanlykhoWPF.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        //string FilePath = "login.txt";
        public bool IsLogin { get; set; }
        private string _username;
        public string Username { get => _username; set => _username = value; }
        private string _password;
        public string Password { get => _password; set => _password = value; }
        public ICommand Logincommand { get; set; }
        public ICommand Passwordcommand { get; set; }
        public ICommand Exitcommand { get; set; }
        public string filePath = "C:/Users/ssvan/source/repos/QuanlykhoWPF/login.txt";
        public LoginViewModel()
        {
            Username = "";
            Password = "";
            IsLogin = false;
            Logincommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Login(p); });
            Exitcommand = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });
            Passwordcommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
        }
        public void Login(Window p)
        {

            if (p == null)
                return;
            string passencode = MD5Hash(Base64Encode(Password));
            var account = Dataprovider._Istance.DB.Users.Where(x => x.UserName == Username && x.Password == passencode).Count();
            if (account > 0)
            {
                string token = GenerateToken(32);
                File.WriteAllText(filePath, token);
                //MessageBox.Show(token);
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
        public static string GenerateToken(int length)
        {
            // Tạo một mảng byte để chứa các giá trị số ngẫu nhiên
            byte[] randomBytes = new byte[length / 2];

            // Sử dụng RandomNumberGenerator để tạo các số ngẫu nhiên
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomBytes);
            }

            // Chuyển các số ngẫu nhiên thành chuỗi hexa
            StringBuilder tokenBuilder = new StringBuilder(length);
            foreach (byte b in randomBytes)
            {
                tokenBuilder.Append(b.ToString("x2"));
            }

            return tokenBuilder.ToString();
        }


    }
}
