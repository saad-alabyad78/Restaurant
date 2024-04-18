using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;

namespace Restaurants.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler
    (ILogger<UpdateUserCommandHandler> logger ,
    IUserContext userContext ,
    IUserStore<User> userStore) : IRequestHandler<UpdateUserCommand>
    {
        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
     
            var user = userContext.GetCurrentUser() ;
           
            logger.LogInformation("updating  user: {userId} , with {@request}" ,user!.Id , request);
          
            var dbUser = await userStore.FindByIdAsync(user!.Id , cancellationToken);


            if(dbUser is null)
            {
                throw new NotFoundException(
                    resourceType: typeof(User).ToString() ,
                    resourceId: user!.Id.ToString() 
                );
            }
            
            dbUser.DateOfBirth = request?.DateOfBirth ?? dbUser.DateOfBirth;
            dbUser.Nationality = request?.Nationality ?? dbUser.Nationality;

            await userStore.UpdateAsync(dbUser , cancellationToken) ;
        }
    }
}