using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            //we wanna map from activity to actvity 
            CreateMap<Activity, Activity >();
        }
    }
}
