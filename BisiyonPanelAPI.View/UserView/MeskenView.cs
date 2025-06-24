
using System.ComponentModel.DataAnnotations;

namespace BisiyonPanelAPI.View.UserView
{
    public class MeskenView
    {
        private int _Id;
        public int Id
        {
            get => _Id;
            set { _Id = value; }
        }
        private int _BlokId;
        public int BlokId
        {
            get => _BlokId;
            set { _BlokId = value; }
        }
        private int? _MeskenTipId;
        public int? MeskenTipId
        {
            get => _MeskenTipId;
            set { _MeskenTipId = value; }
        }
        private int _MalikHisse = 100;
        public int MalikHisse
        {
            get => _MalikHisse;
            set { _MalikHisse = value; }
        }
        [StringLength(100)]
        private string _Ad;
        public string Ad
        {
            get => _Ad;
            set { _Ad = value; }
        }
        private int? _Kat;
        public int? Kat
        {
            get => _Kat;
            set { _Kat = value; }
        }
        private int? _DaireNo;
        public int? DaireNo
        {
            get => _DaireNo;
            set { _DaireNo = value; }
        }
        private int? _M2;
        public int? M2
        {
            get => _M2;
            set { _M2 = value; }
        }
        private int? _ArsaPayi;
        public int? ArsaPayi
        {
            get => _ArsaPayi;
            set { _ArsaPayi = value; }
        }
        private int _Oran1 = 100;
        public int Oran1
        {
            get => _Oran1;
            set { _Oran1 = value; }
        }
        private int _Oran2 = 100;
        public int Oran2
        {
            get => _Oran2;
            set { _Oran2 = value; }
        }
        private int _Oran3 = 100;
        public int Oran3
        {
            get => _Oran3;
            set { _Oran3 = value; }
        }
        private int _Oran4 = 100;
        public int Oran4
        {
            get => _Oran4;
            set { _Oran4 = value; }
        }
        private int _Oran5 = 100;
        public int Oran5
        {
            get => _Oran5;
            set { _Oran5 = value; }
        }
        private int _Oran6 = 100;
        public int Oran6
        {
            get => _Oran6;
            set { _Oran6 = value; }
        }
        private int _Oran7 = 100;
        public int Oran7
        {
            get => _Oran7;
            set { _Oran7 = value; }
        }
        private int _Oran8 = 100;
        public int Oran8
        {
            get => _Oran8;
            set { _Oran8 = value; }
        }
        private int _Oran9 = 100;
        public int Oran9
        {
            get => _Oran9;
            set { _Oran9 = value; }
        }
        private int? _KisiSayisi;
        public int? KisiSayisi
        {
            get => _KisiSayisi;
            set { _KisiSayisi = value; }
        }
        private int? _AidatGrupId;
        public int? AidatGrupId
        {
            get => _AidatGrupId;
            set { _AidatGrupId = value; }
        }
    }
}
