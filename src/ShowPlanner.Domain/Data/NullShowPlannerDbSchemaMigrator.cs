using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ShowPlanner.Data
{
    /* This is used if database provider does't define
     * IShowPlannerDbSchemaMigrator implementation.
     */
    public class NullShowPlannerDbSchemaMigrator : IShowPlannerDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}