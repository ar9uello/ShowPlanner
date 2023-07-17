using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ShowPlanner.Shows
{
    public interface IShowAppService : IApplicationService
    {
        Task<Guid> CreateAsync(ShowCreationDto input);

        Task<List<ShowDto>> GetUpcomingAsync();

        Task<ShowDetailDto> GetAsync(Guid id);

        Task RegisterAsync(Guid id);

        Task UnregisterAsync(Guid id);

        Task DeleteAsync(Guid id);
    }
}
