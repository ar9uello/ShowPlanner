using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShowPlanner.Users;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace ShowPlanner.Shows
{
    public class ShowAppService : ShowPlannerAppService, IShowAppService
    {
        private readonly IRepository<Show, Guid> _showRepository;
        private readonly IRepository<AppUser, Guid> _userRepository;

        public ShowAppService(IRepository<Show, Guid> showRepository, IRepository<AppUser, Guid> userRepository)
        {
            _showRepository = showRepository;
            _userRepository = userRepository;
        }

        [Authorize]
        public async Task<Guid> CreateAsync(ShowCreationDto input)
        {
            var showEntity = ObjectMapper.Map<ShowCreationDto, Show>(input);
            await _showRepository.InsertAsync(showEntity);
            return showEntity.Id;
        }

        public async Task<List<ShowDto>> GetUpcomingAsync()
        {
            var queryable = await _showRepository.GetQueryableAsync();
            var query = queryable
                .OrderBy(x => x.StartTime);
            
            var shows = await AsyncExecuter.ToListAsync(query);

            return ObjectMapper.Map<List<Show>, List<ShowDto>>(shows);
        }

        public async Task<ShowDetailDto> GetAsync(Guid id)
        { 
            var show = await _showRepository.GetAsync(id);
            var attendeeIds = show.Attendees.Select(a => a.UserId).ToList();

            var queryable = await _userRepository.GetQueryableAsync();
            var query = queryable
                .Where(u => attendeeIds.Contains(u.Id));
            
            var attendees = (await AsyncExecuter.ToListAsync(query))
                .ToDictionary(x => x.Id);

            var result = ObjectMapper.Map<Show, ShowDetailDto>(show);

            if (attendees.Count > 1)
            {
                foreach (var attendeeDto in result.Attendees)
                {
                    attendeeDto.UserName = attendees[attendeeDto.UserId].UserName;
                }
            }
            
            return result;
        }

        [Authorize]
        public async Task RegisterAsync(Guid id)
        {
            var show = await _showRepository.GetAsync(id);
            if (show.Attendees.Any(a => a.UserId == CurrentUser.Id))
            {
                return;
            }

            show.Attendees.Add(new ShowAttendee {UserId = CurrentUser.GetId(), CreationTime = Clock.Now});
            await _showRepository.UpdateAsync(show);
        }

        [Authorize]
        public async Task UnregisterAsync(Guid id)
        {
            var show = await _showRepository.GetAsync(id);
            var removedItems = show.Attendees.RemoveAll(x => x.UserId == CurrentUser.Id);
            if (removedItems.Any())
            {
                await _showRepository.UpdateAsync(show);
            }
        }

        [Authorize]
        public async Task DeleteAsync(Guid id)
        {
            var show = await _showRepository.GetAsync(id);

            if (CurrentUser.Id != show.CreatorId)
            {
                throw new UserFriendlyException("You don't have the necessary permission to delete this show!");
            }

            await _showRepository.DeleteAsync(id);
        }
    }
}
