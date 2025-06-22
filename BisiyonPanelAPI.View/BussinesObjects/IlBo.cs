using System.ComponentModel.DataAnnotations;

namespace BisiyonPanelAPI.View.BussinesObjects
{
    public class IlBo
    {
        private int _Id;
        public int Id
        {
            get => _Id;
            set { _Id = value; }
        }
        [StringLength(50)]
        private string _Ad;
        public string Ad
        {
            get => _Ad;
            set { _Ad = value; }
        }
    }
}
