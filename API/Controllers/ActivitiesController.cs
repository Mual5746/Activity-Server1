using Application.Activities;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // [ApiController]
    //[Route("[controller]")]
    //[AllowAnonymous]
    public class ActivitiesController : BaseApiController
    { 
        //this service been created in BaseApiController 
        /*
        private readonly IMediator _mediator;

        // private readonly DataContext _context;

        public ActivitiesController(IMediator mediator)  //(DataContext context)
        {
            _mediator = mediator;
            // _context = context;
        }
        */
        [HttpGet] //api/activities
        //[Route("[api/activities]")]S
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            // return await _context.Activities.ToListAsync();
            //return await Mediator.Send(new List.Query());
            //10
            return HandleResult(await Mediator.Send(new List.Query()));
        }   
        [HttpGet("{id}")] //api/activities/fdfkdffdfd
        //[Route("[api/activities]")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            // return await _context.Activities.FindAsync(id);
            //return await Mediator.Send(new Datails.Query { Id= id });
            //10
            return HandleResult(await Mediator.Send(new Datails.Query { Id = id }));

        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity (Activity activity)
        {
            //return Ok(await Mediator.Send(new Create.Command { Aktivity = activity}));
            //10
            return HandleResult(await Mediator.Send(new Create.Command { Activity = activity }));
        }
       
        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity (Guid id, Activity activity)
        {
            activity.Id = id;
            //return Ok(await Mediator.Send(new Edit.Command { Activity = activity }))
            //10
            return HandleResult(await Mediator.Send(new Edit.Command { Activity = activity }));; 
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity (Guid id)
        {
            //return Ok(await Mediator.Send(new Delete.Command { Id= id }));
            //10
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
