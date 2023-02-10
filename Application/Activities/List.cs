using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>> { };

        //Class handler is going to drive or use the request handler interface from mediator and we
        //pass it the query

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;

            //We need access to our data context.If we want to return a list of activities, then we need
            //to get them from our database.  So we're going to inject our DB context or our data context into
            //here, but it's not going to be a public
            public Handler(DataContext context) 
            {
                _context = context;
            }

            public async Task<List<Activity>>Handle(Query request, CancellationToken token)
            {
                return await _context.Activities.ToListAsync();
            }
            
        }

    }
}
