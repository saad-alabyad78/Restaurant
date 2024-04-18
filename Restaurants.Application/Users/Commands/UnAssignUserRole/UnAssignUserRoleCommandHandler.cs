using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;

namespace Restaurants.Application.Users.Commands.UnAssignUserRole
{
    public class UnAssignUserRoleCommandHandler
    (ILogger<UnAssignUserRoleCommandHandler> logger , 
    UserManager<User> userManager ,
    RoleManager<IdentityRole> roleManager) : IRequestHandler<UnAssignUserRoleCommand>
    {
        public async Task Handle(UnAssignUserRoleCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("assigning user {@email} to role {#role}" , request.Email , request.Role);

            var user = await userManager.FindByEmailAsync(request.Email) ??
                throw new NotFoundException(
                    resourceType : typeof(User).ToString() ,
                    resourceId : request.Email
                );
            var role = await roleManager.FindByNameAsync(request.Role) ??
                throw new NotFoundException(
                    resourceType : typeof(User).ToString() ,
                    resourceId : request.Email
                );
            await userManager.RemoveFromRoleAsync(user , role.Name!) ;
        }
    }
}