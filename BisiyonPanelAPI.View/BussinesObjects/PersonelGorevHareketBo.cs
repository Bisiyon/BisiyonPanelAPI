using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisiyonPanelAPI.View.BussinesObjects
{
    public class PersonelGorevHareketBo
    {
        private int _Id;
        public int Id
        {
            get => _Id;
            set { _Id = value; }
        }

        private int _PersonelId;
        public int PersonelId
        {
            get => _PersonelId;
            set { _PersonelId = value; }
        }

        private int _PersonelGorevId;
        public int PersonelGorevId
        {
            get => _PersonelGorevId;
            set { _PersonelGorevId = value; }
        }

        private DateTime _Tarih;
        public DateTime Tarih
        {
            get => _Tarih;
            set { _Tarih = value; }
        }

        private int _GorevHareketTip;
        public int GorevHareketTip
        {
            get => _GorevHareketTip;
            set { _GorevHareketTip = value; }
        }

        // Eğer ilişkili tablolardan ad bilgisini göstermek istersen
        private string _PersonelAdSoyad;
        public string PersonelAdSoyad
        {
            get => _PersonelAdSoyad;
            set { _PersonelAdSoyad = value; }
        }

        private string _GorevAd;
        public string GorevAd
        {
            get => _GorevAd;
            set { _GorevAd = value; }
        }
    }

}


