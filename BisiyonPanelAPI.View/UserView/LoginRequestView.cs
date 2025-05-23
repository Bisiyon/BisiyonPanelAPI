namespace BisiyonPanelAPI.View
{
    public class LoginRequestView
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string SiteCode { get; set; }
    }
}