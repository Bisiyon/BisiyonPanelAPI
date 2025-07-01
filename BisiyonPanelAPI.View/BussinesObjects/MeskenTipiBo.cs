using System.ComponentModel.DataAnnotations;

namespace BisiyonPanelAPI.View.BussinesObjects
{
    public class MeskenTipiBo
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

        private string _Kod;
        public string Kod
        {
            get => _Kod;
            set { _Kod = value; }
        }

        private string _DataKey;
        public string DataKey
        {
            get => _DataKey;
            set { _DataKey = value; }
        }

        private string _Renk;
        public string Renk
        {
            get => _Renk;
            set { _Renk = value; }
        }
    }
}
