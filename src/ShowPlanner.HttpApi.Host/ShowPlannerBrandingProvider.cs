using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ShowPlanner
{
    [Dependency(ReplaceServices = true)]
    public class ShowPlannerBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "ShowPlanner";
    }
}
