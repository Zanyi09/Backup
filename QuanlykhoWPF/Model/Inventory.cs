using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanlykhoWPF.Model
{
    public class Inventory
    {
        public Object Object { get; set; }
        public int STT { get; set; }
        public int Count { get; set; }
        public int Input { get; set; }
        public int Output { get; set; }
        public int Iven { get; set; }
    }
}
