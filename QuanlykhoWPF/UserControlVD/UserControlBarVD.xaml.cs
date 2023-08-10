using QuanlykhoWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuanlykhoWPF.UserControlVD
{
    /// <summary>
    /// Interaction logic for UserControlBarVD.xaml
    /// </summary>
    public partial class UserControlBarVD : UserControl
    {
        public ControlBarViewModel ViewModel { get; set; }
        public UserControlBarVD()
        {
            InitializeComponent();
            this.DataContext = ViewModel = new ControlBarViewModel();
        }
    }
}
