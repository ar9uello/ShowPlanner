using Volo.Abp.Modularity;

namespace ShowPlanner
{
    [DependsOn(
        typeof(ShowPlannerApplicationModule),
        typeof(ShowPlannerDomainTestModule)
        )]
    public class ShowPlannerApplicationTestModule : AbpModule
    {

    }
}