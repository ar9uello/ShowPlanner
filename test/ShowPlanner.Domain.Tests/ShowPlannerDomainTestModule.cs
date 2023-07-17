using ShowPlanner.MongoDB;
using Volo.Abp.Modularity;

namespace ShowPlanner
{
    [DependsOn(
        typeof(ShowPlannerMongoDbTestModule)
        )]
    public class ShowPlannerDomainTestModule : AbpModule
    {

    }
}