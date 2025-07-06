using BisiyonPanelAPI.View.BussinesObjects;
using Mapster;

namespace BisiyonPanelAPI.View.MeskenView.Response
{
    public class GetAllMeskenListResponseDto
    {
        public int Id { get; set; }
        public string BlokName { get; set; }
        public string Ad { get; set; }
        public string MalSahibi { get; set; }
        public string Oturan { get; set; }
        public string AidatGrubu { get; set; }
        public string ArsaPayi { get; set; }
        public string Oran1 { get; set; }
        public string Oran2 { get; set; }
        public string Oran3 { get; set; }
        public string Oran4 { get; set; }
        public string Oran5 { get; set; }
        public string Bakiye { get; set; }

        // public int? MeskenTipId { get; set; }
        // public int MalikHisse { get; set; } = 100;
        // public List<MeskenUyeBo> MeskenUyes { get; set; }
        

    }
}