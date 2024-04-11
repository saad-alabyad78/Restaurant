using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;

namespace Restaurants.API.Controllers
{
    [ApiController]
    [Route("api/restaurant")]
    public class RestaurantController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var restaurants = await mediator.Send(new GetAllRestaurantsQuery());
            return Ok(restaurants);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var restaurant = await mediator.Send(new GetRestaurantByIdQuery(id)) ;
            if(restaurant == null){
                return BadRequest("not found") ;
            }
            return Ok(restaurant) ;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateRestaurantCommand command)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState) ;
            }
            int id = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById) , new {id} , null) ;
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            bool isDeleted = await mediator.Send(new DeleteRestaurantCommand(id));
            if(isDeleted)
            {
                return NoContent();
            }
            return NotFound();
        }
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> Update([FromRoute]int id , [FromBody]UpdateRestaurantCommand command)
        {
            command.Id = id ;
            bool isUpdated = await mediator.Send(command);

            if(isUpdated is false){
                return NotFound();
            }
            return CreatedAtAction(nameof(GetById) , new{id} , null);
        }

    }
}