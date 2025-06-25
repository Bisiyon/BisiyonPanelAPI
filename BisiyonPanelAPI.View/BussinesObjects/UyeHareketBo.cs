using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisiyonPanelAPI.View.BussinesObjects
{
    public class UyeHareketBo
    {
        public int Id { get; set; }
        public int UyeId { get; set; }
        public DateTime IslemTarih { get; set; }
        public int HareketTipId { get; set; }
    }
}
