using BisiyonPanelAPI.View.BussinesObjects;
using Mapster;

namespace BisiyonPanelAPI.View.UyeView.Response
{
    public class MeskenUyeListView
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UyeTipIsmi { get; set; }
        public string MalikHisse { get; set; }
        public string Miktar { get; set; }
        public string BaslangicTarihi { get; set; }
        public string BitisTarihi { get; set; }

    }
}
