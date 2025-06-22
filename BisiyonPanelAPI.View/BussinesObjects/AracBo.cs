using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisiyonPanelAPI.View.BussinesObjects
{
    public class AracBo 
    {
        private int _Id;
        public int Id
        {
            get => _Id;
            set { _Id = value; }
        }
        private int? _UyeId;
        public int? UyeId
        {
            get => _UyeId;
            set { _UyeId = value; }
        }
        [Required]
        [StringLength(15)]
        private string _Plaka;
        public string Plaka
        {
            get => _Plaka;
            set { _Plaka = value; }
        }
        [StringLength(100)]
        private string _Marka;
        public string Marka
        {
            get => _Marka;
            set { _Marka = value; }
        }
        [StringLength(100)]
        private string _Model;
        public string Model
        {
            get => _Model;
            set { _Model = value; }
        }
        [StringLength(100)]
        private string _Renk;
        public string Renk
        {
            get => _Renk;
            set { _Renk = value; }
        }
        [StringLength(250)]
        private string _Aciklama;
        public string Aciklama
        {
            get => _Aciklama;
            set { _Aciklama = value; }
        }
    }
}
