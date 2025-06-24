namespace BisiyonPanelAPI.View.UserView
{
    public class DemirbasView
    {
        private int _Id;
        public int Id
        {
            get => _Id;
            set { _Id = value; }
        }
        private string _Adi;
        public string Adi
        {
            get => _Adi;
            set { _Adi = value; }
        }
        private int _Miktar;
        public int Miktar
        {
            get => _Miktar;
            set { _Miktar = value; }
        }
        private string _Turu;
        public string Turu
        {
            get => _Turu;
            set { _Turu = value; }
        }
        private string _Satici;
        public string Satici
        {
            get => _Satici;
            set { _Satici = value; }
        }
        private string _Serino;
        public string Serino
        {
            get => _Serino;
            set { _Serino = value; }
        }
        private DateTime _AlimTarihi;
        public DateTime AlimTarihi
        {
            get => _AlimTarihi;
            set { _AlimTarihi = value; }
        }
        private string _FaturaNo;
        public string FaturaNo
        {
            get => _FaturaNo;
            set { _FaturaNo = value; }
        }
        private decimal _Fiyat;
        public decimal Fiyat
        {
            get => _Fiyat;
            set { _Fiyat = value; }
        }
        private decimal _Kdv;
        public decimal Kdv
        {
            get => _Kdv;
            set { _Kdv = value; }
        }
        private decimal _Tutar;
        public decimal Tutar
        {
            get => _Tutar;
            set { _Tutar = value; }
        }
        private DateTime _GarantiBaslangicTarihi;
        public DateTime GarantiBaslangicTarihi
        {
            get => _GarantiBaslangicTarihi;
            set { _GarantiBaslangicTarihi = value; }
        }
        private DateTime _GarantiBitisTarihi;
        public DateTime GarantiBitisTarihi
        {
            get => _GarantiBitisTarihi;
            set { _GarantiBitisTarihi = value; }
        }
    }
}
