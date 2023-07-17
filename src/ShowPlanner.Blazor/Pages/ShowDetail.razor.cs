using System;
using System.Linq;
using System.Threading.Tasks;
using ShowPlanner.Shows;
using Microsoft.AspNetCore.Components;

namespace ShowPlanner.Blazor.Pages
{
    public partial class ShowDetail
    {
        [Parameter]
        public string Id { get; set; }

        private ShowDetailDto Show { get; set; }
        private bool IsRegistered { get; set; }

        private readonly IShowAppService _showAppService;
        private readonly NavigationManager _navigationManager;

        public ShowDetail(
            IShowAppService showAppService,
            NavigationManager navigationManager)
        {
            _showAppService = showAppService;
            _navigationManager = navigationManager;
        }

        protected override async Task OnInitializedAsync()
        {
            await GetShowAsync();
        }

        private async Task GetShowAsync()
        {
            Show = await _showAppService.GetAsync(Guid.Parse(Id));
            if (CurrentUser.IsAuthenticated)
            {
                IsRegistered = Show.Attendees.Any(a => a.UserId == CurrentUser.Id);
            }
        }

        private async Task Register()
        {
            await _showAppService.RegisterAsync(Guid.Parse(Id));
            await GetShowAsync();
        }

        private async Task UnRegister()
        {
            await _showAppService.UnregisterAsync(Guid.Parse(Id));
            await GetShowAsync();
        }

        private async Task Delete()
        {
            if (!await Message.Confirm("This show will be deleted: " + Show.Title))
            {
                return;
            }

            await _showAppService.DeleteAsync(Guid.Parse(Id));
            _navigationManager.NavigateTo("/");
        }
    }
}
