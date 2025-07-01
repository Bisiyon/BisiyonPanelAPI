using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BisiyonPanelAPI.View.BussinesObjects
{
    public class BlokBo
    {
        private int _Id;
        public int Id
        {
            get => _Id;
            set { _Id = value; }
        }
        [StringLength(100)]
        private string _Ad;
        public string Ad
        {
            get => _Ad;
            set { _Ad = value; }
        }
        private int _ToplamDaireSayisi;
        public int ToplamDaireSayisi
        {
            get => _ToplamDaireSayisi;
            set { _ToplamDaireSayisi = value; }
        }
        private int _ToplamKatSayisi;
        public int ToplamKatSayisi
        {
            get => _ToplamKatSayisi;
            set { _ToplamKatSayisi = value; }
        }
        private int _VarsayilanKattakiDaireSayisi;
        public int VarsayilanKattakiDaireSayisi
        {
            get => _VarsayilanKattakiDaireSayisi;
            set { _VarsayilanKattakiDaireSayisi = value; }
        }
        private int _KatBaslangicKati;
        public int KatBaslangicKati
        {
            get => _KatBaslangicKati;
            set { _KatBaslangicKati = value; }
        }
        private bool _MeskenOlusturuldu;
        public bool MeskenOlusturuldu
        {
            get => _MeskenOlusturuldu;
            set { _MeskenOlusturuldu = value; }
        }
        private int _BlokTipId;
        public int BlokTipId
        {
            get => _BlokTipId;
            set { _BlokTipId = value; }
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
        private string _MahalleKoyMezraMevki;
        public string MahalleKoyMezraMevki
        {
            get => _MahalleKoyMezraMevki;
            set { _MahalleKoyMezraMevki = value; }
        }
        private string _CaddeSokak;
        public string CaddeSokak
        {
            get => _CaddeSokak;
            set { _CaddeSokak = value; }
        }
        private string _Apartman;
        public string Apartman
        {
            get => _Apartman;
            set { _Apartman = value; }
        }
        private string _BinaNo;
        public string BinaNo
        {
            get => _BinaNo;
            set { _BinaNo = value; }
        }
        private string _Aciklama;
        public string Aciklama
        {
            get => _Aciklama;
            set { _Aciklama = value; }
        }
    public ICollection<MeskenBo> Meskens { get; set; }
    }
}
