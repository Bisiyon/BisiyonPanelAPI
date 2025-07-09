namespace BisiyonPanelAPI.View.BussinesObjects
{
    public class UyeHareketBo
    {
        private int _Id;
        public int Id
        {
            get => _Id;
            set { _Id = value; }
        }

        private int _UyeId;
        public int UyeId
        {
            get => _UyeId;
            set { _UyeId = value; }
        }

        private int _MeskenId;
        public int MeskenId
        {
            get => _MeskenId;
            set { _MeskenId = value; }
        }

        private DateTime _IslemTarih;
        public DateTime IslemTarih
        {
            get => _IslemTarih;
            set { _IslemTarih = value; }
        }

        private int _HareketTipId;
        public int HareketTipId
        {
            get => _HareketTipId;
            set { _HareketTipId = value; }
        }
    }
}

