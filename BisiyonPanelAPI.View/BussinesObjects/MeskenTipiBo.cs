using System.ComponentModel.DataAnnotations;

namespace BisiyonPanelAPI.View.BussinesObjects
{
    public class MeskenTipiBo
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Tip { get; set; }
        [StringLength(3)]
        public string Kod { get; set; }
        public string Renk { get; set; }
    }
}
