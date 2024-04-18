using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;

namespace Restaurants.Application.Users.Commands.AssignUserRole
{
    public class AssignUserRoleCommandHandler
    (ILogger<AssignUserRoleCommandHandler> logger ,
    UserManager<User> userManager ,
    RoleManager<IdentityRole> roleManager) : IRequestHandler<AssignUserRoleCommand>
    {
        public async Task Handle(AssignUserRoleCommand request, CancellationToken cancellationToken)
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
            await userManager.AddToRoleAsync(user , role.Name!) ;
        }
    }
}