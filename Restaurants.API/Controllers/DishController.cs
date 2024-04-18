using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes.Commands.CreateDish;
using Restaurants.Application.Dishes.Commands.DeleteAll;
using Restaurants.Application.Dishes.Dto;
using Restaurants.Application.Dishes.Queries.GetAll;
using Restaurants.Application.Dishes.Queries.GetBtId;

namespace Restaurants.API.Controllers
{
    [ApiController]
    [Route("api/restaurant/{RestaurantId:int}/dish")]
    public class DishController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DishDto>>> GetAll([FromRoute]int RestaurantId)
        {
            var dishes = await mediator.Send(new GetAllDishesQuery(RestaurantId));
            return Ok(dishes) ;
        }

        [HttpGet("{DishId:int}")]
        public async Task<ActionResult<DishDto>> GetById([FromRoute]int RestaurantId , [FromRoute]int DishId)
        {
            var dishDto = await mediator.Send(new GetDishByIdQuery(RestaurantId , DishId)) ;
            return Ok(dishDto) ;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromRoute]int RestaurantId , [FromBody]CreateDishCommand command)
        {
            command.RestaurantId = RestaurantId ;
            await mediator.Send(command);
            return Created();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAll([FromRoute]int RestaurantId)
        {
            await mediator.Send(new DeleteAllDishesCommand(RestaurantId)) ;
            return NoContent();
        }
    }
}