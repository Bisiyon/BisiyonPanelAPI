namespace BisiyonPanelAPI.Domain
{
    public class KatDaireBilgisi
    {
        public int BlokId { get; set; }
        public string Renk { get; set; }
        public string KatAdi { get; set; }
        public int DaireSayisi { get; set; }
        public List<int> DaireNumaralari { get; set; }
    }

    public class KatDaireInput
    {
        public int BlokId { get; set; }
        public string Renk { get; set; }
        public string KatAdi { get; set; }
        public int DaireSayisi { get; set; }
    }

}