using ShowPlanner.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ShowPlanner.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class ShowPlannerController : AbpController
    {
        protected ShowPlannerController()
        {
            LocalizationResource = typeof(ShowPlannerResource);
        }
    }
}