using ShowPlanner.Shows;
using MongoDB.Driver;
using ShowPlanner.Users;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace ShowPlanner.MongoDB
{
    [ConnectionStringName("Default")]
    public class ShowPlannerMongoDbContext : AbpMongoDbContext
    {
        public IMongoCollection<AppUser> Users => Collection<AppUser>();
        
        public IMongoCollection<Show> Shows => Collection<Show>();

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.Entity<AppUser>(b =>
            {
                /* Sharing the same "AbpUsers" collection
                 * with the Identity module's IdentityUser class. */
                b.CollectionName = "AbpUsers";
            });
        }
    }
}
