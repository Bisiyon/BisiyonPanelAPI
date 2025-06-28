using BisiyonPanelAPI.View.BussinesObjects;

namespace BisiyonPanelAPI.View
{
    public class CreateNewBlokWithMeskenRequestDto
    {
        public CreateNewBlokWithMeskenRequestDto()
        {
            this.Meskens = new List<MeskenBo>();
        }
        public BlokBo Blok { get; set; }
        public List<MeskenBo> Meskens { get; set; }

    }
}