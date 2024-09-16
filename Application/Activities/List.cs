using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<Result<List<ActivityDto>>> { }

        //Class handler is going to drive or use the request handler interface from mediator and we
        //pass it the query

        public class Handler : IRequestHandler<Query, Result<List<ActivityDto>>>
        {
            private readonly DataContext _context;
            public readonly IMapper _mapper;

            
            public Handler(DataContext context, IMapper mapper ) 
            {
                _mapper = mapper;
                _context = context;
            }

            //public async Task<List<Activity>>Handle(Query request, CancellationToken token) // in case to want to use cancelation
            public async Task<Result<List<ActivityDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
               var activities = await _context.Activities
               .Include( a => a.Attendees)
               .ThenInclude( u => u.AppUser)
               .ToListAsync();

               var activitiesToReturn = _mapper.Map<List<ActivityDto>>(activities);
                //return await _context.Activities.ToListAsync();
                return Result<List<ActivityDto>>.Success(activitiesToReturn);
            }
            
        }

    }
}
