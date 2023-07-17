using ShowPlanner.Localization;
using Volo.Abp.AspNetCore.Components;

namespace ShowPlanner.Blazor
{
    public class ShowPlannerComponentBase : AbpComponentBase
    {
        public ShowPlannerComponentBase()
        {
            LocalizationResource = typeof(ShowPlannerResource);
        }
    }
}
