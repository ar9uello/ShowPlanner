using System.Collections.Generic;
using System.Threading.Tasks;
using ShowPlanner.Shows;

namespace ShowPlanner.Blazor.Pages
{
    public partial class Index
    {
        private List<ShowDto> UpcomingShows { get; set; } = new List<ShowDto>();

        private readonly IShowAppService _showAppService;

        public Index(IShowAppService showAppService)
        {
            _showAppService = showAppService;
        }

        protected override async Task OnInitializedAsync()
        {
            UpcomingShows = await _showAppService.GetUpcomingAsync();
        }
    }
}
