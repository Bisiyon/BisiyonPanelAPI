using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisiyonPanelAPI.View.BussinesObjects
{
    public class MeskenUyeBo
    {
        public int Id { get; set; }
        public int UyeId { get; set; }
        public int MeskenId { get; set; }
    }
}
