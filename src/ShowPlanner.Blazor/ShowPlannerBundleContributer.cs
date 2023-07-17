using Volo.Abp.Bundling;

namespace ShowPlanner.Blazor
{
    public class ShowPlannerBundleContributer : IBundleContributor
    {
        public void AddScripts(BundleContext context)
        {
        }

        public void AddStyles(BundleContext context)
        {
            context.Add("main.css", true);
        }
    }
}
