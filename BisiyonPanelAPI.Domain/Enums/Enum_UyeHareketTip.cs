namespace BisiyonPanelAPI.Domain
{
    public enum Enum_UyeHareketTip
    {
        /// <summary>
        /// Yeni bir üyenin ilk kez taşınması
        /// </summary>
        TasinmaGiris = 1,

        /// <summary>
        /// Üyenin taşınarak çıkması
        /// </summary>
        TasinmaCikis = 2,

        /// <summary>
        /// Aynı apartman içinde başka daireye geçiş
        /// </summary>
        DaireDegisikligi = 3,

        /// <summary>
        /// Kullanıcı bilgileri veya rolü değişmiş
        /// </summary>
        BilgiGuncelleme = 4,

        /// <summary>
        /// Geçici süreli giriş (örneğin misafir)
        /// </summary>
        GeciciGiris = 5,

        /// <summary>
        /// Vefat gibi durumlarla çıkış
        /// </summary>
        SistemselCikis = 6
    }
}