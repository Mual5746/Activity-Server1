using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<Result<List<Activity>>> { }

        //Class handler is going to drive or use the request handler interface from mediator and we
        //pass it the query

        public class Handler : IRequestHandler<Query, Result<List<Activity>>>
        {
            private readonly DataContext _context;
            //private readonly ILogger<List> _logger;

            //We need access to our data context.If we want to return a list of activities, then we need
            //to get them from our database.  So we're going to inject our DB context or our data context into
            //here, but it's not going to be a public
            public Handler(DataContext context ) //, ILogger<List> logger) 
            {
                _context = context;
               // _logger = logger;
            }

            //public async Task<List<Activity>>Handle(Query request, CancellationToken token) // in case to want to use cancelation
            public async Task<Result<List<Activity>>> Handle(Query request, CancellationToken cancellationToken)
            {
                /*
                try
                {
                    for (var i = 0; i < 10; i++)
                    {
                        token.ThrowIfCancellationRequested();
                        await Task.Delay(1000, token);
                        _logger.LogInformation($"Task {i} has been completed ");
                    }

                } catch(Exception ex)
                {
                    _logger.LogInformation($"Task was canceled {ex}" );

                } */
                //return await _context.Activities.ToListAsync();
                return Result<List<Activity>>.Success(await _context.Activities.ToListAsync());
            }
            
        }

    }
}
