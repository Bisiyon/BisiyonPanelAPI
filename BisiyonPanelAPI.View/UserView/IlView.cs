using System.ComponentModel.DataAnnotations;

namespace BisiyonPanelAPI.View.UserView
{
    public class IlView
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
