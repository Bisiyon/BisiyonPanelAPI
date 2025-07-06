using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisiyonPanelAPI.View.BussinesObjects
{
    public class MeskenUyeBo
    {
        private int _Id;
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

        private int _MeskenId;
        public int MeskenId
        {
            get => _MeskenId;
            set { _MeskenId = value; }
        }
        public UyeBo Uye { get; set; }

    }
}
