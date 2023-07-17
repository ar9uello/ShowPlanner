using ShowPlanner.MongoDB;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace ShowPlanner.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(ShowPlannerMongoDbModule),
        typeof(ShowPlannerApplicationContractsModule)
        )]
    public class ShowPlannerDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
