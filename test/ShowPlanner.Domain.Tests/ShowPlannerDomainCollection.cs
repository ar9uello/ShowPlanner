using ShowPlanner.MongoDB;
using Xunit;

namespace ShowPlanner
{
    [CollectionDefinition(ShowPlannerTestConsts.CollectionDefinitionName)]
    public class ShowPlannerDomainCollection : ShowPlannerMongoDbCollectionFixtureBase
    {

    }
}
