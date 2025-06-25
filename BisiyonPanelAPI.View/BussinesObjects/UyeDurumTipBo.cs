using System.ComponentModel.DataAnnotations;

namespace BisiyonPanelAPI.View.BussinesObjects
{
    public class UyeDurumTipBo
    {
        public int Id { get; set; }
        /// <summary>
        /// Ev Sahibi, Kiracı, Sakin, Hissedar
        /// </summary>
        [StringLength(50)]
        public string Durum { get; set; }
    }
}
