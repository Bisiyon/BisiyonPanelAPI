using System.ComponentModel.DataAnnotations;

namespace BisiyonPanelAPI.View.UserView
{
    public class AidatView
    {
        private int _Id;
        public int Id
        {
            get => _Id;
            set { _Id = value; }
        }
        private string _Ad;
        public string Ad
        {
            get => _Ad;
            set { _Ad = value; }
        }
        private int? _ToplamArsaPayi;
        public int? ToplamArsaPayi
        {
            get => _ToplamArsaPayi;
            set { _ToplamArsaPayi = value; }
        }
        private bool _SabiteDahilMi;
        public bool SabiteDahilMi
        {
            get => _SabiteDahilMi;
            set { _SabiteDahilMi = value; }
        }
        private int? _ToplamMesken;
        public int? ToplamMesken
        {
            get => _ToplamMesken;
            set { _ToplamMesken = value; }
        }
        private int? _ArsaPayi;
        public int? ArsaPayi
        {
            get => _ArsaPayi;
            set { _ArsaPayi = value; }
        }
        private decimal? _SabitTutar;
        public decimal? SabitTutar
        {
            get => _SabitTutar;
            set { _SabitTutar = value; }
        }
        private decimal? _ArsaPayiTutar;
        public decimal? ArsaPayiTutar
        {
            get => _ArsaPayiTutar;
            set { _ArsaPayiTutar = value; }
        }
        private decimal? _Tutar;
        public decimal? Tutar
        {
            get => _Tutar;
            set { _Tutar = value; }
        }
    }
}
