﻿using Application.Activities;
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
            return await Mediator.Send(new List.Query());
        }
        
        [HttpGet("{id}")] //api/activities/fdfkdffdfd
        //[Route("[api/activities]")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            // return await _context.Activities.FindAsync(id);
            return await Mediator.Send(new Datails.Query { Id= id });

        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity (Activity activity)
        {
            return Ok(await Mediator.Send(new Create.Command { Aktivity = activity}));
        }
    }
}
