using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Interface;
using BisiyonPanelAPI.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;

namespace BisiyonPanelAPI.Api
{
    public class AidatController : BaseController
    {
        private readonly IAidatService _aidatService;

        public AidatController( IAidatService aidatService)
        {
            _aidatService = aidatService;
        }

    }
}