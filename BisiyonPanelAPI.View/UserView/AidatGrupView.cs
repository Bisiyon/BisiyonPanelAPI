using System.ComponentModel.DataAnnotations;

namespace BisiyonPanelAPI.View.UserView
{
    public class AidatGrupView
    {
        private int _Id;
        public int Id
        {
            get => _Id;
            set { _Id = value; }
        }
        private string _Ad;
        public string Ad
        {
            get => _Ad;
            set { _Ad = value; }
        }
    }
}
