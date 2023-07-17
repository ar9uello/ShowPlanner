using System;
using System.Collections.Generic;
using System.Text;
using ShowPlanner.Localization;
using Volo.Abp.Application.Services;

namespace ShowPlanner
{
    /* Inherit your application services from this class.
     */
    public abstract class ShowPlannerAppService : ApplicationService
    {
        protected ShowPlannerAppService()
        {
            LocalizationResource = typeof(ShowPlannerResource);
        }
    }
}
