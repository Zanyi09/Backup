using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanlykhoWPF.Model
{
    public class Dataprovider
    {
        
        private static Dataprovider _istance;
        public static Dataprovider _Istance
        {
            get
            {
                if (_istance == null)
                    _istance = new Dataprovider();
                return _istance;
            }
            set { _istance = value; }
        }
        public QuanLyKhoEntities DB { get; set; }
        private Dataprovider()
        {
            DB = new QuanLyKhoEntities();
        }
        
    }
}
