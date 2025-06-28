using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisiyonPanelAPI.View.BussinesObjects
{
    public class PersonelTipBo
    {
        private int _Id;
        public int Id
        {
            get => _Id;
            set { _Id = value; }
        }
        private string _Tip;
        public string Tip
        {
            get => _Tip;
            set { _Tip = value; }
        }
    }
}
