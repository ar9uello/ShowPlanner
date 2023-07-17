using AutoMapper;
using ShowPlanner.Shows;

namespace ShowPlanner
{
    public class ShowPlannerApplicationAutoMapperProfile : Profile
    {
        public ShowPlannerApplicationAutoMapperProfile()
        {
            CreateMap<ShowCreationDto, Show>();
            CreateMap<Show, ShowDto>();
            CreateMap<Show, ShowDetailDto>();
            CreateMap<ShowAttendee, ShowAttendeeDto>();
        }
    }
}
