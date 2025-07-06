using Mapster;

namespace BisiyonPanelAPI.View.MeskenView.Response
{
    public class GetAllMeskenListResponseDto
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public int BlokId { get; set; }
        public string BlokName { get; set; }
        public int? MeskenTipId { get; set; }
        public int MalikHisse { get; set; } = 100;
        

    }
}