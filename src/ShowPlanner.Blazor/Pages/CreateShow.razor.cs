using System.Threading.Tasks;
using ShowPlanner.Shows;
using Microsoft.AspNetCore.Components;

namespace ShowPlanner.Blazor.Pages
{
    public partial class CreateShow
    {
        private ShowCreationDto Show { get; set; } = new ShowCreationDto();

        private readonly IShowAppService _showAppService;
        private readonly NavigationManager _navigationManager;

        public CreateShow(
            IShowAppService showAppService,
            NavigationManager navigationManager)
        {
            _showAppService = showAppService;
            _navigationManager = navigationManager;
        }

        private async Task Create()
        {
            var showId = await _showAppService.CreateAsync(Show);
            _navigationManager.NavigateTo("/shows/" + showId);
        }
    }
}
