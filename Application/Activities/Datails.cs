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
        public class Query : IRequest<Activity>
        {
            // we need to know which activity 
            public Guid Id { get; set; }

        }
        public  class Handler : IRequestHandler<Query, Activity>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public Guid Id { get; set; } = Guid.NewGuid();

            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Activities.FindAsync(request.Id );
            }
        }
    }
}
