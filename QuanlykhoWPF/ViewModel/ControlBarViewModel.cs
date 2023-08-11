using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;

namespace QuanlykhoWPF.ViewModel
{
    public class ControlBarViewModel : BaseViewModel
    {
        #region
        public ICommand CloseWindowCommand { get; set; }
        public ICommand CloseWindowMinimize { get; set; }
        public ICommand CloseWindowMaximize { get; set; }
        public ICommand MouseMove { get; set; }

        #endregion

        public ControlBarViewModel()
        {
            CloseWindowCommand = new RelayCommand<System.Windows.Controls.UserControl>((p) => { return p == null ? false : true; }, (p) => {
                FrameworkElement window = GetWindowParent(p);
                var w = window as Window;
                if (w != null)
                {
                    DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        w.Close();
                    }
       
                }
            }
            );
            CloseWindowMinimize = new RelayCommand<System.Windows.Controls.UserControl>((p) => { return p == null ? false : true; }, (p) => {
                FrameworkElement window = GetWindowParent(p);
                var w = window as Window;
                if (w != null)
                {
                   if (w.WindowState != WindowState.Minimized)
                        w.WindowState = WindowState.Minimized;
                    else
                        w.WindowState = WindowState.Normal;
                }
            }
            );
            CloseWindowMaximize = new RelayCommand<System.Windows.Controls.UserControl>((p) => { return p == null ? false : true; }, (p) => {
                FrameworkElement window = GetWindowParent(p);
                var w = window as Window;
                if (w != null)
                {
                    if (w.WindowState != WindowState.Maximized)
                        w.WindowState = WindowState.Maximized;
                    else
                        w.WindowState = WindowState.Normal;
                }
            }
            );
            MouseMove = new RelayCommand<System.Windows.Controls.UserControl>((p) => { return p == null ? false : true; }, (p) => {
                FrameworkElement window = GetWindowParent(p);
                var w = window as Window;
                if (w != null)
                {
                    w.DragMove();
                }
            }
            );
        }
        FrameworkElement GetWindowParent(System.Windows.Controls.UserControl p)
        {
            FrameworkElement parent = p;

            while (parent.Parent != null)
            {
                parent = parent.Parent as FrameworkElement;
            }

            return parent;
        }
    }
}
