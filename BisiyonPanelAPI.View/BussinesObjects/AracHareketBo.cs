using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisiyonPanelAPI.View.BussinesObjects
{
    public class AracHareketBo
    {
        private int _Id;
        public int Id
        {
            get => _Id;
            set { _Id = value; }
        }

        private int _AracId;
        public int AracId
        {
            get => _AracId;
            set { _AracId = value; }
        }

        private int _AracHereketTipId;
        public int AracHereketTipId
        {
            get => _AracHereketTipId;
            set { _AracHereketTipId = value; }
        }

    }
}
