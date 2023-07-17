using System;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace ShowPlanner.Shows
{
    [Collection(ShowPlannerTestConsts.CollectionDefinitionName)]
    public class ShowAppService_Tests : ShowPlannerApplicationTestBase
    {
        private readonly IShowAppService _showAppService;

        public ShowAppService_Tests()
        {
            _showAppService = GetRequiredService<IShowAppService>();
        }

        [Fact]
        public async Task Should_Create_A_Valid_Show()
        {
            // Create an show

            var showId = await _showAppService.CreateAsync(
                new ShowCreationDto
                {
                    Title = "My test show 1",
                    Description = "My test show description 1",
                    IsFree = true,
                    StartTime = DateTime.Now.AddDays(2)
                }
            );

            showId.ShouldNotBe(Guid.Empty);

            // Get the show

            var show = await _showAppService.GetAsync(showId);
            show.Title.ShouldBe("My test show 1");

            // Get upcoming shows

            var shows = await _showAppService.GetUpcomingAsync();
            shows.ShouldContain(x => x.Title == "My test show 1");
        }
    }
}
