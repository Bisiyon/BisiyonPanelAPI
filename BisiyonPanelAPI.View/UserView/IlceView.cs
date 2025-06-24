using System.ComponentModel.DataAnnotations;

namespace BisiyonPanelAPI.View.UserView
{
    public class IlceView
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
        private int _IlId;
        public int IlId
        {
            get => _IlId;
            set { _IlId = value; }
        }
    }
}
