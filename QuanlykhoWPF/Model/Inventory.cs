using QuanlykhoWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanlykhoWPF.Model
{
    public class Inventory : BaseViewModel
    {
        private Object _object;
        public Object Object { get => _object; set { _object = value; OnPropertyChanged(); } }
        private int _stt;
        public int STT { get => _stt; set { _stt = value; OnPropertyChanged(); } }
        private int _count;
        public int Count { get => _count; set { _count = value; OnPropertyChanged(); } }
        private int _input;
        public int Input { get => _input; set { _input = value; OnPropertyChanged(); } }
        private int _output;
        public int Output { get => _output; set { _output = value; OnPropertyChanged(); } }
        private int _Iven;
        public int Iven { get => _Iven; set { _Iven = value; OnPropertyChanged(); } }
    }
}
