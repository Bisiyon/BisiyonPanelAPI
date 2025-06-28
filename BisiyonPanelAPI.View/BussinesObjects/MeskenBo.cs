using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Mapster;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace BisiyonPanelAPI.View.BussinesObjects
{
    public class MeskenBo
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
         [AdaptMember("Ad")]
        private string _BuPropIsimPropu;
        public string BuPropIsimPropu
        {
            get => _BuPropIsimPropu;
            set { _BuPropIsimPropu = value; }
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
        [ValidateNever]
        public AidatGrupBo AidatGrup { get; set; }
        [ValidateNever]
        public MeskenTipiBo MeskenTipi { get; set; }

    }
}

