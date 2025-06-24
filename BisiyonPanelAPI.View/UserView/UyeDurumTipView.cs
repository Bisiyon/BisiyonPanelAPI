using System.ComponentModel.DataAnnotations;
namespace BisiyonPanelAPI.View.UserView
{
    public class UyeDurumTipView
    {
        public int Id { get; set; }
        /// <summary>
        /// Ev Sahibi, Kiracı, Sakin, Hissedar
        /// </summary>
        [StringLength(50)]
        public string Durum { get; set; }
    }
}
