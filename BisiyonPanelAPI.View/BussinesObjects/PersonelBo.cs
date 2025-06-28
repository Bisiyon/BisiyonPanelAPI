using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisiyonPanelAPI.View.BussinesObjects
{
    public class PersonelBo
    {

        private int _Id;
        public int Id
        {
            get => _Id;
            set { _Id = value; }
        }

        private int _PersonelTipId;
        public int PersonelTipId
        {
            get => _PersonelTipId;
            set { _PersonelTipId = value; }
        }

        private string _SicilNo;
        public string SicilNo
        {
            get => _SicilNo;
            set { _SicilNo = value; }
        }

        private string _Ad;
        public string Ad
        {
            get => _Ad;
            set { _Ad = value; }
        }

        private string _Soyad;
        public string Soyad
        {
            get => _Soyad;
            set { _Soyad = value; }
        }

        private string _CinsiyetId;
        public string CinsiyetId
        {
            get => _CinsiyetId;
            set { _CinsiyetId = value; }
        }

        private string _TCKimlikNo;
        public string TCKimlikNo
        {
            get => _TCKimlikNo;
            set { _TCKimlikNo = value; }
        }

        private string _DogumTarihi;
        public string DogumTarihi
        {
            get => _DogumTarihi;
            set { _DogumTarihi = value; }
        }

        private string _CepTelefonu;
        public string CepTelefonu
        {
            get => _CepTelefonu;
            set { _CepTelefonu = value; }
        }

        private string _Email;
        public string Email
        {
            get => _Email;
            set { _Email = value; }
        }

        private int _IlId;
        public int IlId
        {
            get => _IlId;
            set { _IlId = value; }
        }

        private int _IlceId;
        public int IlceId
        {
            get => _IlceId;
            set { _IlceId = value; }
        }

        private DateTime? _IseGirisTarihi;
        public DateTime? IseGirisTarihi
        {
            get => _IseGirisTarihi;
            set { _IseGirisTarihi = value; }
        }

        private DateTime? _IstenCikisTarihi;
        public DateTime? IstenCikisTarihi
        {
            get => _IstenCikisTarihi;
            set { _IstenCikisTarihi = value; }
        }

        private string _Aciklama;
        public string Aciklama
        {
            get => _Aciklama;
            set { _Aciklama = value; }
        }

        private string _Adres;
        public string Adres
        {
            get => _Adres;
            set { _Adres = value; }
        }

        // Eğer il, ilçe ve personel tip bilgileri DTO içinde gösterilmek isteniyorsa:
        private string _IlAdi;
        public string IlAdi
        {
            get => _IlAdi;
            set { _IlAdi = value; }
        }

        private string _IlceAdi;
        public string IlceAdi
        {
            get => _IlceAdi;
            set { _IlceAdi = value; }
        }

        private string _PersonelTipAdi;
        public string PersonelTipAdi
        {
            get => _PersonelTipAdi;
            set { _PersonelTipAdi = value; }
        }

    }
}
