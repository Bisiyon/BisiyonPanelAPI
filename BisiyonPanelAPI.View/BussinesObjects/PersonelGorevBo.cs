using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisiyonPanelAPI.View.BussinesObjects
{
   public class PersonelGorevBo
{
    private int _Id;
    public int Id
    {
        get => _Id;
        set { _Id = value; }
    }

    private string _Ad;
    public string Ad
    {
        get => _Ad;
        set { _Ad = value; }
    }

    private string _Aciklama;
    public string Aciklama
    {
        get => _Aciklama;
        set { _Aciklama = value; }
    }

    private string _Adres;
    public string Adres
    {
        get => _Adres;
        set { _Adres = value; }
    }
}

}
