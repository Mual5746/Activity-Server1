using Application.Core;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    /// <summary>
    /// this take care of logic to returning an individuel activity
    /// </summary>
    public class Datails
    {
        //public class Query : IRequest<Activity>
        //10
        public class Query : IRequest<Result<ActivityDto>>
        {
            // we need to know which activity 
            public Guid Id { get; set; }

        }
        public class Handler : IRequestHandler<Query, Result<ActivityDto>>
         //IRequestHandler<Query, Result<Activity>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            private readonly IUserAccessor _userAccessor;

            public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
                _mapper = mapper;
                _context = context;
            }

            public Guid Id { get; set; } = Guid.NewGuid();

            public async Task<Result<ActivityDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities
                    .ProjectTo<ActivityDto>(_mapper.ConfigurationProvider,
                         new{currentUsername = _userAccessor.GetUsername()})
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                return Result<ActivityDto>.Success(activity);
            }
        }
    }
}
