using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisiyonPanelAPI.View.BussinesObjects
{
    public class MeskenUyeBo
    {
        private int _Id;
        [Key]
        public int Id
        {
            get => _Id;
            set { _Id = value; }
        }

        private int _UyeId;
        public int UyeId
        {
            get => _UyeId;
            set { _UyeId = value; }
        }

        private int _UyeDurumTipId;
        public int UyeDurumTipId
        {
            get => _UyeDurumTipId;
            set { _UyeDurumTipId = value; }
        }

        private int _MeskenId;
        public int MeskenId
        {
            get => _MeskenId;
            set { _MeskenId = value; }
        }

        private int _MalikHisse = 100;
        public int MalikHisse
        {
            get => _MalikHisse;
            set { _MalikHisse = value; }
        }


    }
}
