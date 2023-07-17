using System.Threading.Tasks;

namespace ShowPlanner.Data
{
    public interface IShowPlannerDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
