using Application.Core;
using Domain;
using MediatR;
using Persistence;
using System;

namespace Application.Activities
{
    /// <summary>
    /// this take care of logic to returning an individuel activity
    /// </summary>
    public class Datails
    {
        //public class Query : IRequest<Activity>
        //10
        public class Query : IRequest<Result<Activity>>
        {
            // we need to know which activity 
            public Guid Id { get; set; }

        }
        public class Handler : IRequestHandler<Query, Result<Activity>>
         //IRequestHandler<Query, Result<Activity>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public Guid Id { get; set; } = Guid.NewGuid();

            public async Task<Result<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.Id);

                return Result<Activity>.Success(activity);
            }
        }
    }
}
