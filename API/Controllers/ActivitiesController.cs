using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    // [ApiController]
    //[Route("[controller]")]
    public class ActivitiesController : BaseApiController
    {
        private readonly IMediator _mediator;

        // private readonly DataContext _context;

        public ActivitiesController(IMediator mediator)  //(DataContext context)
        {
            _mediator = mediator;
            // _context = context;
        }

        [HttpGet] //api/activities
        //[Route("[api/activities]")]S
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
           // return await _context.Activities.ToListAsync();
           return await _mediator.Send(new List.)
           return await Mediator.Send(new List.Query());
        }
        
        [HttpGet("{id}")] //api/activities/fdfkdffdfd
        //[Route("[api/activities]")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await _context.Activities.FindAsync(id);

        }
    }
}
